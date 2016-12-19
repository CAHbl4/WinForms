using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentention.Abstract
{
    public interface IMainService
    {
        IEnumerable<String> GetSurname();
        IEnumerable<String> GetNames();
        IEnumerable<double> GetHeigth();
        IEnumerable<int> GetBalls();
    }
}
