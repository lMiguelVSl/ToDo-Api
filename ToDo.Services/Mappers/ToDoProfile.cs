using AutoMapper;
using ToDo.Core.Models;
using ToDo.Core.Models.Requests;
using ToDo.Core.Models.Responses;

namespace ToDo.Services.Mappers;

public class ToDoProfile: Profile
{
    public ToDoProfile()
    {
        CreateMap<ToDoRequest, Core.Entities.ToDo>().ReverseMap();
        CreateMap<ToDoResponse, Core.Entities.ToDo>().ReverseMap();
        CreateMap<ToDoBase, Core.Entities.ToDo>().ReverseMap();
        CreateMap<ToDoCreateRequest, Core.Entities.ToDo>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
    }
}