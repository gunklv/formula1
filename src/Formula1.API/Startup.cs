using API.Helpers;
using BLL.Configuration;
using DAL.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Reflection;
using System.Text;

namespace API
{
    public class Startup
    {
        private const string corsPolicy = nameof(corsPolicy);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ExceptionHandler>();
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Jwt:Secret"))),
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddDataContext();
            services.AddRepositores();
            services.AddServices();
            services.AddValidatorsFromAssemblies(new Assembly[] { Assembly.GetAssembly(typeof(Startup)) });
            services.AddControllers().AddFluentValidation();
            services.AddSwaggerDocument(config => {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                config.AddSecurity("JWT",
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Copy 'Bearer {your valid JWT token}' into field",
                        In = OpenApiSecurityApiKeyLocation.Header
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler(applicationBuilder =>
            {
                applicationBuilder.Run(async context =>
                {
                    var handler = applicationBuilder.ApplicationServices.GetRequiredService<ExceptionHandler>();
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    await handler.HandleErrorAsync(context, ex?.Error);
                });
            });

            app.UseCors(corsPolicy);
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
