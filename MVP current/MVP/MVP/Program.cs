using Presentention.Abstract;
using Presentention.Presenters;
using Presentention.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IPresenter presenter = new MainPresenter(new Form1(), new MainService("students.csv"));
            presenter.Run();
        }
    }
}
