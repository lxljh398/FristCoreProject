using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionlessTest.Controllers
{
    /// <summary>
    /// SwaggerAPI测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        /// <summary>
        /// 获取方法
        /// </summary>
        /// <returns></returns>
        // GET: api/Swagger
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 通过ID获取
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        // GET: api/Swagger/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST方法
        /// </summary>
        /// <param name="value">值</param>
        // POST: api/Swagger
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="value">值</param>
        // PUT: api/Swagger/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">ID</param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
