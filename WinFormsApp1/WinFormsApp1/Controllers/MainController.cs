using WinFormsApp1.Model;
using WinFormsApp1.Repositories;
using WinFormsApp1.Views;
using WinFormsApp1.Views.Interfaces;
using WinFormsApp1.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Controllers
{
    public class MainController
    {
        private readonly IMainView _mainView;

        public MainController(IMainView mainView)
        {
            _mainView = mainView;

            _mainView.LoadAutor += LoadAutor;
            _mainView.LoadGenre += LoadGenre;
            _mainView.LoadPublisher += LoadPublisher;
            _mainView.LoadBook += LoadBook;
        }

        private void LoadBook(object? sender, EventArgs e)
        {
            IBookView view = BookView.GetInstance((MainView)_mainView);
            IRepository<BookViewModel> repository = new BookRepository(new ApplicationContext());
            IRepository<Author> authorRepository = new AutorRepository(new ApplicationContext());
            IRepository<Genre> genreRepository = new GenreRepository(new ApplicationContext());
            IRepository<Publisher> publisherRepository = new PublisherRepository(new ApplicationContext());
            new BookController(view, _mainView ,repository, authorRepository, genreRepository, publisherRepository);
        }

        private void LoadPublisher(object? sender, EventArgs e)
        {
            IPublisherView view = PublisherView.GetInstance((MainView)_mainView);
            IRepository<Publisher> repository = new PublisherRepository(new ApplicationContext());
            new PublisherController(view, _mainView, repository);
        }

        private void LoadGenre(object? sender, EventArgs e)
        {
            IGenreView view = GenreView.GetInstance((MainView)_mainView);
            IRepository<Genre> repository = new GenreRepository(new ApplicationContext());
            new GenreController(view, _mainView, repository);
        }

        private void LoadAutor(object? sender, EventArgs e)
        {
            IAutorView view = AutorView.GetInstance((MainView)_mainView);
            IRepository<Author> repository = new AutorRepository(new ApplicationContext());
            new AutorController(view, _mainView, repository);
        }
    }
}
