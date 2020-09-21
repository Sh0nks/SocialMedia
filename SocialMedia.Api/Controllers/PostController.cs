using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly IMapper _mapper;

        public PostController(IPostService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        public ActionResult Get()
        { 
            IEnumerable<Post> posts = _service.GetPosts();
            return Ok(new ApiResponse<IEnumerable<PostDto>>(_mapper.Map<List<PostDto>>(posts)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Post post = await _service.Get(id);
            return Ok(new ApiResponse<PostDto>(_mapper.Map<PostDto>(post)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto); 
            await _service.Create(post);
            return Created($"{post.Id}", new ApiResponse<PostDto>(_mapper.Map<PostDto>(post)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);
            post.Id = id;
            await _service.Update(post);
           return Ok(new ApiResponse<PostDto>(postDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool deleted = await _service.Delete(id);
            return Ok(new ApiResponse<bool>(deleted));
        }
        
    }
}
