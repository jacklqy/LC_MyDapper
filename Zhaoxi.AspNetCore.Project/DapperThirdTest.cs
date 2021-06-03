using Dapper;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Zhaoxi.AspNetCore.Model;

namespace Zhaoxi.AspNetCore.Project
{
    public class DapperThirdTest
    {
        /// <summary>
        ///框架落地的时候，会通过Autofac-AOP注入
        /// </summary>
        public static void Show()
        {
            MiniProfiler profiler = MiniProfiler.StartNew("StartNew");
            using (profiler.Step("Level1"))
            {
                //查询
                using (IDbConnection Connection = GetConnection())
                {
                    Company company02 = Connection.QueryFirst<Company>("select * from Company");
                }
            }
            WriteLog(profiler);
        }


        private static IDbConnection GetConnection()
        {
            DbConnection connection = new SqlConnection("Server=LAPTOP-QDDHF04P;Database=ZhaoXiDataBaseInit;Trusted_Connection=True;");
            if (MiniProfiler.Current != null)
            {
                connection = new StackExchange.Profiling.Data.ProfiledDbConnection(connection, MiniProfiler.Current);
            }
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 相当于把对数据库的命令全部记录下来，中间也有Sql语句部分；
        /// </summary>
        /// <param name="profiler"></param>
        private static void WriteLog(MiniProfiler profiler)
        {
            if (profiler?.Root != null)
            {
                var root = profiler.Root;
                if (root.HasChildren)
                {
                    root.Children.ForEach(chil =>
                    {
                        if (chil.CustomTimings?.Count > 0)
                        {
                            foreach (var customTiming in chil.CustomTimings)
                            {
                                var all_sql = new List<string>();
                                var err_sql = new List<string>();
                                var all_log = new List<string>();
                                int i = 1;
                                customTiming.Value?.ForEach(value =>
                                {
                                    if (value.ExecuteType != "OpenAsync")
                                        all_sql.Add(value.CommandString);
                                    if (value.Errored)
                                        err_sql.Add(value.CommandString);
                                    var log = $@"【{customTiming.Key}{i++}】{value.CommandString} Execute time :{value.DurationMilliseconds} ms,Start offset :{value.StartMilliseconds} ms,Errored :{value.Errored}";
                                    all_log.Add(log);
                                });
                                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(all_log));
                            }
                        }
                    });
                }
            }
        }
    }
}
