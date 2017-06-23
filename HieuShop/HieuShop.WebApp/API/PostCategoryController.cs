using HieuShop.Models.Models;
using HieuShop.Services;
using HieuShop.WebApp.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HieuShop.WebApp.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : APIControllerBase
    {
        IPostCategoryServices _postCategoryServices;
        public PostCategoryController(IErrorLogServices errorLogServices, IPostCategoryServices postCategoryServices)
            : base(errorLogServices)
        {
            _postCategoryServices = postCategoryServices;
        }
        
        public HttpResponseMessage Post(HttpRequestMessage requestMessage,PostCategory postCategory)
        {
            return CreateHttpResponse(requestMessage, () =>
             {
                 HttpResponseMessage response = null;
                 if(ModelState.IsValid)
                 {
                     _postCategoryServices.Add(postCategory);
                     _postCategoryServices.SaveChanges();

                     response = requestMessage.CreateResponse(HttpStatusCode.Created, postCategory);
                 }
                 else
                 {
                     requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 return response;
             });
        }

        public HttpResponseMessage Put(HttpRequestMessage requestMessage, PostCategory postCategory)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    _postCategoryServices.Update(postCategory);
                    _postCategoryServices.SaveChanges();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK, postCategory);
                }
                else
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    _postCategoryServices.Delete(id);
                    _postCategoryServices.SaveChanges();

                    response = requestMessage.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var list = _postCategoryServices.GetAll();


                response = requestMessage.CreateResponse(HttpStatusCode.OK,list);
                }
                else
                {
                    requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

    }
}