using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;
using DomainModel.Readers;

namespace DomainModel.Repositories
{
   public class MyStudentRepository:IStudentRepository
   {
       List<Student> students;

       public MyStudentRepository(IReader reader, string fileName)
       {
           students = reader.Read(fileName).ToList<Student>();
       }

       public IEnumerable<Student> Students
       {
           get { return students; }
       }
   }
}
