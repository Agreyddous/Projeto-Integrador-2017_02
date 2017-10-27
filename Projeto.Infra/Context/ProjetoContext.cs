using Projeto.Domain;
using Projeto.Domain.Entities;
using Projeto.Infra.Mappings;
using System.Data.Entity;

namespace Projeto.Infra.Context
{
	public class ProjetoContext : DbContext
	{
		public ProjetoContext() : base(Runtime.ConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Bike> Bikes { get; set; }
		public DbSet<Usage> Usages { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserMap());
			modelBuilder.Configurations.Add(new BikeMap());
			modelBuilder.Configurations.Add(new UsageMap());
		}
	}
}