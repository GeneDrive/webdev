using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PretparkContext>(options =>
    options.UseSqlite("Data Source=mijndatabase.db"));

// Add services to the container.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PretparkContext>()
                .AddDefaultTokenProviders();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7131",
        ValidAudience = "https://localhost:7131",
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"))
    };
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
//
// help dit werkt niet
//
// builder.Services.AddSwaggerGen(c => {
//     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         Name = "Authorization",
//         Type = SecuritySchemeType.ApiKey,
//         Scheme = "Bearer",
//         BearerFormat = "JWT",
//         In = ParameterLocation.Header,
//         Description = "JWT Authorization header using the Bearer scheme."
//     });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
