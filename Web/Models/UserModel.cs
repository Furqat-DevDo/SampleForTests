using System.Text.Json;

namespace Web.Models;
public record UserModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public dynamic PersonalData { get; set; } = null!;
}