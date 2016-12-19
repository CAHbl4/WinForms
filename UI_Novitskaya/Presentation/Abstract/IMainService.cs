using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Abstract
{
    public interface IMainService
    {
        IEnumerable<string> GetSurnames();
        IEnumerable<string> GetNames();

        IEnumerable<double> GetHeidhts();
        IEnumerable<int> GetBalls();


    }
}
