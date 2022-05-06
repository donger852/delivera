using DeliverApp.Module;

using DeliverApp.Module.TableLists;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeliverApp.Core
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
          //  _database.CreateTableAsync<ClientList>().Wait();
            _database.CreateTableAsync<StorList>().Wait();
        //    _database.CreateTableAsync<PlaceList>().Wait();
          //  _database.CreateTableAsync<ClientLists>().Wait();
         //   _database.CreateTableAsync<ProductList>().Wait();
            _database.CreateTableAsync<ExpressList>().Wait();
            //CompanyList
            _database.CreateTableAsync<CompanyList>().Wait();

        }

        #region 仓库表数据操作
        public Task<List<StorList>> GetStorListAsync()
        {
            return _database.Table<StorList>().ToListAsync();
        }

        public Task<int> GetStorListCountAsync()
        {
            return _database.Table<StorList>().CountAsync();
        }

        public Task<int> SaveStorListAsync(StorList storlist)
        {
            return _database.InsertAsync(storlist);
        }
        #endregion

        #region 库位表数据操作
        //public Task<List<PlaceList>> GetPlaceListAsync()
        //{
        //    return _database.Table<PlaceList>().ToListAsync();
        //}

        //public Task<int> SavePlaceListAsync(PlaceList placelist)
        //{
        //    return _database.InsertAsync(placelist);
        //}
        #endregion
        #region 客户表数据操作
        //public  Task<List<ClientLists>> GetClientListsAsync()
        //{
           
        //      return _database.Table<ClientLists>().ToListAsync();
        //}

        //public Task<int> GetClientListsCountAsync()
        //{
        //    return _database.Table<ClientLists>().CountAsync();
        //}
        //public Task<int> SaveClientListsAsync(ClientLists clientists)
        //{
        //    return _database.InsertAsync(clientists);
        //}
        #endregion

        #region  产品表数据操作
        //public Task<List<ProductList>> GetProductListAsync()
        //{
        //    return _database.Table<ProductList>().ToListAsync();
        //}
        //public Task<int> SaveProductListAsync(ProductList productlist)
        //{
        //    return _database.InsertAsync(productlist);
        //}
        #endregion


        #region 快递公司表操作
        public Task<List<ExpressList>> GetExpressListAsync()
        {
            return _database.Table<ExpressList>().ToListAsync();
        }
        public Task<int> SaveExpressListAsync(ExpressList expresslist)
        {
            return _database.InsertAsync(expresslist);
        }
        #endregion

        #region 公司

        #endregion
    }
}
