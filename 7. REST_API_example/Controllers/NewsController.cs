using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using REST_API_example.Models;

namespace REST_API_example.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository _repository { get; }
        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<News> GetNews([FromHeader]bool isFake)
        {
            return _repository.GetAllNews(isFake);
        }
        [HttpPost]
        public void CreateNews(News news)
        {
            _repository.CreateNews(news);
        }
        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _repository.DeleteNews(id);
        }
        [HttpPut("{id}")]
        public void ModifyNews(int id, [FromBody]News news)
        {
            _repository.MoveNews(id, news);
        }
        [HttpPatch("{id}")]
        public void UpdateNews(int id, [FromBody] News news)
        {
            _repository.UpdateNews(id, news);
        }
    }
}