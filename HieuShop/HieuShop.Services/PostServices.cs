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
    public interface IPostServices
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize,out int total);
        IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int total);
        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int total);
        Post GetById(int id);
        void SaveChanges();
    }
    public class PostServices : IPostServices
    {
        IPostRepository _postRepository;
        IUnitofWork _unitOfWork;
        public PostServices(IPostRepository postRepository,
            IUnitofWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] {"PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int categoryID, int page, int pageSize, out int total)
        {
            //return _postRepository.GetAllByCategory(categoryID, page, pageSize, out total);
            return _postRepository.GetMultiPaging(x=>x.PostCategoryID == categoryID && x.Status == true,out total,page,pageSize,new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int total)
        {
            //TODO: Need include tag in here
            //return _postRepository.GetMultiPaging(x=>x.Status == true, out total, page, pageSize);
            return _postRepository.GetAllByTag(tag, page, pageSize, out total);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int total)
        {
            return _postRepository.GetMultiPaging(x => x.Status == true, out total, page, pageSize); 
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleByID(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
