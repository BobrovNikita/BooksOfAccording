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
    public class AutorController
    {
        private readonly IAutorView _view;
        private readonly IMainView _mainView;
        private readonly IRepository<Author> _repository;

        private BindingSource _authorBindingSource;

        private IEnumerable<Author>? _authors;

        public AutorController(IAutorView view, IMainView mainView, IRepository<Author> repository)
        {
            _view = view;
            _mainView = mainView;
            _repository = repository;

            _authorBindingSource = new BindingSource();

            view.SearchEvent += Search;
            view.AddNewEvent += Add;
            view.EditEvent += LoadSelectedToEdit;
            view.DeleteEvent += DeleteSelected;
            view.SaveEvent += Save;
            view.CancelEvent += CancelAction;

            LoadAuthor();

            view.SetAuthorBindingSource(_authorBindingSource);

            _view.Show();
        }

        private void CleanViewFields()
        {
            _view.Id = Guid.Empty;
            _view.AName = string.Empty;
        }

        private void LoadAuthor()
        {
            _authors = _repository.GetAll();
            _authorBindingSource.DataSource = _authors;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void Save(object? sender, EventArgs e)
        {
            var model = new Author();
            model.AuthorId = _view.Id;
            model.Name = _view.AName;
            try
            {
                if (_view.IsEdit)
                {
                    _repository.Update(model);
                    _view.Message = "Author edited successfuly";
                }
                else
                {
                    _repository.Create(model);
                    _view.Message = "Author added successfuly";
                }
                _view.IsSuccessful = true;
                LoadAuthor();
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
                var model = (Author)_authorBindingSource.Current;

                _repository.Delete(model);
                _view.IsSuccessful = true;
                _view.Message = "Autor deleted successfuly";
                LoadAuthor();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Autor";
            }
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var model = (Author)_authorBindingSource.Current;
            _view.Id = model.AuthorId;
            _view.AName = model.Name;
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
                _authors = _repository.GetAllByValue(_view.searchValue);
            else
                _authors = _repository.GetAll();

            _authorBindingSource.DataSource = _authors;
        }
    }
}
