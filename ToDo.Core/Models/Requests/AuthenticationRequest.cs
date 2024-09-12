using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Models.Requests;

public class AuthenticationRequest
{
    [Required] public string UserName { get; set; } = string.Empty;
}