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
    public class PublisherController
    {
        private readonly IPublisherView _view;
        private readonly IMainView _mainView;
        private readonly IRepository<Publisher> _repository;

        private BindingSource _publisherBindingSource;

        private IEnumerable<Publisher>? _publishers;

        public PublisherController(IPublisherView view, IMainView mainView, IRepository<Publisher> repository)
        {
            _view = view;
            _mainView = mainView;
            _repository = repository;

            _publisherBindingSource = new BindingSource();

            view.SearchEvent += Search;
            view.AddNewEvent += Add;
            view.EditEvent += LoadSelectedToEdit;
            view.DeleteEvent += DeleteSelected;
            view.SaveEvent += Save;
            view.CancelEvent += CancelAction;

            LoadPublishers();

            view.SetPublisherBindingSource(_publisherBindingSource);

            _view.Show();
        }

        private void CleanViewFields()
        {
            _view.Id = Guid.Empty;
            _view.PName = string.Empty;
        }

        private void LoadPublishers()
        {
            _publishers = _repository.GetAll();
            _publisherBindingSource.DataSource = _publishers;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void Save(object? sender, EventArgs e)
        {
            var model = new Publisher();
            model.PublisherId = _view.Id;
            model.Name = _view.PName;
            try
            {
                if (_view.IsEdit)
                {
                    _repository.Update(model);
                    _view.Message = "Publisher edited successfuly";
                }
                else
                {
                    _repository.Create(model);
                    _view.Message = "Publisher added successfuly";
                }
                _view.IsSuccessful = true;
                LoadPublishers();
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
                var model = (Publisher)_publisherBindingSource.Current;

                _repository.Delete(model);
                _view.IsSuccessful = true;
                _view.Message = "Publisher deleted successfuly";
                LoadPublishers();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Publisher";
            }
        }

        private void LoadSelectedToEdit(object? sender, EventArgs e)
        {
            var model = (Publisher)_publisherBindingSource.Current;
            _view.Id = model.PublisherId;
            _view.PName = model.Name;
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
                _publishers = _repository.GetAllByValue(_view.searchValue);
            else
                _publishers = _repository.GetAll();

            _publisherBindingSource.DataSource = _publishers;
        }
    }
}
