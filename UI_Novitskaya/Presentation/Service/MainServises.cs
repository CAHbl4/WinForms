using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Readers;
using DomainModel.Repositories;
using Presentation.Abstract;

namespace Presentation.Service
{
    public class MainServises:IMainService
    {
        IStudentRepository repo;

        public MainServises(string fileName)
        {
            repo = new MyStudentRepository(new ReaderFromCSV(), fileName);
        }
        public IEnumerable<string> GetSurnames()
        {
            return repo.Students.Select(s => s.Surname);
        }

        public IEnumerable<string> GetNames()
        {
            return repo.Students.Select(s => s.Name);
        }

        public IEnumerable<double> GetHeidhts()
        {
            return repo.Students.Select(s => s.Height);
        }

        public IEnumerable<int> GetBalls()
        {
            return repo.Students.Select(s => s.BallForOOP);
        }
    }
}
