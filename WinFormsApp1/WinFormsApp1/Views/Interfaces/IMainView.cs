using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Views.Interfaces
{
    public interface IMainView
    {
        event EventHandler LoadAutor;
        event EventHandler LoadGenre;
        event EventHandler LoadPublisher;
        event EventHandler LoadBook;
    }
}
