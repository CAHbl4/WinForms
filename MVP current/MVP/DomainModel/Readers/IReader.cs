using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Readers
{
   public interface IReader
    {
       IEnumerable<Student> Read(string fileName);
    }
}
