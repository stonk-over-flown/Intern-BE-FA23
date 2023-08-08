using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Test.Entity;
using Test.Repository;
using Test.Tools;

namespace Test
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //JWT for later

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<AppDbContext>();
            //add scoped for repo here
            services.AddScoped<UserRepo>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRMS API", Version = "v1" });
            });

            services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
            });

            services.AddCors(o =>
            {
                o.AddPolicy("AllowAnyOrigin", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.SetIsOriginAllowed(x => _ = true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // auto migrate database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                // Here is the migration executed
                try
                {
                    await dbContext.Database.MigrateAsync();
                    await DbInit.Initialize(dbContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            app.UseCors("AllowAnyOrigin");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tét API v1"));
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out DateTime dateTime))
            {
                return dateTime;
            }


            return default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("dd/MM/yyyy"));
        }
    }
}
