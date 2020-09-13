using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PostService: IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> Get(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task Create(Post post)
        {
            User user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            if (post.Description.Contains("Sexo"))
            {
                throw new Exception("Inapropiedted content");
            }
            await _unitOfWork.PostRepository.Create(post);
        }

        public async Task<bool> Update(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}