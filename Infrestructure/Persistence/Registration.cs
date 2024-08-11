using Application.Interfaces.Repositories;
using Application.Interfaces.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Rpositories;
using Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class Registration
    {
        //extension metod, türe yeni metod eklememizi sağlıyor (this IServiceCollection services)
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepo <>), typeof(ReadRepository <>));
            services.AddScoped(typeof(IWriteRepo<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
