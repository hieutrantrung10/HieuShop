using HieuShop.Data.Infrastructure;
using HieuShop.Data.Repositories;
using HieuShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Services
{
    public interface IErrorLogServices
    {
        void Add(ErrorLog err);
        void Save();
    }
    public class ErrorLogServices : IErrorLogServices
    {
        IErrorLogRepository _errorLogRepository;
        IUnitofWork _unitOfWork;
        public ErrorLogServices(IErrorLogRepository errorLogRepository,IUnitofWork unitOfWork)
        {
            _errorLogRepository = errorLogRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(ErrorLog err)
        {
            //throw new NotImplementedException();
            _errorLogRepository.Add(err);
        }        

        public void Save()
        {
            //throw new NotImplementedException();
            _unitOfWork.Commit();
        }
    }
}
