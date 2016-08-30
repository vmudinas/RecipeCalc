using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;

namespace Core.Service
{
    public class DataService :IDataService
    {
        private readonly IDataRepository _dataRepository;
        public DataService(IDataRepository repo)
        {
            _dataRepository = repo;
        }


        public RecipeTotals GetAllRecipies()
        {
            return _dataRepository.GetAllRecipies();
        }

    }
}
