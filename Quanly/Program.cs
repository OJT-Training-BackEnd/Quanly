using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quanly.Data;
using Quanly.Services.CustomerService;
using Quanly.Services.MemberCardsService;
using Quanly.ValidationHandling.CustomerValidation;
using Quanly.Services.UserService;
using Quanly.ValidationHandling.MemberCardValidation;
using Quanly.Services.ContactPersonService;
using Quanly.ValidationHandling.ContactPersonValidation;
using Quanly.Services.AccumulateRuleService;
using Quanly.ValidationHandling.AccumulateRuleValidation;
using Quanly.ValidationHandling.AccumulatePointsValidation;
using Quanly.Services.ValidPointsService;
using Quanly.Services.AccumulatePointsService;
using Quanly.Models.AccumulatePoints;
using System.Text.Json.Serialization;
using Quanly.Models.AccumulatePointsRules;
using Quanly.Models;

var builder = WebApplication.CreateBuilder(args);
/*var server = builder.Configuration["DBServer"] ?? "localhost";
var port = builder.Configuration["DBPort"] ?? "11433";
var user = builder.Configuration["DBUser"] ?? "sa";
var password = builder.Configuration["DBPassword"] ?? "Chinhpro123a";
var database = builder.Configuration["Database"] ?? "quanly";*/
// Add services to the container.
/*builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer($"Server={server};Database={database};Uid={user};Password={password}"));*/
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder
    .Configuration
    .GetConnectionString("DefaultConnection")));

/*Console.WriteLine($"Server={server},{port};Initial Catalog={database};Uid={user};Password={password}");*/
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//Configure the Services
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<CustomerValidation>();

builder.Services.AddScoped<IMemberCardService, MemberCardService>();
builder.Services.AddScoped<MemberCardValidation>();

builder.Services.AddScoped<ValidGetAllCus>();
builder.Services.AddScoped<ValidDeleteCus>();

builder.Services.AddScoped<IContactPersonService, ContactPersonService>();
builder.Services.AddScoped<ContactPersonValidation>();

builder.Services.AddScoped<IAccumulatePointsService, AccumulatePointsService>();
builder.Services.AddScoped<ValidGetAllAccumulatePoints>();
builder.Services.AddScoped<DeleteAccumulatePoints>();
builder.Services.AddScoped<SearchAccumulatePoints>();

builder.Services.AddScoped<IAccumulateRuleService, AccumulateRuleService>();
builder.Services.AddScoped<AccumulateRuleValidation>();
builder.Services.AddScoped<AccumulatePoint>();
builder.Services.AddScoped<AccumulatePointsRule>();
var app = builder.Build();

PrepDB.PrepPopulation(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
