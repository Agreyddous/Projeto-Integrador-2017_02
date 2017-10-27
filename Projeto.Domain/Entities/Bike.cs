using Projeto.Domain.ValueObjects;

namespace Projeto.Domain.Entities
{
	public class Bike : Entity
	{
		protected Bike() { }

		public Bike(Location location)
		{
			Location = location;

			AddNotifications(location.Notifications);
		}

		public Location Location { get; private set; }
	}
}