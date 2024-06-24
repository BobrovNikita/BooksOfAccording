using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;

namespace WinFormsApp1.Views.Interfaces
{
    public interface IBookView
    {
        Guid Id { get; set; }
        Author AuthorId { get; set; }
        Genre GenreId { get; set; }
        Publisher PublisherId { get; set; }

        string Bname { get; set; }
        int count_Page { get; set; }


        string searchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetAuthorBindingSource(BindingSource source);
        void SetGenreBindingSource(BindingSource source);
        void SetPublisherBindingSource(BindingSource source);
        void SetBookBindingSource(BindingSource source);
        void Show();

    }
}
