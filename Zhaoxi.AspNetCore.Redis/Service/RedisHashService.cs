using Zhaoxi.AspNetCore.Redis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.AspNetCore.Redis.Service
{
    /// <summary>
    ///
    /// </summary>
    public class RedisHashService : RedisBase, IRedisHashService
    {
        #region 添加
        /// <summary>
        /// 向hashid集合中添加key/value
        /// </summary>       
        public bool SetEntryInHash(string hashid, string key, string value)
        {
            return base.iClient.SetEntryInHash(hashid, key, value);
        }
        /// <summary>
        /// 如果hashid集合中存在key/value则不添加返回false，
        /// 如果不存在在添加key/value,返回true
        /// 
        /// //
        /// </summary>
        public bool SetEntryInHashIfNotExists(string hashid, string key, string value)
        {
            return base.iClient.SetEntryInHashIfNotExists(hashid, key, value);
        }
        /// <summary>
        /// 存储对象T t到hash集合中
        /// 需要包含Id，然后用Id获取
        /// 存入的对象必须有一个Id
        /// </summary>
        public void StoreAsHash<T>(T t)
        {
            base.iClient.StoreAsHash<T>(t);
        }
        #endregion

        #region 获取
        /// <summary>
        /// 获取对象T中ID为id的数据。
        /// </summary>
        public T GetFromHash<T>(object id)
        {
            return base.iClient.GetFromHash<T>(id);
        }
        /// <summary>
        /// 获取所有hashid数据集的key/value数据集合
        /// </summary>
        public Dictionary<string, string> GetAllEntriesFromHash(string hashid)
        {
            return base.iClient.GetAllEntriesFromHash(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中的数据总数
        /// </summary>
        public long GetHashCount(string hashid)
        {
            return base.iClient.GetHashCount(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中所有key的集合
        /// </summary>
        public List<string> GetHashKeys(string hashid)
        {
            return base.iClient.GetHashKeys(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中的所有value集合
        /// </summary>
        public List<string> GetHashValues(string hashid)
        {
            return base.iClient.GetHashValues(hashid);
        }
        /// <summary>
        /// 获取hashid数据集中，key的value数据
        /// </summary>
        public string GetValueFromHash(string hashid, string key)
        {
            return base.iClient.GetValueFromHash(hashid, key);
        }
        /// <summary>
        /// 获取hashid数据集中，多个keys的value集合
        /// </summary>
        public List<string> GetValuesFromHash(string hashid, string[] keys)
        {
            return base.iClient.GetValuesFromHash(hashid, keys);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除hashid数据集中的key数据
        /// </summary>
        public bool RemoveEntryFromHash(string hashid, string key)
        {
            return base.iClient.RemoveEntryFromHash(hashid, key);
        }
        #endregion

        #region 其它
        /// <summary>
        /// 判断hashid数据集中是否存在key的数据
        /// </summary>
        public bool HashContainsEntry(string hashid, string key)
        {
            return base.iClient.HashContainsEntry(hashid, key);
        }
        /// <summary>
        /// 给hashid数据集key的value加countby，返回相加后的数据
        /// </summary>
        public double IncrementValueInHash(string hashid, string key, double countBy)
        {
            return base.iClient.IncrementValueInHash(hashid, key, countBy);
        }
        #endregion
    }
}
