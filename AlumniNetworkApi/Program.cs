using AlumniNetworkApi.Models;
using AlumniNetworkApi.Services.AlumniGroups;
using AlumniNetworkApi.Services.AlumniUsers;
using AlumniNetworkApi.Services.Events;
using AlumniNetworkApi.Services.Posts;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            builder.Services.AddDbContext<AlumniDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddScoped<IAlumniGroupService, AlumniGroupService>();
            builder.Services.AddScoped<IAlumniUserService, AlumniUserService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}