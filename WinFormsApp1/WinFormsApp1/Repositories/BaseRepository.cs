using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositories
{
    public abstract class BaseRepository
    {
        protected ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
