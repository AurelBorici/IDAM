using Infrastructure;
using Infrastructure.ExceptionHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MigrationMSSQL;
using Perstistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IDAM", Description = "Identity and Access Management System", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert authentication token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string [] {}
                    }
    });
    c.EnableAnnotations();
});
builder.Services.AddIdentityInfrastructure(builder.Configuration);

builder.Services.AddDbContext<IDAMContext>(config => config.UseSqlServer(builder.Configuration.GetConnectionString("IDAMDatabase")));

builder.Services.AddPersistenceConfig(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IDAM V1");
    });
    app.UseDeveloperExceptionPage();

}
app.UseRouting();
app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true)
             .AllowCredentials());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
