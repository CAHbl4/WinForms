using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public interface IGenerator
    {
        string GetQuestion();
        string GetCorrectAnswer();
        List<string> GetAllAnswers();
    }
}
