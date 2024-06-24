using WinFormsApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public class PublisherRepository : BaseRepository, IRepository<Publisher>
    {
        public PublisherRepository(ApplicationContext context) : base(context)
        {
        }

        public void Create(Publisher model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Publishers.Add(model);
                context.SaveChanges();
            }
        }

        public void Delete(Publisher model)
        {
            using (var context = new ApplicationContext())
            {
                context.Publishers.Remove(model);
                context.SaveChanges();
            }
        }
        public IEnumerable<Publisher> GetAll()
        {
            using (var context = new ApplicationContext())
                return context.Publishers.ToList();
        }
        public IEnumerable<Publisher> GetAllByValue(string value)
        {
            return null;
        }

        public Publisher GetModel(Guid id)
        {
            using (var context = new ApplicationContext())
                return context.Publishers.First(p => p.PublisherId == id);
        }

        public void Update(Publisher model)
        {
            using (var context = new ApplicationContext())
            {
                new Common.ValidationModel().Validate(model);

                context.Publishers.Update(model);
                context.SaveChanges();
            }
        }
    }
}
