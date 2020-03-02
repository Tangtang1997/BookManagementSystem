using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BMS.DAL.EntityFrameworkCore;

namespace BMS.Web.Startup
{
    /// <summary>
    /// Autofac启动配置
    /// </summary>
    public class AutoFacBootstrap
    {
        /// <summary>
        /// 注册
        /// </summary>
        public static void Register()
        {
            // 实例化一个Autofac的创建容器
            var builder = new ContainerBuilder();

            SetupResolveRules(builder);

            //注册Controller
            builder.RegisterControllers(Assembly.GetExecutingAssembly())
                   .PropertiesAutowired();

            //注册数据库上下文
            builder.Register(m => new ApplicationDbContextFactory().CreateDbContext(null)).As<ApplicationDbContext>();

            // 创建一个Autofac的容器
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        /// <summary>
        /// 配置规则
        /// </summary>
        /// <param name="builder"></param>
        public static void SetupResolveRules(ContainerBuilder builder)
        {
            // 告诉Autofac框架，将来要创建的控制器类存放在哪个程序集
            var apiControllerAssembly = Assembly.Load("BMS.Web");
            builder.RegisterControllers(apiControllerAssembly);

            // 告诉Autofac框架，注册数据仓储层所在程序集中的所有类的对象实例，创建仓储层中的所有类的instance以此类的实现接口存储
            var repositoryAssembly = Assembly.Load("BMS.DAL");
            builder.RegisterTypes(repositoryAssembly.GetTypes())
                   .Where(a => a.Name.Contains("Repository"))
                   .AsImplementedInterfaces();

            // 告诉Autofac框架，注册数据业务层(BLL层)所在程序集中的所有类的对象实例，创建应用层中的所有类的instance（实例）以此类的实现接口存储
            var serviceAssembly = Assembly.Load("BMS.BLL");
            builder.RegisterTypes(serviceAssembly.GetTypes())
                   .Where(a => a.Name.Contains("Service"))
                   .AsImplementedInterfaces();
        }

    }
}