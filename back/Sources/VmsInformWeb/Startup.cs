using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using VmsInform.Business.Settings;
using VmsInform.Common.Auth;
using VmsInform.DAL.MyBoxRepositories;
using VmsInform.DbMigration;
using VmsInformWeb.Filters;

namespace VmsInformWeb
{
    public class Startup
    {
        private const string _swaggerApiTitle = "VmsInform API";
        private const string _connectionStringName = "DefaultConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.Configure<DbSettings>(Configuration);

            services.AddControllers(a =>
            {
                a.Filters.Add<ExceptionFilter>();
            }).AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                opts.JsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBox.Delivery.Management.WebApi", Version = "v1" });
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthenticationRequirementsOperationFilter>();
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.TokenIssuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.Configure<AuthSettings>(Configuration);
            services.AddHttpContextAccessor();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(GetType().Assembly);
            builder.RegisterMediatR(GetType().Assembly);
            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            //builder.Register(ctx => new VmsInformContext("Data Source=192.168.5.230;Initial Catalog=autoPrice;User ID=sa; pwd=st3b8aXd;"))
            builder.RegisterType<VmsInformContext>()
            .As<DbContext>()
            .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", _swaggerApiTitle));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseFastReport();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/api/images"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Scripts")),
                RequestPath = "/api/scripts"
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            new DbMigrationContext(Configuration).Database.Migrate();

            Console.WriteLine(Configuration.GetConnectionString(_connectionStringName));
            //new DbMigrationContext("Data Source=192.168.5.230;Initial Catalog=autoPrice;User ID=sa; pwd=st3b8aXd;").Database.Migrate();

        }
    }
}
