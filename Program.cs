using PracticeCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text; 
using Microsoft.OpenApi.Models;
//var  MyAllowSpecificOrigins = "AllowOrigin";

var builder = WebApplication.CreateBuilder(args);  
// Add services to the container.
builder.Services.AddCors(options => {
              options.AddPolicy(name:"AllowOrigin", builder => {
                  builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
              });
          });
 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



          var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
 
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PracticeCrud", Version = "v1" });
            });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PracticeCrud v1"));
}




app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
