using ToDo.Core.Entities;
using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories.Base;
using ToDo.Infrastructure.Repositories.Interfaces;

namespace ToDo.Infrastructure.Repositories.Implementations;

public class AuthenticationRepository(ToDoDbContext context): RepositoryBase<Authentication>(context), IAuthenticationRepository;