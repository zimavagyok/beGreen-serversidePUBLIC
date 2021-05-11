using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using beGreen.WebApplication.Authentication.Interfaces;
using beGreen.Infrastructure.service;
using beGreen.Services;
using beGreen.Repositories;
using beGreen.Infrastructure.repository;
using beGreen.Infrastructure.unitOfWork;
using beGreen.Infrastructures.UnitOfWork;
using beGreen.Model.Identity;
using beGreen.WebApplication.extensions;
using beGreen.WebApplication.Authentication;

namespace beGreen.WebApplication
{
    public partial class Startup
    {
        private void SetServices(IServiceCollection serviceCollection)
        {
            #region Service

            serviceCollection.AddTransient<ITokenStoreService, TokenStoreService>();
            serviceCollection.AddTransient<ITokenValidatorService, TokenValidatorService>();

            serviceCollection.AddTransient<ISecurityService, SecurityService>();

            serviceCollection.AddTransient<IDeviceProfileConnectionRepository, DeviceProfileConnectionRepository>();
            serviceCollection.AddTransient<IDeviceProfileConnectionService, DeviceProfileConnectionService>();

            serviceCollection.AddTransient<IProfileService, ProfileService>();
            serviceCollection.AddTransient<IProfileRepository, ProfileRepository>();

            serviceCollection.AddTransient<IDeviceService, DeviceService>();
            serviceCollection.AddTransient<IDeviceRepository, DeviceRepository>();

            serviceCollection.AddTransient<IManufacturerService, ManufacturerService>();
            serviceCollection.AddTransient<IManufacturerRepository, ManufacturerRepository>();

            serviceCollection.AddTransient<IResetPasswordService, ResetPasswordService>();
            serviceCollection.AddTransient<IResetPasswordHashRepository, ResetPasswordHashRepository>();

            serviceCollection.AddTransient<IAuditService, AuditService>();
            serviceCollection.AddTransient<IAuditRepository, AuditRepository>();

            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();

            serviceCollection.AddTransient<IRecyclingBankService, RecyclingBankService>();
            serviceCollection.AddTransient<IRecyclingBankRepository, RecyclingBankRepository>();

            serviceCollection.AddTransient<ILikeService, LikeService>();
            serviceCollection.AddTransient<ILikeRepository, LikeRepository>();

            //serviceCollection.AddTransient<IImageUploaderService, ImageUploaderService>();
            #endregion

            #region AppSettings
            serviceCollection.AddTransient<IUnitOfWork<uint>, UnitOfWork<uint>>();
            serviceCollection.AddTransient<IUnitOfWork<string>, UnitOfWork<string>>();
            serviceCollection.AddTransient<IUnitOfWork<int>, UnitOfWork<int>>();
            serviceCollection.AddTransient<IUnitOfWork<double>, UnitOfWork<double>>();

            //setup configuration settings form appsettings.json
            serviceCollection.AddSingleton<IConfiguration>(Configuration);

            serviceCollection.Configure<ConnectionString>(x => Configuration.GetSection("Connection").Bind(x));
            serviceCollection.Configure<JwtSettings>(x => Configuration.GetSection("JwtSettings").Bind(x));

            serviceCollection.AddSingleton<JwtSettings>((_) => Configuration.GetObjectFromConfigSection<JwtSettings>("JwtSettings"));
            serviceCollection.AddSingleton<ConnectionString>((_) => Configuration.GetObjectFromConfigSection<ConnectionString>("Conection"));
            #endregion

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}
