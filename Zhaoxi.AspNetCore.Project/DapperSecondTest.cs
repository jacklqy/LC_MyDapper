using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zhaoxi.AspNetCore.Model;

namespace Zhaoxi.AspNetCore.Project
{
    public class DapperSecondTest
    {
        public static void Show()
        {
            {
                //查询
                using (IDbConnection Connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;"))
                {
                    Company company01 = Connection.QueryFirst<Company>("select * from Company");
                    //Connection.Query< Company >()
                    //Connection.BeginTransaction 
                    #region InsertCompnay
                    string strSql = @"INSERT INTO [dbo].[Company] ([Name] ,[CreateTime] ,[CreatorId]
                                                   ,[LastModifierId]
                                                   ,[LastModifyTime]
                                                   ,[Description])
                                             VALUES
                                                   (@Name
                                                   ,@CreateTime
                                                   ,@CreatorId
                                                   ,@LastModifierId
                                                   ,@LastModifyTime
                                                   ,@Description)";
                    #endregion 
                    int flg = Connection.Execute(strSql, new
                    { Name = "朝夕教育", CreateTime = DateTime.Now, CreatorId = 1, LastModifierId = 1, LastModifyTime = DateTime.Now, Description = "致力于改造.Net生态圈" });
                }
            }
        }
    }
}
