using HieuShop.Models.Models;
using HieuShop.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HieuShop.WebApp.Infrastructure.Core
{
    public class APIControllerBase : ApiController
    {
        private IErrorLogServices _errorLogService;
        public APIControllerBase(IErrorLogServices errorLogService)
        {
            _errorLogService = errorLogService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage,Func<HttpResponseMessage> func)
        {
            HttpResponseMessage res = null;
            try
            {
                res = func.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach(var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" is state \"{eve.Entry.State}\" has following validation errors:");
                    foreach(var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"-Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\" ");
                    }
                }
                LogError(ex);
                res = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch(DbUpdateException dbEx)
            {
                LogError(dbEx);
            }
            catch (Exception ex)
            {
                LogError(ex);
                res = requestMessage.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            return res;
        }

        private void LogError(Exception ex)
        {
            try
            {
                ErrorLog error = new ErrorLog();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorLogService.Add(error);
                _errorLogService.Save();
            }catch()
            {

            }
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}