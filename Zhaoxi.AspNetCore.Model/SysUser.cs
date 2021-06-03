using System;
using System.Collections.Generic;

namespace Zhaoxi.AspNetCore.Model
{
    public partial class SysUser
    {
        public SysUser()
        {
            SysUserRoleMapping = new HashSet<SysUserRoleMapping>();
            UserInfo = new HashSet<UserInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public byte Status { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long? Qq { get; set; }
        public string WeChat { get; set; }
        public byte? Sex { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int CompanyId { get; set; }
        public int? CompanyId1 { get; set; }

        public virtual Company Company { get; set; }
        public virtual Company CompanyId1Navigation { get; set; }
        public virtual ICollection<SysUserRoleMapping> SysUserRoleMapping { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
