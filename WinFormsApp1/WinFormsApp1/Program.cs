using WinFormsApp1.Controllers;
using WinFormsApp1.Views.Interfaces;
using WinFormsApp1.Views;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            IMainView view = new MainView();
            new MainController(view);
            Application.Run((Form)view);
        }
    }
}