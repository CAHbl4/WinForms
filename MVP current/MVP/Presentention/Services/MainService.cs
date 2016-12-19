
using DomainModel.Repositories;
using Presentention.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Readers;

namespace Presentention.Services
{
    public class MainService:IMainService
    {
        IStudentRepository repo;
        public MainService(string fileName)
        {
            repo = new MyStudentRepositories(new ReaderFromCsv(), fileName);
        }
        public IEnumerable<string> GetSurname()
        {
          return  repo.Students.Select(s=>s.Surname);
        }

        public IEnumerable<string> GetNames()
        {
            return repo.Students.Select(s => s.Name);
        }

        public IEnumerable<double> GetHeigth()
        {
            return repo.Students.Select(s => s.Height);
        }

        public IEnumerable<int> GetBalls()
        {
            return repo.Students.Select(s => s.BallForOOP);
        }
    }
}
