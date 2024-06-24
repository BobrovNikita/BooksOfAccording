using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Book
    {
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Имя обязательное поле")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 50 символов")]
        public string Name { get; set; }

        public int Count_Page { get; set; }

        [Required(ErrorMessage = "Автор это обязательное поле")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Жанр это обязательное поле")]
        public Guid GenreId { get; set; }

        [Required(ErrorMessage = "Издательство это обязательное поле")]
        public Guid PublisherId { get; set; }


        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
    }
}
