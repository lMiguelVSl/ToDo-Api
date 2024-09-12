using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Entities;

public class Authentication
{
    public int Id { get; set; }
    [StringLength(20)]
    public string UserName { get; set; } = string.Empty;
    public string AuthenticationToken { get; set; } = string.Empty;
}