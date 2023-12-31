﻿using System.Linq;
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
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }
        public void DeletePublisherById(int id)
        {
            var _publisher=_context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher !=null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }

    }
}
