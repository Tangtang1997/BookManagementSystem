using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BMS.DAL.EntityFrameworkCore
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseSqlServer("Server=.; Database=BMSDB;User ID=sa;Password=123@qwe");//本地数据库地址
            builder.UseSqlServer("Server=39.106.131.243; Database=BMSDB;User ID=sa;Password=123@qwe");//服务器数据库地址

            return new ApplicationDbContext(builder.Options);
        }
    }
}