using JobHubWebAPI.ApplicationLayer.AuthService.Interfaces;
using JobHubWebAPI.ApplicationLayer.AuthService.Repos;
using JobHubWebAPI.ApplicationLayer.EFCoreService.LoadingWith;
using JobHubWebAPI.ApplicationLayer.Token;
using JobHubWebAPI.APPLICATIONLAYER.AccountService;
using JobHubWebAPI.DataLayer.DataBaseConnection;
using JobHubWebAPI.DATALAYER.Repositores.ImplementationR;
using JobHubWebAPI.DATALAYER.Repositores.ServicesR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GenJWT>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IRegisterService,RegisterService>();
builder.Services.AddDbContext<JobHubDataBaseContext>(context =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")); // connection string is inside sercet.json that will be invisible in any appsettings json files :)
    // connectionstrings is string type that's why I don't need to use IOptionSnapShot to get direct POCO type from configuration files
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        RequireExpirationTime = true
    };
    jwtOptions.Authority = builder.Configuration["JwtTokenSettings:ValidAudience"];
    jwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidAudiences = builder.Configuration.GetSection("JwtTokenSettings:ValidAudience").Get<string[]>(),
        ValidIssuers = builder.Configuration.GetSection("JwtTokenSettings:ValidIssuer").Get<string[]>()
    };
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error"); 
    // if any kind of exception happens this middleware will short circuit request and return static error page instead showing details of our error to mailicious user ( will use exception filtes to return information about error)
    app.UseStatusCodePagesWithReExecute("/notFound"); 
    // if request doesn't match any endpoint , not found will execute by endpoint middleware. To avoid ( let's say aviod :) ) that Im using this middleware to return own not found page with same url . Another option is  UseStatusCodePagesWithRedirects which redirect user to specific url :)
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
