using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Thaz.BLL.Model;
using Thaz.BLL.Services;

namespace Thaz.BLL
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<AuthService>();
            services.AddTransient<AccountingService>();
            services.AddTransient<BillService>();
            services.AddTransient<CondominiumService>();
            services.AddTransient<PartnerService>();
            services.AddTransient<TransactionService>();

            services.AddScoped<User, UserFromContext>();

        }
    }
}