using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Services.HuggingFaceService;
using Blogy.Business.Services.OpenAIService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;
namespace Blogy.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServicesExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryMappings).Assembly);

            services.AddHttpClient<IHuggingFaceService, HuggingFaceService>();
            services.AddHttpClient<IOpenAIService, OpenAIService>();

            services.Scan(opt =>
            {
                opt.FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });

            //bu aşağdıkilere gerek kalmadı

            //services.AddScoped<IBlogService, BlogService>();
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<ICommentService, CommentService>();

            services
                 .AddFluentValidationAutoValidation()
                 .AddFluentValidationClientsideAdapters()
                 .AddValidatorsFromAssembly(typeof(CreateCategoryDto).Assembly);

        }
    }
}
