using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DomainModel.Readers
{
    public class ReaderFromCSV:IReader
    {
        public IEnumerable<Models.Student> Read(string fileName)
        {
            List<Student> students=new List<Student>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] temp = reader.ReadLine().Split(';');
                    students.Add(new Student { Surname = temp[0], Name = temp[1], Height = double.Parse(temp[2]), BallForOOP=int.Parse(temp[3]) });
                }
            }
            return students;
        }
    }
}
