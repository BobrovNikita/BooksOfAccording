using WinFormsApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class GenreRepository : BaseRepository, IRepository<Genre>
    {
        public GenreRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(Genre model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Genres.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Genre model)
        {
            using (var context = new ApplicationContext())
            {
                context.Genres.Remove(model);
                context.SaveChanges();
            }
        }
        public IEnumerable<Genre> GetAll()
        {
            using (var context = new ApplicationContext())
                return context.Genres.ToList();
        }
        public IEnumerable<Genre> GetAllByValue(string value)
        {
            return null;
        }

        public Genre GetModel(Guid id)
        {
            using (var context = new ApplicationContext())
                return context.Genres.First(p => p.GenreId == id);
        }

        public void Update(Genre model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Genres.Update(model);
                context.SaveChanges();
            }
        }
    }
}
