using AutoMapper;
using DAL;
using DAL.Repositories.Diaries;
using DAL.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Services.Diaries;
using Services.SecretService;
using Services.Users;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MaskooAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaskooAPI", Version = "v1" });
            });

            // Automapper
            services.AddAutoMapper(typeof(Startup));

            // Configure JWT authentication.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = "https://localhost:5001",
                      ValidAudience = "https://localhost:5001",
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw=="))
                  };

                  options.Events = new JwtBearerEvents
                  {
                      OnAuthenticationFailed = context =>
                      {
                          if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                          {
                              context.Response.Headers.Add("Token-Expired", "true");
                          }
                          return Task.CompletedTask;
                      }
                  };
              });

            // Services
            services.AddTransient<IDiaryService, DiaryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISecretService, SecretService>();

            // Repositories
            services.AddTransient<IDiaryRepository, DiaryRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Db context
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });
            services.AddRazorPages()
                .AddNewtonsoftJson()
                .WithRazorPagesRoot("/MaskooClient/Pages");
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaskooAPI v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                             Path.Combine(env.ContentRootPath, "MaskooClient/wwwroot")),
                RequestPath = "/static"
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
