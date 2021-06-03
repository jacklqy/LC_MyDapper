using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Zhaoxi.AspNetCore.Interface.Extend
{
    public class CustomConnectionFactory : ICustomConnectionFactory
    {
        private DBConnectionOption _Options = null;

        private IDbConnection _Connection = null;

        private static int _iSeed = 0;
        private static bool _isSet = true;
        private static readonly object _ObjectisSet_Lock = new object();

        public CustomConnectionFactory(IDbConnection connection, IOptionsMonitor<DBConnectionOption> options)
        {
            _Connection = connection;
            _Options = options.CurrentValue;

            if (_isSet)
            {
                lock (_ObjectisSet_Lock)
                {
                    if (_isSet)
                    {
                        _iSeed = _Options.ReadConnectionList.Count; //应该保证  只有在CustomConnectionFactory 第一次初始化的时候，对其赋值；
                        _isSet = false;
                    }
                }
            }
        }


        public CustomConnectionFactory(IOptionsMonitor<DBConnectionOption> options, IDbConnection connection)
        {
            _Options = options.CurrentValue;
            _Connection = connection;
        }

        /// <summary>
        /// 根据不同的枚举  选择不同的字符串创建对象返回回去
        /// </summary>
        /// <param name="writeAndRead"></param>
        /// <returns></returns>
        public IDbConnection GetConnection(WriteAndRead writeAndRead)
        {
            switch (writeAndRead)
            {
                case WriteAndRead.Write:
                    _Connection.ConnectionString = _Options.WriteConnection; //增删改
                    break;
                case WriteAndRead.Read:  //如果来查询的时候，我们是不是可以在这里自由选择查询的数据库？
                    _Connection.ConnectionString = QuyerStrategy();//_Options.ReadConnectionList[0]; //增删改
                    break;
                default:
                    break;
            }
            return _Connection;
        }
        /// <summary>
        /// 选择策略
        /// </summary>
        /// <returns></returns>
        private string QuyerStrategy()
        {
            switch (_Options.Strategy)
            {
                case Strategy.Polling:
                    return Polling();
                case Strategy.Random:
                    return Random();
                default:
                    throw new Exception("分库查询策略不存在。。。");
            }
        }

        /// <summary>
        /// 随机策略
        /// </summary>
        /// <returns></returns>
        private string Random()
        {
            int Count = _Options.ReadConnectionList.Count;
            int index = new Random().Next(0, Count);
            return _Options.ReadConnectionList[index];
        }

        /*  private static int _iSeed = _Options.ReadConnectionList.Count;//3; //如果这个_iSeed 到达一定的量级以后，直接归零；*/

        /// <summary>
        /// 轮询
        /// </summary>
        /// <returns></returns>
        private string Polling()
        {
            return this._Options.ReadConnectionList[_iSeed++ % this._Options.ReadConnectionList.Count];//轮询;   
        }

    }
}
