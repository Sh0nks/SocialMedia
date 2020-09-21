using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Collections;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task<Post> Get(int id);
        Task Create(Post post);
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);
    }
}