using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int i);

        Task<Post> Create(Post post);
        Task<bool> Update(Post post);
        Task<bool> Delete(int id);
        
    }
}