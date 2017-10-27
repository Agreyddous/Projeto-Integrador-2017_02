using FluentValidator;
using Projeto.Domain.ValueObjects;

namespace Projeto.Domain.Entities
{
	public class User : Entity
	{
		protected User() { }

		public User(Name name, string profilePic)
		{
			Name = name;
			ProfilePic = profilePic;

			Odometer = 0;

			new ValidationContract<User>(this)
				.IsRequired(x => x.ProfilePic, "Profile picture is required");

			AddNotifications(name.Notifications);
		}

		public Name Name { get; private set; }
		public string ProfilePic { get; private set; }
		public double Odometer { get; private set; }

		public void UpdateDistance(double distance) => Odometer += distance;
	}
}