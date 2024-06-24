using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Publisher
    {
        public Guid PublisherId { get; set; }

        [Required(ErrorMessage = "Имя обязательное поле")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 50 символов")]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
