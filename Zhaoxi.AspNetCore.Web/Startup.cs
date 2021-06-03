using System.Data;
using System.Data.SqlClient;
using System.IO;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Zhaoxi.AspNetCore.Interface;
using Zhaoxi.AspNetCore.Interface.Extend;
using Zhaoxi.AspNetCore.Redis;
using Zhaoxi.AspNetCore.Redis.Interface;
using Zhaoxi.AspNetCore.Redis.Service;
using Zhaoxi.AspNetCore.Service;

namespace Zhaoxi.AspNetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////ע�����
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IDbConnection, SqlConnection>();
            //services.AddTransient<ICustomConnectionFactory, CustomConnectionFactory>();
            
            services.Configure<DBConnectionOption>(Configuration.GetSection("ConnectionStrings"));
            services.AddControllersWithViews();
        }


        /// <summary>
        /// ʹ��Autofac
        /// 1.����Autofac �����
        /// 2.����.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        /// 3.ConfigureContainer ����
        /// 4.ע�����
        /// 5. Interceptor
        /// 6.ע��Interceptor
        /// 7.����Ҫ֧��AOP�ķ�����������[Intercept(typeof(CacheInterceptor))]
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            { 
                builder.RegisterType<CacheInterceptor>().As<CacheInterceptor>().UsingConstructor(typeof(IRedisStringService));
                builder.RegisterType<SqlConnection>().As<IDbConnection>();
                builder.RegisterType<RedisStringService>().As<IRedisStringService>();
                builder.RegisterType<UserService>().As<IUserService>() 
                    .EnableInterfaceInterceptors();  //��ǰע��֧��AOP
                //builder.RegisterType<RedisStringService>().As<IRedisStringService>();
                builder.RegisterType<CustomConnectionFactory>().As<ICustomConnectionFactory>().UsingConstructor(typeof(IDbConnection), typeof(IOptionsMonitor<DBConnectionOption>));
            }

        }





        //Autofa ��һ������  ֧��AOP
        //1.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseStaticFiles();
            //ָ������·����ȡ��̬�ļ�
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot"))
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Second}/{action=IndexCache}/{id?}");
            });
        }
    }
}
