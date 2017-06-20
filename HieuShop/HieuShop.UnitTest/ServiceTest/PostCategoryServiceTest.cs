using HieuShop.Data.Infrastructure;
using HieuShop.Data.Repositories;
using HieuShop.Models.Models;
using HieuShop.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace HieuShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitofWork> _mockUnitOfWork;
        private IPostCategoryServices _categoryServices;
        private List<PostCategory> listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitofWork>();
            _categoryServices = new PostCategoryServices(_mockRepository.Object, _mockUnitOfWork.Object);
            listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID = 1, Name = "Test1",Status = true },
                new PostCategory() {ID = 2, Name = "Test2",Status = true },
                new PostCategory() {ID = 3, Name = "Test3",Status = true }
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(listCategory);

            //call action
            var result = _categoryServices.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}