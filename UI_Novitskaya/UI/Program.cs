using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Abstract;
using Presentation.Presentors;
using Presentation.Service;

namespace UI
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
            //Application.Run(new Form1()); //заменяем на
            IPresenter presenter = new MainPresenter(new Form1(), new MainServises("students.csv"));
            presenter.Run();
        }
    }
}
