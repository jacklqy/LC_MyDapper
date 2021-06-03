using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using Z.Dapper.Plus;
using Zhaoxi.AspNetCore.Model;

namespace Zhaoxi.AspNetCore.Project
{
    public class DapperFourthSqlBulkTest
    {
        /// <summary>
        /// 批量操作
        /// </summary>
        public static void Show()
        {
            List<Company> companies = new List<Company>();
            for (int i = 0; i < 10000; i++)
            {
                companies.Add(new Company()
                {
                    Name = $"朝夕{i}分公司",
                    CreateTime = DateTime.Now,
                    CreatorId = 1,
                    Description = $"朝夕{i}分公司",
                    LastModifierId = 1,
                    LastModifyTime = DateTime.Now
                });
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //批量操作   SqlSerer2008版本以上才支持
            //{ //方案1：单链接循环操作
            //    //7129
            //    using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
            //    {
            //        foreach (var company in companies)
            //        { 
            //            Connection.Insert<Company>(company);
            //        }
            //    }
            //}
            //{
            //    //方案2：循环操作多链接   
            //    //循环集合 每次循环单个操作；  最不可取
            //    //8410
            //    foreach (var company in companies)
            //    {
            //        using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
            //        {
            //            Connection.Insert<Company>(company);
            //        }
            //    }
            //}
            {
                //方案3：SqlBulk 2822  SqlBulk是数据库支持的；
                //批量操作优选这个Bukl;
                using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                {
                    Connection.BulkInsert<Company>(companies);
                }
            }
            stopwatch.Stop();
            var count = stopwatch.ElapsedMilliseconds;   
            Console.WriteLine(count);
        }
    }
}
