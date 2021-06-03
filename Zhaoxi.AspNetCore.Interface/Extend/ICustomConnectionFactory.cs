using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Zhaoxi.AspNetCore.Interface.Extend
{
    public interface ICustomConnectionFactory
    {
        //
        public IDbConnection GetConnection(WriteAndRead writeAndRead);
    }
}
