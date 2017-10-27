using FluentValidator;

namespace Projeto.Domain.ValueObjects
{
	public class Name : Notifiable
	{
		protected Name() { }

		public Name(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;

			new ValidationContract<Name>(this)
				.IsRequired(x => x.FirstName, "First Name is required").HasMaxLenght(x => x.FirstName, 15, "First Name max length exceeded").HasMinLenght(x => x.FirstName, 3, "First Name is too short")
				.IsRequired(x => x.LastName, "Last Name is required").HasMaxLenght(x => x.LastName, 15, "Last Name max length exceeded").HasMinLenght(x => x.LastName, 3, "Last Name is too short");
		}

		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		public override string ToString() => FirstName + " " + LastName;
	}
}