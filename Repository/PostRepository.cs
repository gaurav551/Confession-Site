using NepConfess.Data;
using NepConfess.GenericRepository;
using NepConfess.Models;

namespace NepConfess.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}