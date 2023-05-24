using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;

namespace Akelny.DAL.Repo.ReviewRepo
{
    public class ReviewRepo : GenericRepo<Review>, IReviewRepo
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
