using WebAPIDemos.Controllers.Data.Models;
using WebAPIDemos.Controllers.Data.ViewModels;

namespace WebAPIDemos.Controllers.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVm publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
