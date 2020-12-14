using Microsoft.Extensions.DependencyInjection;
using Thaz.BLL.Repositories;
using Thaz.DAL.Repositories;
using Thaz.DAL.Repositories.Accounting;

namespace Thaz.DAL
{
    public static class Startup
    { 
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ThazDbContext>();
            
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IPartnerRepository, PartnerRepository>();
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<ICondominiumRepository, CondominiumRepository>();
            
            services.AddTransient<IAccountingRepository, AccountingRepository>();
            services.AddTransient<IBillAccountingRepository, BillAccountingRepository>();
            services.AddTransient<ICondominiumAccountingRepository, CondominiumAccountingRepository>();
        }
    }
}