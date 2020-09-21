using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastruncture.Data;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly SocialMediaContext _context;

        private readonly IPostRepository _postRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<User> _userRepository;
        

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
            _postRepository =new PostRepository(context);
            _commentRepository = new BaseRepository<Comment>(context);
            _userRepository = new BaseRepository<User>(context);
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public IPostRepository PostRepository => _postRepository;
        public IRepository<Comment> CommentRepository => _commentRepository;
        public IRepository<User> UserRepository => _userRepository;
        
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}