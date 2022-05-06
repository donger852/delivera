using DeliverService.Helper;
using DeliverService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DeliverService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FreeSqlListController : ControllerBase
    {
        private readonly ILogger<FreeSqlListController> _logger;
        private readonly IFreeSql _fsql;
        public FreeSqlListController(ILogger<FreeSqlListController> logger, IFreeSql fsql)
        {
            _logger = logger;
            _fsql = fsql;
        }
        #region 客户
        /// <summary>
        /// 客户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetCustormersList()
        {
            var blogs = _fsql.Select<Custormers>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 客户表总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetClientsListCount()
        {

            var result = _fsql.Select<Custormers>()
                .Count();
            return result;
        }

        #endregion
        #region 库位

        /// <summary>
        /// 库位列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetLocationList()
        {


            var blogs = _fsql.Select<Location>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 库位表总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetLocationCount()
        {

            var result = _fsql.Select<Location>()
                .Count();
            return result;
        }

        #endregion
        #region 仓库
        /// <summary>
        /// 仓库列表
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public Object GetStoreList()
        {


            var blogs = _fsql.Select<Store>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 仓库列表总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetStoreCount()
        {

            var result = _fsql.Select<Store>()
                .Count();
            return result;
        }
        #endregion
        #region 产品
        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public Object GetProductList()
        {

            var blogs = _fsql.Select<Product>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 产品列表总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetProductCount()
        {

            var result = _fsql.Select<Product>()
                .Count();
            return result;
        }
        #endregion
        #region 快递

        /// <summary>
        /// 快递列表
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public Object GetExpressList()
        {

            var blogs = _fsql.Select<Express>()
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 快递列表总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetExpressCount()
        {

            var result = _fsql.Select<Express>()
                .Count();
            return result;
        }

        #endregion
        #region 发货单

        /// <summary>
        /// 发货单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetGoodsList()
        {

            var blogs = _fsql.Select<Goods>()
                        .Where(a => a.TypeName == "正常入库")
                        .Count(out var TotalCount)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 商品总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetGoodsCount()
        {

            var result = _fsql.Select<Goods>()
                .Count();
            return result;
        }



        [HttpPost]
        public Object InsertGoods([FromBody] Goods goods)
        {

            var repo = _fsql.GetRepository<Goods>();
            //var item = new Goods()
            //{
            //    GoodsId = GoodsId,
            //    CustormerId = CustormerId,
            //    CreateTime = CreateTime,
            //};
            var result = repo.Insert(goods);
            //item.GoodsId = GoodsId;
            return result;

        }

        #endregion

        #region
        /// <summary>
        /// 正常入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetNormal_WarehousingList()
        {


            var blogs = _fsql.Select<Code, Goods>()
                        .LeftJoin((a, b) => a.GoodsId == b.GoodsId)
                        .LeftJoin((a, b) => a.Location.Id == a.LocationId)
                        .Where((a, b) => b.TypeName == "正常入库")
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 不入库直接发货
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetNoDeleveryList()
        {


            var blogs = _fsql.Select<Code, Goods>()
                        .LeftJoin((a, b) => a.GoodsId == b.GoodsId)
                        .LeftJoin((a, b) => a.Location.Id == a.LocationId)
                        .Where((a, b) => b.TypeName == "不入库直接发货")
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        /// <summary>
        /// 已入库产品发货
        /// </summary>
        /// <param name="normal_warehousing"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public Object GetDirectDeleveryList()
        {


            var blogs = _fsql.Select<Code, Goods>()
                        .LeftJoin((a, b) => a.GoodsId == b.GoodsId)
                        .LeftJoin((a, b) => a.Location.Id == a.LocationId)
                        .Where((a, b) => b.TypeName == "已入库产品发货")
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }

        /// <summary>
        /// 退货入库列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetReturnWarehousingList()
        {


            var blogs = _fsql.Select<Code, Goods>()
                        .LeftJoin((a, b) => a.GoodsId == b.GoodsId)
                        .LeftJoin((a, b) => a.Location.Id == a.LocationId)
                        .Where((a, b) => b.TypeName == "退货入库")
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }
        #endregion

        #region Code
        /// <summary>
        /// 新增条码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>

        [HttpPost]
        public Object InsertCode([FromBody] Code code)
        {

            var repo = _fsql.GetRepository<Code>();

            var result = repo.Insert(code);
            return result;

        }

        /// <summary>
        /// 查看条码列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Object GetCodeList()
        {


            var blogs = _fsql.Select<Code>()
                        .LeftJoin(a => a.Goods.GoodsId == a.GoodsId)
                        .LeftJoin(a => a.Location.Id == a.LocationId)
                        .LeftJoin(a => a.Product.Id == a.ProductId)
                        .LeftJoin(a => a.Custormers.Id == a.Goods.CustormerId)
                        .LeftJoin(a => a.Custormers.Id == a.Custormers.Id)
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;
        }

        /// <summary>
        /// 产看指定GoosId条码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public Object PostCodeGoodidList([FromBody] Code code)
        {

            var blogs = _fsql.Select<Code>()
                        .LeftJoin(a => a.Goods.GoodsId == a.GoodsId)
                        .LeftJoin(a => a.Product.Id == a.ProductId)
                        .Where(a => a.GoodsId == code.GoodsId)
                        .ToList();
            return blogs;
        }
        /// <summary>
        /// 查看指定GoodsId 的code列表数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object GetGoodsIdCodeCount([FromBody] Code code)
        {
            var result = _fsql.Select<Code>()
                        .LeftJoin(a => a.Goods.GoodsId == a.GoodsId)
                        .Where(a => a.GoodsId == code.GoodsId)
                        .Count();
            return result;
        }

        #endregion

        #region
        [HttpGet]
        public Object GetTypeList()
        {
            var blogs = _fsql.Select<TypeList>()
                        .Page(1, 10) //第100行-110行的记录
                        .ToList();
            return blogs;

        }



        #endregion

        #region
        [HttpPost]
        public Object GenTonkenjson([FromBody] TokenInfo user) {
            var repo = _fsql.GetRepository<TokenInfo>();
            var result = repo.Insert(user);
            string tokenjson = TokenHelper.GenToken(result);

            string token = this.HttpContext.Request.Headers[tokenjson];
            return tokenjson;
        }
        #endregion

        [HttpPost]
        public Object Login([FromBody] TokenInfo user)
        {
            var repo = _fsql.GetRepository<TokenInfo>();
            string token = this.HttpContext.Request.Headers["tokenjson"];
            return token;
        }

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Object CreateUser([FromBody] UserInfo user)
        {
            var repo = _fsql.GetRepository<UserInfo>();

            var result = repo.Insert(user);
            return result;
        }
        /// <summary>
        /// g更新用户登录状态，0：未登录，1：绑定，2：正在登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Object SetUserType(UserInfo user)
        {
            var repo = _fsql.Update<UserInfo>()
                .Where(a => a.UserName == user.UserName)
                .Set(a => a.LoginType, user.LoginType)
                .ExecuteAffrows();

            return repo;
        }

        [HttpGet]
        public Object SelectLoginUser()
        {
            var repo = _fsql.Select<UserInfo>()
                .Where(a => a.LoginType >0)
                .ToList();

            return repo;
        }
        /// <summary>
        /// 用户验证
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Url"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpGet]
        public Object GetSelectUser(string UserName, string Url, string Password) {

            var repo = _fsql.Select<UserInfo>().Where(a => a.UserName == UserName).Where(a => a.Url == Url).Where(a => a.Password == Password).Any();

            return repo;
        }




        /// <summary>
        /// 查找条码是否已入库
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public Object SetCodeIdInOnStock(Code code) {
            var repo = _fsql.Select<Code>()
                .Where(a => a.CodeId == code.CodeId).Any();
            return repo;
        }

        /// <summary>
        /// 更新条码对应单号
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public Object SetCodeIdInUpdate(Code code)
        {
            var repo = _fsql.Update<Code>()
                .Where(a => a.CodeId == code.CodeId)
                .Set(a => a.GoodsId, code.GoodsId)
                .Set(a => a.CustormerId, code.CustormerId)
                .Set(a => a.LocationId, code.LocationId)
                .ExecuteAffrows();
            
            return repo;
        }

        /// <summary>
        ///CodeId是否不入库直接发货
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public Object SelectCodeIdUnStorgeUpdate(Code code)
        {
            var repo = _fsql.Select<Code>()
                .Where(a => a.CodeId == code.CodeId)
                .Where(a => a.Goods.TypeName == "不入库直接发货")
                .Any();
            return repo;
        }
        /// <summary>
        /// CodeId是否已入库产品发货
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public Object SelectCodeIdOnStockUpdate(Code code)
        {
            var repo = _fsql.Select<Code>()
                .Where(a => a.CodeId == code.CodeId)
                .Where(a => a.Goods.TypeName == "已入库产品发货")
                .Any();
            return repo;
        }
    }
}
