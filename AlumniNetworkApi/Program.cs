using AlumniNetworkApi.Models;
using AlumniNetworkApi.Services.AlumniGroups;
using AlumniNetworkApi.Services.AlumniUsers;
using AlumniNetworkApi.Services.Events;
using AlumniNetworkApi.Services.Posts;
using AlumniNetworkApi.Services.Topics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://keyclokalumni.azurewebsites.net/auth/realms/alumni"; 
    options.Audience = ".NET-auth"; 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DefaultFilesOptions newOptions = new DefaultFilesOptions();
newOptions.DefaultFileNames.Append("index.html");
app.UseDefaultFiles(newOptions);

app.UseStaticFiles();

app.UseCors("AllowAny");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
