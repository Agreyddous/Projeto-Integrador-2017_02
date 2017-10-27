using FluentValidator;
using System;

namespace Projeto.Domain.Entities
{
	public class Entity : Notifiable
	{
		public Entity() => Id = Guid.NewGuid();

		public Guid Id { get; private set; }
	}
}