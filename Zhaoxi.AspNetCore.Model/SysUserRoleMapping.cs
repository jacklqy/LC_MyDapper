using System;
using System.Collections.Generic;

namespace Zhaoxi.AspNetCore.Model
{
    public partial class SysUserRoleMapping
    {
        public int SysUserId { get; set; }
        public int SysRoleId { get; set; }

        public virtual SysRole SysRole { get; set; }
        public virtual SysUser SysUser { get; set; }
    }
}
