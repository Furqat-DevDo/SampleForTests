namespace Web.Models;
public class UserCreateModel
{
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public dynamic PersonalData { get; set; } = null!;
}
