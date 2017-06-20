using HieuShop.Data.Infrastructure;
using HieuShop.Data.Repositories;
using HieuShop.Models.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory _dbFactory;
        IPostCategoryRepository _objRepository;
        IUnitofWork _unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _objRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitofWork(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory pc = new PostCategory();
            pc.Name = "Hot Tiin";
            pc.Status = true;
            pc.Alias = "hot-tiin";

            _objRepository.Add(pc);
            _unitOfWork.Commit();           

        }


    }
}
