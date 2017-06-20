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
    public interface IPostCategoryServices
    {
        void Add(PostCategory postcategory);
        void Update(PostCategory postcategory);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(int parentID);
        PostCategory GetById(int id);
        void SaveChanges();
    }
    public class PostCategoryServices : IPostCategoryServices
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitofWork _unitOfWork;
        public PostCategoryServices(IPostCategoryRepository postCategoryRepository
            , IUnitofWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(PostCategory postcateogry)
        {
            _postCategoryRepository.Add(postcateogry);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentID)
        {
            return _postCategoryRepository.GetMulti(x => x.ParentID == parentID && x.Status == true);
        }       

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postcategory)
        {
            _postCategoryRepository.Update(postcategory);
        }
    }
}
