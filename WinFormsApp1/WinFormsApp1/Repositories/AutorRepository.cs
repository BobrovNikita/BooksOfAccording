using WinFormsApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class AutorRepository : BaseRepository, IRepository<Author>
    {
        public AutorRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(Author model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Authors.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Author model)
        {
            using (var context = new ApplicationContext())
            {
                context.Authors.Remove(model);
                context.SaveChanges();
            }
        }
        public IEnumerable<Author> GetAll()
        {
            using (var context = new ApplicationContext())
                return context.Authors.ToList();
        }
        public IEnumerable<Author> GetAllByValue(string value)
        {
            return null;
        }

        public Author GetModel(Guid id)
        {
            using (var context = new ApplicationContext())
                return context.Authors.First(p => p.AuthorId == id);
        }

        public void Update(Author model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Authors.Update(model);
                context.SaveChanges();
            }
        }
    }
}
