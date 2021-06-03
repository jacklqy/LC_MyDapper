using System;
using System.Collections.Generic;

namespace Zhaoxi.AspNetCore.Model
{
    public partial class SysLogInfo
    {
        public int Id { get; set; }
        public string Introduction { get; set; }
        public string Detail { get; set; }
        public byte LogType { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
    }
}
