using Microsoft.EntityFrameworkCore;
using ToDo.Core.Persistence;
using ToDo.Infrastructure.Repositories.Base;
using Models = ToDo.Core.Models;

namespace ToDo.Infrastructure.Repositories.Custom;

public class ToDoRepository(DbContext context) : RepositoryBase<Models.ToDo>(context), IToDoRepository;