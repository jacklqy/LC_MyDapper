using System;
using System.Collections.Generic;
using System.Text;

namespace Zhaoxi.AspNetCore.Interface.Extend
{
    public class DBConnectionOption
    {
        public string WriteConnection { get; set; }
        public List<string> ReadConnectionList { get; set; }

        public Strategy Strategy { get; set; }
    }
}
