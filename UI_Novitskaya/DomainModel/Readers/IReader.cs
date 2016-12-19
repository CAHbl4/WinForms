using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DomainModel.Readers
{
    public interface IReader
    {
        IEnumerable<Student> Read(string fileName);
    }
}
