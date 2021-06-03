using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zhaoxi.AspNetCore.Model;

namespace Zhaoxi.AspNetCore.Project
{
    public class DapperOneTest
    {
        public static void Show()
        {
            {
                {
                    //增加
                    using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                    {
                        //Connection.Open(); 
                        //Nuget引入：Dapper.Contrib.Extensions  
                        var addCompany = new Company()
                        {
                            Name = "朝夕教育",
                            CreateTime = DateTime.Now,
                            CreatorId = 1,
                            LastModifierId = 1,
                            LastModifyTime = DateTime.Now,
                            Description = "专注于培养新一代C#与.Net技术精英~"
                        };
                        long flg = Connection.Insert<Company>(addCompany);
                    }
                }
                {
                    //查询
                    using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                    {
                        Company company01 = Connection.Get<Company>(10054);
                        //Company company02 = Connection.QueryFirst<Company>("select * from Company");
                    }
                }
                {
                    //修改
                    using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                    {
                        Company company01 = Connection.Get<Company>(10054);
                        company01.Name = company01.Name + "123";
                        Connection.Update<Company>(company01);
                    }
                }
                {
                    //删除
                    using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                    {
                        Company company01 = Connection.Get<Company>(10054);
                        Connection.Delete<Company>(company01);
                    }
                }
            }
        }
    }
}
