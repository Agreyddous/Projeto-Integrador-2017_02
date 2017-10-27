using Projeto.Domain.Entities;
using System;

namespace Projeto.Domain.Repositories
{
	public interface IUserRepository
	{
		User Get(Guid userId);
		bool Add(User user);
		bool UpdateDistance(User user);
	}
}