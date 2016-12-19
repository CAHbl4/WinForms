using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class RandomMultiGenrator:IGenerator
    {
        int min, max;
        int x, y;
        Random r = new Random();
        public RandomMultiGenrator(int min=1,int max=10)
        {
            this.min = min;
            this.max = max;
        }
        public string GetQuestion()
        {
            
             x = r.Next(min, max);
             y = r.Next(min, max);
            return x + " x " + y + " = ";
        }

        public string GetCorrectAnswer()
        {
            return (x*y).ToString();
        }


        public List<string> GetAllAnswers()
        {
            List<string> result=new List<string>();
            for (int i = min; i <=max; i++)
            {
                for (int j = min; j <= max; j++)
                {
                    string temp = i + " x " + j + " = " + (i * j);
                    result.Add(temp);
                }
            }
            return result;
        }
    }
}
