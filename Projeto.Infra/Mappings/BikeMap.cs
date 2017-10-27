using Projeto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Infra.Mappings
{
	public class BikeMap : EntityTypeConfiguration<Bike>
	{
		public BikeMap()
		{
			ToTable("Bikes");
			HasKey(x => x.Id);

			Property(x => x.Location.Latitude).IsRequired().HasColumnName("Latitude");
			Property(x => x.Location.Longitude).IsRequired().HasColumnName("Longitude");
		}
	}
}