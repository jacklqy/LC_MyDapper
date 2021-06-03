
using Zhaoxi.AspNetCore.Interface;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Z.Dapper.Plus;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Options;
using Zhaoxi.AspNetCore.Interface.Extend;

namespace Zhaoxi.AspNetCore.Service
{
    public class BaseService : IBaseService
    {
        /// <summary>
        /// 字符串写死了
        /// 现在有多个数据库了；数据库的操作要根据业务需求来选择；
        /// 1.增删改---主库
        /// 2.查询--从库
        /// 、、
        /// </summary>
        //protected IDbConnection _Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;");



        //1. 应该有容器来创建IDbConnection
        //2. 创建的时候要根据业务需求来使用不同的字符串

        //1.如果注入IDbConnection 无法执行连接串、中间这一部分工作其实复杂；
        //2.最好能够把它抽取出来---甩出去---丢给第三方；


        protected IDbConnection _Connection = null;
        private ICustomConnectionFactory _Connectionfactory = null;

        public BaseService(ICustomConnectionFactory factory)
        { 
            _Connectionfactory = factory;
        }
         
        #region Insert
        public bool Insert<T>(T t) where T : class
        {
            ///为什么不在这里来呢？  可以。。。
            _Connection= _Connectionfactory.GetConnection(WriteAndRead.Write); 
            return _Connection.Insert<T>(t) > 0;
        }

        public bool Insert(string sql, DynamicParameters parameters)
        {
            _Connection = _Connectionfactory.GetConnection(WriteAndRead.Write);
            return _Connection.Execute(sql, parameters) > 0;
        }

        public IEnumerable<T> BulkInsert<T>(IEnumerable<T> ts)
        {
            DapperPlusActionSet<T> result = _Connection.BulkInsert(ts);
            return result.Current;
        }
        #endregion

        #region Delete
        

        public bool Delete<T>(int Id) where T : class
        {
            T t = _Connection.Get<T>(Id);
            return _Connection.Delete<T>(t);
        }

        public bool Delete(string sql, DynamicParameters parameters)
        {
            return _Connection.Execute(sql, parameters) > 0;
        }

        public void BulkDelete<T>(IEnumerable<T> list)
        {
            _Connection.BulkDelete<T>(list);
        }
        #endregion

        #region update

        public bool Update<T>(T t) where T : class
        {
            return _Connection.Update<T>(t);
        }

        public T BulkUpdate<T>(IEnumerable<T> list) where T : class
        {
            DapperPlusActionSet<T> result = _Connection.BulkUpdate<T>(list);
            return result.CurrentItem;
        }
        #endregion

        #region Get
        public T Get<T>(int Id) where T : class
        {
            //
            //if (//查询)
            //{
            //  var queyrconn=  new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;");
            //}
            _Connection = _Connectionfactory.GetConnection(WriteAndRead.Read);
            return _Connection.Get<T>(Id);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return _Connection.Query<T>(sql);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _Connection.GetAll<T>();
        } 
        #endregion

        /// <summary>
        /// 释放数据库连接
        /// </summary>
        public void Dispose()
        {
            if (_Connection != null)
            {
                _Connection.Close();
            }
        }
    }
}
