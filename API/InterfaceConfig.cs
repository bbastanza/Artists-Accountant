using API.Services;
using Core.Services.ArtWorkServices;
using Core.Services.DbServices;
using Core.Services.SqlBuilders;
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
            services.AddScoped<IGetUserAuth, GetUserAuth>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IPatchUser, PatchUser>();
            services.AddScoped<IPatchArtWork, PatchArtWork>();
            services.AddScoped<IDeleteArtWork, DeleteArtWork>();
            services.AddScoped<IArtworkSqlBuilder, ArtworkSqlBuilder>();
            services.AddScoped<IUserSqlBuilder, UserSqlBuilder>();
            services.AddSingleton<ISqlServer>(new SqlServer(configuration));
        }
    }
}