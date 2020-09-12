using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastruncture.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {

            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<Post> Create(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Update(Post post)
        {
            Post existentPost = await GetPost(post.Id);
            if (existentPost != null)
            {
                existentPost.Date = post.Date;
                existentPost.Image = post.Image;
                existentPost.Description = post.Description;
                _context.Posts.Update(existentPost);
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            Post post = await GetPost(id);
            _context.Posts.Remove(post);
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
        
    }
}