using DeliverService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DeliverService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientsListController : ControllerBase
    {
        private readonly ILogger<ClientsListController> _logger;
        private readonly IFreeSql _fsql;
        public ClientsListController(ILogger<ClientsListController> logger, IFreeSql fsql)
        {
            _logger = logger;
            _fsql = fsql;
        }

        /// <summary>
        /// 分表查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
         public Object GetList(string listname)
        {
            // 表名MessageList_XXX
            var Listname = listname;

            var blogs = _fsql.Select<MessageList>()
                        .AsTable((type,name)=> $"{Listname}")
                        .Count(out var TotalCount)
                        .Page(1,10) //第100行-110行的记录
                        .ToList();
            return blogs;
        
        }

        [HttpGet]
        public Object GetCustormersList()
        {
            // 表名MessageList_XXX
            //var Listname = listname;

            var blogs = _fsql.Select<Custormers>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }

        /// <summary>
        /// 分表插入数据
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="number">编号</param>
        /// <returns></returns>
        [HttpPost]
        public Object InsertPost(string name, string id,string tablename)
        {
            var Tablename = tablename;
            ///分表
            var repo = _fsql.GetRepository<MessageList> ();
            repo.AsTable(oldname => $"{Tablename}");

            var item = new MessageList()
            {
                Name = name,
                Id = id
            };
            //插入数据
            var result = repo.Insert(item);
            item.Name = name;
            return result;
        }

        /// <summary>
        /// 分表删除数据
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        [HttpDelete]
        public object DelectClients( string id, string tablename)
        {
            var TableName = tablename;
            var result = _fsql.Select<MessageList>()
                .AsTable((type,oldname )=>$"{TableName}")
                .Where(a => a.Id == id)
                .ToDelete()
                .ExecuteAffrows(); ;
            return result;
        }

        /// <summary>
        /// 客户列表数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetClientsListCount(string tablename)
        {
            var TableName = tablename;
            var result = _fsql.Select<MessageList>()
                .AsTable((type, oldname) => $"{TableName}")
                .Count();
            return result;
        }



      
    }
}
