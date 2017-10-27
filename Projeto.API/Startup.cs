using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Projeto.Infra.Context;
using Projeto.Infra.Transactions;
using Projeto.Domain.Repositories;
using Projeto.Infra.Repositories;
using Projeto.Domain.Commands.Handler;
using Projeto.Domain;
using Microsoft.Extensions.Logging;

namespace Projeto.API
{
	public class Startup
    {
		public IConfiguration Configuration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
			Configuration = configurationBuilder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddCors();

			services.AddScoped<ProjetoContext, ProjetoContext>();
			services.AddTransient<IUow, Uow>();

			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IBikeRepository, BikeRepository>();
			services.AddTransient<IUsageRepository, UsageRepository>();

			services.AddTransient<RegisterUserCommandHandler, RegisterUserCommandHandler>();
			services.AddTransient<UpdateUserCommandHandler, UpdateUserCommandHandler>();

			services.AddTransient<RegisterBikeCommandHandler, RegisterBikeCommandHandler>();

			services.AddTransient<RegisterUsageCommandHandler, RegisterUsageCommandHandler>();
			services.AddTransient<UpdateUsageCommandHandler, UpdateUsageCommandHandler>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			loggerFactory.AddConsole();

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseCors(x =>
			{
				x.AllowAnyHeader();
				x.AllowAnyMethod();
				x.AllowAnyOrigin();
			});
			app.UseMvc();

			Runtime.ConnectionString = Configuration.GetConnectionString("CnnStr");
		}
    }
}
