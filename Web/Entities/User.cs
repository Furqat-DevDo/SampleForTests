using System.Text.Json;

namespace Web.Entities;
public class User
{
    public int Id { get; set;}
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public JsonDocument PersonalData { get; set; } = null!;
}