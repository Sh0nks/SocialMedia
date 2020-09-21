using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastruncture.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository: BaseRepository<Post>, IPostRepository
    {
        public PostRepository(SocialMediaContext context) : base(context)
        {}

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            return await _entities.Where(post => post.UserId == userId).ToListAsync();
        }
    }
}