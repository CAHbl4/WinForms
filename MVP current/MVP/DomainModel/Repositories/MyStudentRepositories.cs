using DomainModel.Models;
using DomainModel.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public class MyStudentRepositories:IStudentRepository
    {
        List<Student> students;

        public MyStudentRepositories(IReader reader,string fileName)
        {
            students = reader.Read(fileName).ToList<Student>();
        }



        public IEnumerable<Student> Students
        {
            get { return students; }

            
        }
    }
}
