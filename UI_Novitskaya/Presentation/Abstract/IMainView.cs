using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Abstract
{
    public interface IMainView:IView
    {
        List<string> Surnames { get; set; }
        List<String> Names { get; set; }
        List<Double> Heights { get; set; }
        List<int> Balls { get; set; }
       //событие кот будет иницилизироваться когда польз будет открывать файл
        event Action Open;
        void ShowAll();
    }
}
