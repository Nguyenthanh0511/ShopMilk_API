using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Reponsitory.Base;
using Reponsitory.IRepo;
using Reponsitory.Repo;
using Service.Implement;
using Service.Interface;
using AutoMapper;
using Service.Mapping;
using Model.Model;
using Service.Base;
using ShopMilk.HelperAuthen;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Service.Implement;
//using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Configure about Authentication
JWTAuthen.Issuer = builder.Configuration["Jwt:Issuer"];
JWTAuthen.KeyString = builder.Configuration["Jwt:KeyString"];
JWTAuthen.Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
JWTAuthen.Audience = builder.Configuration["Jwt:Audience"];
// add service 
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = JWTAuthen.Audience,
        ValidIssuer = JWTAuthen.Issuer,
        IssuerSigningKey = JWTAuthen.Key,
    };
});


// Configure service
// Đăng ký DbContext với chuỗi kết nối
string getConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Shopmilk_5Context>(options => options.UseSqlServer(getConnectionString));
// Đăng ký các repository
builder.Services.AddScoped<Shopmilk_5Context, Shopmilk_5Context>();
builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IGalleryRepo, GalleryRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<ICartDetailRepo, CartDetailRepo>();
builder.Services.AddScoped<IUserRepo,TUserRepo>();
//Service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartDetailService<CartDetail>, CartDetailService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGalleryService,GalleryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//Auto mapping
builder.Services.AddAutoMapper(typeof(MappingP));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Allow at Frontend to call API
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllowAll");

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
