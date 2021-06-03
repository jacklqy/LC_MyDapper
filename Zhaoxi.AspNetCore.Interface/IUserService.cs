using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Zhaoxi.AspNetCore.Redis;

namespace Zhaoxi.AspNetCore.Interface
{
    public interface IUserService : IBaseService
    {

        public string GetString();
    }
}
