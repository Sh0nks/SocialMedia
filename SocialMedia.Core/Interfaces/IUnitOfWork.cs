using System;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Post> PostRepository { get; } 
        IRepository<Comment> CommentRepository { get; }
        IRepository<User> UserRepository { get; }

        void Save();

        Task SaveChangesAsync();
    }
}