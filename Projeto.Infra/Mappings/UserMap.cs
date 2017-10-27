using Projeto.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Infra.Mappings
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			ToTable("Users");
			HasKey(x => x.Id);

			Property(x => x.Name.FirstName).IsRequired().HasMaxLength(15).HasColumnName("FirstName");
			Property(x => x.Name.LastName).IsRequired().HasMaxLength(15).HasColumnName("LastName");

			Property(x => x.ProfilePic).IsRequired().HasColumnName("ProfilePic");
			Property(x => x.Odometer).IsRequired().HasColumnName("Odometer");
		}
	}
}