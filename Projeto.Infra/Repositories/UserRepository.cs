using Projeto.Domain.Repositories;
using System;
using System.Linq;
using Projeto.Domain.Entities;
using Projeto.Infra.Context;
using System.Data.Entity;

namespace Projeto.Infra.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ProjetoContext _context;

		public UserRepository(ProjetoContext context) => _context = context;

		public bool Add(User user)
		{
			if (user.IsValid())
				_context.Users.Add(user);

			return user.IsValid();
		}

		public User Get(Guid userId) => _context.Users.FirstOrDefault(x => x.Id == userId);
		public bool UpdateDistance(User user)
		{
			if (user.IsValid())
				_context.Entry(user).State = EntityState.Modified;

			return user.IsValid();
		}
	}
}