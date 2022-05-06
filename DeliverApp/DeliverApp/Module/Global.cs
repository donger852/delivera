using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    /// <summary>
    /// 全部列表
    /// </summary>
    public class Global
    {
        /// <summary>
        /// 服务地址
        /// </summary>
        public static string Url { get; set; }

        /// <summary>
        /// 登录验证接口
        /// </summary>
        public static string PostSelectUser = "/api/FreeSqlList/GetSelectUser";
        /// <summary>
        /// 更改用户登录状态
        /// </summary>
        public static string SetUserType = "/api/FreeSqlList/SetUserType";
        /// <summary>
        /// 查找登录和绑定的用户列表
        /// </summary>
        public static string SelectLoginUser = "/api/FreeSqlList/SelectLoginUser";

        /// <summary>
        /// 客户列表
        /// </summary>
        public static string GetCustormersList = "/api/FreeSqlList/GetCustormersList";
        /// <summary>
        /// 仓库列表
        /// </summary>
        public static string GetStoreList = "/api/FreeSqlList/GetStoreList";

        /// <summary>
        /// 库位列表
        /// </summary>
        public static string GetLocationList = "/api/FreeSqlList/GetLocationList";
        /// <summary>
        /// 产品列表
        /// </summary>
        public static string GetProductList = "/api/FreeSqlList/GetProductList";
        /// <summary>
        /// 快递列表
        /// </summary>
        public static string GetExpressList = "/api/FreeSqlList/GetExpressList";
        /// <summary>
        /// 生成单号
        /// </summary>
        public static string InsertGoods = "/api/FreeSqlList/InsertGoods";


        /// <summary>
        /// 导入条码
        /// </summary>
        public static string InsertCode = "/api/FreeSqlList/InsertCode";
        /// <summary>
        /// 由Goodid获取code列表
        /// </summary>
        public static string PostCodeGoodidList = "/api/FreeSqlList/PostCodeGoodidList";
        /// <summary>
        /// 由Goodid获取code列表总数
        /// </summary>
        public static string GetGoodsIdCodeCount = "/api/FreeSqlList/GetGoodsIdCodeCount";

        /// <summary>
        /// 更新条码中的goodid
        /// </summary>
        public static string SetCodeIdInUpdate = "/api/FreeSqlList/SetCodeIdInUpdate";
        /// <summary>
        /// 是否不入库直接发货
        /// </summary>
        public static string SelectCodeIdUnStorgeUpdate = "/api/FreeSqlList/SelectCodeIdUnStorgeUpdate";
        /// <summary>
        /// 是否已入库产品发货
        /// </summary>
        public static string SelectCodeIdOnStockUpdate = "/api/FreeSqlList/SelectCodeIdOnStockUpdate";
    }
}
