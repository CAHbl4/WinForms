using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Students { get; }
    }
}
