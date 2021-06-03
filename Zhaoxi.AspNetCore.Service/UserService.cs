using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Zhaoxi.AspNetCore.Interface;
using Zhaoxi.AspNetCore.Interface.Extend;
using Zhaoxi.AspNetCore.Redis;

namespace Zhaoxi.AspNetCore.Service
{

    [Intercept(typeof(CacheInterceptor))]
    public class UserService : BaseService, IUserService
    {
        public UserService(ICustomConnectionFactory factory) :base(factory)
        {

        }

        public string GetString()
        {
            /// 1. 先判断 是否有缓存
            /// 2.如果有缓存，就直接返回缓存的数据 
            return DateTime.Now.ToString();
            //3.保存到缓存内部中去
        }

        public string GetString1()
        {
            /// 1. 先判断 是否有缓存
            /// 2.如果有缓存，就直接返回缓存的数据 
            return DateTime.Now.ToString();
            //3.保存到缓存内部中去
        }

        public string GetString2()
        {
            /// 1. 先判断 是否有缓存
            /// 2.如果有缓存，就直接返回缓存的数据 
            return DateTime.Now.ToString();
            //3.保存到缓存内部中去
        }
    }
}
