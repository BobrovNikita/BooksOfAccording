using WinFormsApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Views.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Repositories
{
    public class BookRepository : BaseRepository, IRepository<BookViewModel>
    {
        public BookRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(BookViewModel model)
        {
            using (var context = new ApplicationContext())
            {
                var entity = ConvertToEntity(model);

                new Common.ValidationModel().Validate(entity);

                context.Books.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(BookViewModel model)
        {
            using (var context = new ApplicationContext())
            {
                var entity = ConvertToEntity(model);

                context.Books.Remove(entity);
                context.SaveChanges();
            }
        }
        public IEnumerable<BookViewModel> GetAll()
        {
            using (var context = new ApplicationContext())
            {
                var entities = context.Books.Include(g => g.Genre).Include(a => a.Author).Include(p => p.Publisher).ToList();
                var viewModels = new List<BookViewModel>();
                foreach (var e in entities)
                {
                    viewModels.Add(ConvertToViewModel((e)));
                }

                return viewModels;
            }
        }
        public IEnumerable<BookViewModel> GetAllByValue(string value)
        {
            var entities = _context.Books.Include(g => g.Genre)
                              .Include(a => a.Author)
                              .Include(p => p.Publisher)
                              .Where
                              (p => p.Name.Contains(value) ||
                               p.Genre.Name.Contains(value) ||
                               p.Author.Name.Contains(value) ||
                               p.Publisher.Name.Contains(value)
                              ).ToList();

            var viewModels = new List<BookViewModel>();

            foreach (var e in entities)
            {
                viewModels.Add(ConvertToViewModel((e)));
            }

            return viewModels;
        }

        public BookViewModel GetModel(Guid id)
        {
            var entity = _context.Books.Include(g => g.Genre).Include(a => a.Author).Include(p => p.Publisher).First(p => p.BookId == id);

            var viewModel = ConvertToViewModel(entity);

            return viewModel;
        }

        public void Update(BookViewModel model)
        {
            using (var context = new ApplicationContext())
            {
                var entity = ConvertToEntity(model);
                new Common.ValidationModel().Validate(entity);

                context.Books.Update(entity);
                context.SaveChanges();
            }
        }


        private Book ConvertToEntity(BookViewModel model)
        {
            var entity = new Book();
            entity.BookId = model.BookId;
            entity.AuthorId = model.AuthorId;
            entity.PublisherId = model.PublisherId;
            entity.GenreId = model.GenreId;
            entity.Name = model.name;
            entity.Count_Page = model.count_Page;

            return entity;
        }

        private BookViewModel ConvertToViewModel(Book model)
        {
            var viewModel = new BookViewModel();
            viewModel.BookId = model.BookId;
            viewModel.AuthorId = model.AuthorId;
            viewModel.GenreId = model.GenreId;
            viewModel.PublisherId = model.PublisherId;
            viewModel.name = model.Name;
            viewModel.count_Page = model.Count_Page;
            viewModel.author_name = model.Author.Name;
            viewModel.genre_name = model.Genre.Name;
            viewModel.publisher_name = model.Publisher.Name;

            return viewModel;
        }
    }
}
