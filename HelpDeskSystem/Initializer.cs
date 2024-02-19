using System.Diagnostics;
using HelpDeskSystem.DAL.Interfaces;
using HelpDeskSystem.DAL.Repository;
using HelpDeskSystem.Domain.Entity;
using HelpDeskSystem.Domain.Enum;

using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Users>, UserRepository>();
        }

        public static void InitialServices(this IServiceCollection services)
        {
            //   services.AddScoped<IAccountService, AccountService>();
        }
        public static void AddAccount(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnValidatePrincipal = async context =>
                {
                    var UserName = context.Principal?.Identity?.Name;
                    var UserRepository = context.HttpContext.RequestServices.GetService<UserRepository>();
                    var User = await UserRepository.GetAll().FirstOrDefaultAsync(x => x.Login == UserName);
                    if (User == null)
                    {
                        User = new Users
                        {
                            Login = UserName,
                            Role = Role.User
                        };
                        await UserRepository.Create(User);
                    }
                    else
                    {
                        Debug.WriteLine("Аккаунт уже существуеет:)");
                    }
                    Debug.WriteLine($"add new user : {User.Login}");
                };
               
            });
            Debug.WriteLine($"Я находился в методе AddAccount");
        }

    }
}
