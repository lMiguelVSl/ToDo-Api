namespace ToDo.Core.Entities;

public class Authentication
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid AuthenticationToken { get; set; }
}