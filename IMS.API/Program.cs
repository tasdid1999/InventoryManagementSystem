using Ecom.API.Validator;
using Ecom.Infrastructure.Repository.UserRepository;
using Ecom.Service.User;
using IMS.API.Validator;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repository.Auth;
using IMS.Infrastructure.UnitOfWork;
using IMS.Service.Auth;
using IMS.Service.productBrand;
using IMS.Service.productCatagory;
using IMS.Service.productService;
using IMS.Service.purchase;
using IMS.Service.requsition;
using IMS.Service.shop;
using IMS.Service.shopBin;
using IMS.Service.shopRack;
using IMS.Service.shopRow;
using IMS.Service.shopToShopTransfer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<IdentityUser<int>,IdentityRole<int>>().AddEntityFrameworkStores<Context>();
builder.Services.AddDbContext<Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

//services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductBrandService, ProductBrandService>();
builder.Services.AddScoped<IProductCatagoryService, ProductCatagoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShopService,ShopService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShopBinService, ShopBinService>();
builder.Services.AddScoped<IShopRackService, ShopRackService>();
builder.Services.AddScoped<IShopRowService, ShopRowService>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IRequsitionService,RequsitionService>();
builder.Services.AddScoped<IPurchaseService,PurchaseService>();
builder.Services.AddScoped<IShopToShopTransferService, ShopToShopTransferService>();

builder.Services.AddScoped<RegisterValidator>();
builder.Services.AddScoped<LoginValidator>();
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<ShopValidator>();
builder.Services.AddScoped<RequisitionValidator>();
builder.Services.AddScoped<PurchaseValidator>();
builder.Services.AddScoped<ProductCatagoryValidator>();
builder.Services.AddScoped<ProductBrandValidator>();
builder.Services.AddScoped<ShopStockValidator>();
builder.Services.AddScoped<ShopToShopTransferValidator>();
//database configuration for Dapper
builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetService<IConfiguration>();

    var connectionString = configuration.GetConnectionString("conn") ?? throw new Exception("connection string not found");

    return new SqlConnectionFactory(connectionString);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryManagementSystem Test apis", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "This site uses Bearer token for authentication. format: Bearer<<space>>token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>(){}
                    }

                });
});
//jwt config
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:SecretKey") ?? throw new Exception("there is no secret key"))),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddControllers().AddNewtonsoftJson();

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
