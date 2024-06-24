using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Views.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public Guid PublisherId { get; set; }

        [DisplayName("Название")]
        public string name { get; set; }

        [DisplayName("Кол-во страниц")]
        public int count_Page { get; set; }

        [DisplayName("Автор")]
        public string author_name { get; set; }

        [DisplayName("Жанр")]
        public string genre_name { get; set; }

        [DisplayName("Издательство")]
        public string publisher_name { get; set; }
    }
}
