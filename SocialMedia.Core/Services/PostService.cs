using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PostService: IPostService    
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _repository.GetPosts();
        }

        public async Task<Post> Get(int id)
        {
            return await _repository.GetPost(id);
        }

        public async Task Create(Post post)
        {
            User user = await _userRepository.GetUser(post.UserId);
            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            if (post.Description.Contains("Sexo"))
            {
                throw new Exception("Inapropiedted content");
            }
            await _repository.Create(post);
        }

        public async Task<bool> Update(Post post)
        {
            return await _repository.Update(post);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}