using System;

namespace Zhaoxi.AspNetCore.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("同学们晚上好！欢迎大家来到.Net高级班的体验课~");
            try
            {
                ///性能之王Dapper初识
                ///最接近于Ado.Net
                {
                    DapperOneTest.Show();
                }
                {
                    //DapperSecondTest.Show();
                }
                {
                    //批量操作，Dapper提供了和数据库配合完成  Bulk；
                    //DapperFourthSqlBulkTest.Show(); 
                }
                {
                    //DapperThirdTest.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
