using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProfile.DAL;
using MyProfile.DAL.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace MyProfile.API
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
			services.AddMvc();
			services.AddAutoMapper(typeof(Startup));
			services.AddDbContext<MyProfileDbContext>(options => options.UseInMemoryDatabase(databaseName: "MyProfile"));
			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IContactRepository, ContactRepository>();
			services.AddScoped<IExperienceRepository, ExperienceRepository>();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1.0", new Info { Title = "MyProfile", Version = "v1.0" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "MYProfile v1.0");
			});

			app.UseMvc();
		}
	}
}
