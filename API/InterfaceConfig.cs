using API.Services;
using Core.Services.ArtWorkServices;
using Core.Services.DbServices;
using Core.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAddArtWork, AddArtWork>();
            services.AddScoped<IMapPiece, MapPiece>();
            services.AddScoped<IGetUserData, GetUserData>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IEditUser, EditUser>();
            services.AddScoped<IGetArtWork, GetArtWork>();
            services.AddScoped<IEditArtWork, EditArtWork>();
            services.AddScoped<IDeleteArtWork, DeleteArtWork>();
            services.AddSingleton<ISqlServer>(new SqlServer(configuration));
            services.AddScoped<IAwsImage, AwsImage>();
        }
    }
}