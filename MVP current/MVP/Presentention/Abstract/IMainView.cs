using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentention.Abstract
{
    public interface IMainView : IView
    {
        List<String> Surnames { get; set; }
        List<String> Names { get; set; }
        List<double> Heights { get; set; }
        List<int> Balls { get; set; }

        event Action Open;   //событие открытия,когда пользователь откроет файл
        void ShowAll();
    }

}
