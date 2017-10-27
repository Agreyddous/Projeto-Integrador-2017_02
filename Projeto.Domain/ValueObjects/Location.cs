using FluentValidator;

namespace Projeto.Domain.ValueObjects
{
	public class Location : Notifiable
	{
		protected Location() { }
		public Location(string latitude, string longitude)
		{
			Latitude = latitude;
			Longitude = longitude;

			new ValidationContract<Location>(this)
				.IsRequired(x => x.Latitude, "Latitude is required")
				.IsRequired(x => x.Longitude, "Longitude is required");
		}

		public string Latitude { get; private set; }
		public string Longitude { get; private set; }

		public override string ToString() => Latitude + ":" + Longitude;
	}
}