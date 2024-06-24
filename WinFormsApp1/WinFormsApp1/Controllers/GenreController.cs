using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;
using WinFormsApp1.Repositories;
using WinFormsApp1.Views.Interfaces;

namespace WinFormsApp1.Controllers
{
    public class GenreController
    {
        private readonly IGenreView _view;
        private readonly IMainView _mainView;
        private readonly IRepository<Genre> _repository;

        private BindingSource _genreBindingSource;

        private IEnumerable<Genre>? _genres;

        public GenreController(IGenreView view, IMainView mainView, IRepository<Genre> repository)
        {
            _view = view;
            _mainView = mainView;
            _repository = repository;

            _genreBindingSource = new BindingSource();

            view.SearchEvent += Search;
            view.AddNewEvent += Add;
            view.EditEvent += LoadSelectedToEdit;
            view.DeleteEvent += DeleteSelected;
            view.SaveEvent += Save;
            view.CancelEvent += CancelAction;

            LoadGenre();

            view.SetGenreBindingSource(_genreBindingSource);

            _view.Show();
        }

        private void CleanViewFields()
        {
            _view.Id = Guid.Empty;
            _view.GName = string.Empty;
        }

        private void LoadGenre()
        {
            _genres = _repository.GetAll();
            _genreBindingSource.DataSource = _genres;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void Save(object? sender, EventArgs e)
        {
            var model = new Genre();
            model.GenreId = _view.Id;
            model.Name = _view.GName;
            try
            {
                if (_view.IsEdit)
                {
                    _repository.Update(model);
                    _view.Message = "Genre edited successfuly";
                }
                else
                {
                    _repository.Create(model);
                    _view.Message = "Genre added successfuly";
                }
                _view.IsSuccessful = true;
                LoadGenre();
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
                var model = (Genre)_genreBindingSource.Current;

                _repository.Delete(model);
                _view.IsSuccessful = true;
                _view.Message = "Genre deleted successfuly";
                LoadGenre();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Genre";
            }
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var model = (Genre)_genreBindingSource.Current;
            _view.Id = model.GenreId;
            _view.GName = model.Name;
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
                _genres = _repository.GetAllByValue(_view.searchValue);
            else
                _genres = _repository.GetAll();

            _genreBindingSource.DataSource = _genres;
        }
    }
}
