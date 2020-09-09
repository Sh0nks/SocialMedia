using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get()
        { 
            IEnumerable<Post> posts = await _repository.GetPosts();
            return _mapper.Map<List<PostDto>>(posts);
        }

        [HttpGet("{id}")]
        public async Task<PostDto> Get(int id)
        {
            Post post = await _repository.GetPost(id);
            return _mapper.Map<PostDto>(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Create(PostDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto); 
            await _repository.Create(post);
            return Created($"{post.Id}", _mapper.Map<PostDto>(post));
        }
    }
}
