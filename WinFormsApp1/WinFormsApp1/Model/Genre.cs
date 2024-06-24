using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Genre
    {
        public Guid GenreId { get; set; }

        [Required(ErrorMessage = "Название жанра обязательное поле")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Название жанра должно содержать от 3 до 50 символов")]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
