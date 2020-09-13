using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PostService: IPostService    
    {
        private readonly IRepository<Post> _repository;
        private readonly IRepository<User> _userRepository;

        public PostService(IRepository<Post> repository, IRepository<User> userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _repository.GetAll();
        }

        public async Task<Post> Get(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(Post post)
        {
            User user = await _userRepository.GetById(post.UserId);
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
            await _repository.Update(post);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _repository.Delete(id);
            return true;
        }
    }
}