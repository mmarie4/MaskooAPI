using DAL;
using DAL.Repositories.Diaries;
using DAL.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Diaries;
using Services.SecretService;
using Services.Users;
using AutoMapper;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaskooAPI", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));

            // Configure JWT authentication.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
