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
//using Service.Implement;
//using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Cấu hình dịch vụ
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
//Service
builder.Services.AddScoped<ICartDetailService<CartDetail>, CartDetailService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGalleryService,GalleryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(MappingP));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
