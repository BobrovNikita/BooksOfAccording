using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;
using WinFormsApp1.Repositories;
using WinFormsApp1.Views.Interfaces;
using WinFormsApp1.Views.ViewModels;

namespace WinFormsApp1.Controllers
{
    public class BookController
    {
        private readonly IBookView _view;
        private readonly IMainView _mainView;
        private readonly IRepository<BookViewModel> _repository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Publisher> _publisherRepository;

        private BindingSource bookBindingSource;
        private BindingSource authorBindingSource;
        private BindingSource genreBindingSource;
        private BindingSource publisherBindingSource;

        private IEnumerable<BookViewModel>? _book;
        private IEnumerable<Author>? _author;
        private IEnumerable<Genre>? _genre;
        private IEnumerable<Publisher>? _publisher;

        public BookController(IBookView view, IMainView mainView, IRepository<BookViewModel> repository, IRepository<Author> authorRepository, IRepository<Genre> genreRepository, IRepository<Publisher> publisherRepository)
        {
            _view = view;
            _mainView = mainView;
            _repository = repository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _publisherRepository = publisherRepository;

            bookBindingSource = new BindingSource();
            authorBindingSource = new BindingSource();
            genreBindingSource= new BindingSource();
            publisherBindingSource = new BindingSource();

            view.SearchEvent += Search;
            view.AddNewEvent += Add;
            view.EditEvent += LoadSelectedToEdit;
            view.DeleteEvent += DeleteSelected;
            view.SaveEvent += Save;
            view.CancelEvent += CancelAction;

            LoadBooks();
            LoadCombobox();

            view.SetBookBindingSource(bookBindingSource);
            view.SetAuthorBindingSource(authorBindingSource);
            view.SetGenreBindingSource(genreBindingSource);
            view.SetPublisherBindingSource(publisherBindingSource);

            _view.Show();

        }

        private void LoadBooks()
        {
            _book = _repository.GetAll();
            bookBindingSource.DataSource = _book;
        }

        private void LoadCombobox()
        {
            _author = _authorRepository.GetAll();
            authorBindingSource.DataSource = _author;

            _genre = _genreRepository.GetAll();
            genreBindingSource.DataSource = _genre;

            _publisher = _publisherRepository.GetAll();
            publisherBindingSource.DataSource = _publisher;
        }

        private void CleanViewFields()
        {
            _view.Id = Guid.Empty;
            _view.AuthorId = new Author();
            _view.GenreId= new Genre();
            _view.PublisherId = new Publisher();
            _view.Bname = string.Empty;
            _view.count_Page = -1;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void Save(object? sender, EventArgs e)
        {
            if (_view.AuthorId == null || _view.GenreId == null || _view.PublisherId == null)
            {
                CleanViewFields();
                _view.Message = "Нет значения в выпадающем списке";
                return;
            }

            var model = new BookViewModel();
            model.BookId = _view.Id;
            model.AuthorId = _view.AuthorId.AuthorId;
            model.GenreId = _view.GenreId.GenreId;
            model.PublisherId = _view.PublisherId.PublisherId;
            model.name = _view.Bname;
            model.count_Page = _view.count_Page;

            try
            {
                if (_view.IsEdit)
                {
                    _repository.Update(model);
                    _view.Message = "Book edited successfuly";
                }
                else
                {
                    _repository.Create(model);
                    _view.Message = "Book added successfuly";
                }
                _view.IsSuccessful = true;
                LoadBooks();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        private void DeleteSelected(object? sender, EventArgs e)
        {
            try
            {
                var model = (BookViewModel)bookBindingSource.Current;
                if (model == null)
                {
                    throw new Exception();
                }
                _repository.Delete(model);
                _view.IsSuccessful = true;
                _view.Message = "Book deleted successfuly";
                LoadBooks();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Book";
            }
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var model = (BookViewModel)bookBindingSource.Current;
            _view.Id = model.BookId;
            _view.AuthorId.AuthorId = model.AuthorId;
            _view.GenreId.GenreId = model.GenreId;
            _view.PublisherId.PublisherId = model.PublisherId;
            _view.Bname = model.name;
            _view.count_Page = model.count_Page;
            _view.IsEdit = true;
        }

        private void Add(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = String.IsNullOrWhiteSpace(_view.searchValue);

            if (emptyValue == false)
                _book = _repository.GetAllByValue(_view.searchValue);
            else
                _book = _repository.GetAll();

            bookBindingSource.DataSource = _book;
        }
    }
}
