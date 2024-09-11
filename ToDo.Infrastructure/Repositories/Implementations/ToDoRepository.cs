using ToDo.Infrastructure.Persistence;
using ToDo.Infrastructure.Repositories.Base;
using ToDo.Infrastructure.Repositories.Interfaces;
using Entities_ToDo = ToDo.Core.Entities.ToDo;

namespace ToDo.Infrastructure.Repositories.Implementations;

public class ToDoRepository(ToDoDbContext context) : RepositoryBase<Entities_ToDo>(context), IToDoRepository;