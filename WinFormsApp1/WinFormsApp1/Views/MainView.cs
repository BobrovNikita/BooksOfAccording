using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Views.Interfaces;

namespace WinFormsApp1.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();

            InitializeBtnEvents();
        }

        private void InitializeBtnEvents()
        {
            AuthorBtn.Click += delegate { LoadAutor?.Invoke(this, EventArgs.Empty); };
            GenreBtn.Click += delegate { LoadGenre?.Invoke(this, EventArgs.Empty); };
            PublisherBtn.Click += delegate { LoadPublisher?.Invoke(this, EventArgs.Empty); };
            BookBtn.Click += delegate { LoadBook?.Invoke(this, EventArgs.Empty); };
            FormClosed += delegate { Application.Exit(); };
        }

        public event EventHandler LoadAutor;
        public event EventHandler LoadGenre;
        public event EventHandler LoadPublisher;
        public event EventHandler LoadBook;
    }
}
