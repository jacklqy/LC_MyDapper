using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.AspNetCore.Redis.Interface;
using Zhaoxi.AspNetCore.Redis.Service;

namespace Zhaoxi.AspNetCore.Redis
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class CacheInterceptor : IInterceptor
    {
        private readonly IRedisStringService _redisStringService = null;

        public CacheInterceptor(IRedisStringService redisStringService)
        {
            _redisStringService = redisStringService;
        }

        public void Intercept(IInvocation invocation)
        {
            {
                //在这里就判断一下是否有缓存
                string key = invocation.Method.Name;
                string strResult = _redisStringService.Get(key);
                if (strResult == null)
                {
                    invocation.Proceed(); //要去执行的动作
                    _redisStringService.Set(key, invocation.ReturnValue.ToString());
                }
                else
                {
                    invocation.ReturnValue = strResult;
                }
            }
        }
    }
}
