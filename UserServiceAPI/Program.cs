using Microsoft.EntityFrameworkCore;
using UserServiceAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EFCoreDBConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()  // Allow any Origins
                   .AllowAnyHeader()  // Allow any headers (like Content-Type)
                   .AllowAnyMethod(); // Allow any HTTP methods (GET, POST, etc.)
        });
});
builder.Services.AddScoped<UserRepository>();
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
app.UseCors("AllowAllOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
