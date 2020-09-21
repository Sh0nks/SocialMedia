using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        Task<Post> Get(int id);
        Task Create(Post post);
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);
    }
}