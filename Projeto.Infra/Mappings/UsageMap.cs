using Projeto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Infra.Mappings
{
	public class UsageMap : EntityTypeConfiguration<Usage>
	{
		public UsageMap()
		{
			ToTable("Usages");
			HasKey(x => x.Id);

			Property(x => x.Distance).IsRequired().HasColumnName("Distance");
			Property(x => x.StartDate).IsRequired().HasColumnName("StartDate");
			Property(x => x.EndDate).IsRequired().HasColumnName("EndDate");
			Property(x => x.Active).IsRequired().HasColumnName("Active");

			HasRequired(x => x.User);
			HasRequired(x => x.Bike);
		}
	}
}