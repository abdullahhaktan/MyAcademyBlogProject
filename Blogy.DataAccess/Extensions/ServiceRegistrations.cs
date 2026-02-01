using Blogy.DataAccess.Context;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace Blogy.DataAccess.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddRepositoriesExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(opt =>
            {
                opt.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });

            //bu aşağıdakilere gerek kalmadı

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IBlogRepository, BlogRepository>();
            //services.AddScoped<IBlogTagRepository, BlogTagRepository>();
            //services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
