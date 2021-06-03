﻿using System;
using System.Collections.Generic;

namespace Zhaoxi.AspNetCore.Model
{
    public partial class SysMenu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SysMenuName { get; set; }
        public string Url { get; set; }
        public byte MenuLevel { get; set; }
        public byte MenuType { get; set; }
        public string MenuIcon { get; set; }
        public string Description { get; set; }
        public string SourcePath { get; set; }
        public int Sort { get; set; }
        public byte Status { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public int? LastModifierId { get; set; }
    }
}
