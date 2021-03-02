using API.ApiServices;
using Core.Services.ArtPieceServices;
using Core.Services.DbServices;
using Core.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class InterfaceConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAddArtWork, AddArtWork>();
            services.AddScoped<IMapPiece, MapPiece>();
            services.AddScoped<IQueryDbService, QueryDbService>();
            services.AddScoped<IGetUserData, GetUserData>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IEditUser, EditUser>();
        }
    }
}