using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Models;

namespace DomainModel.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Students { get; }
    }
}
