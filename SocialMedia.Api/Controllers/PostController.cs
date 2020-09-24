using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.Collections;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastruncture.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PostController(IPostService service, IMapper mapper, IUriService uriService)
        {
            _mapper = mapper;
            _service = service;
            _uriService = uriService;
        }
        
        [HttpGet(Name = "Post-List")]
        public ActionResult Get([FromQuery] PostQueryFilter filters)
        {
           
            PagedList<Post> posts = _service.GetPosts(filters);
            var uri = _uriService.getPostPaginatedUri(filters, Url.RouteUrl("Post-List"));
            var pagginationData = new Metadata
            {
                Total = posts.TotalPage,
                TotalCount = posts.TotalCount,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = uri.ToString()
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagginationData));
            ApiResponse<IEnumerable<PostDto>> response = new ApiResponse<IEnumerable<PostDto>>(
                _mapper.Map<List<PostDto>>(posts))
            {
                meta = pagginationData
            };
            return Ok(response);
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
