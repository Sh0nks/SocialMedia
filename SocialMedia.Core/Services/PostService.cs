using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Core.Collections;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Services
{
    public class PostService: IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedList<Post> GetPosts(PostQueryFilter filters)
        {
            
            IEnumerable<Post> posts = _unitOfWork.PostRepository.GetAll();
            if (filters.UserId != null)
            {
                posts = posts.Where(post => post.UserId == filters.UserId);
            }

            if (filters.Date != null)
            {
                posts = posts.Where(post => post.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                posts = posts.Where(posts => posts.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            return PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);
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

            IEnumerable<Post> posts = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (posts.Count() < 10)
            {
                Post lastPost = posts.LastOrDefault();
                int daysLapsed = (int)((DateTime.Now - lastPost.Date).TotalDays);
                if (daysLapsed < 7)
                {
                   throw new BussinesExecption("You are not able to publish a post yet");
                }
            }
            if (post.Description.Contains("Sexo"))
            {
                throw new BussinesExecption("Inapropiedted content");
            }
            await _unitOfWork.PostRepository.Create(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }
    }
}