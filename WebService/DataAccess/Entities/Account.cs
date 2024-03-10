namespace DataAccess.Entities;

public class Account
{
    public Account(string email, string password)
    {
        Email = email;
        Password = password;
    }

    protected Account() { }

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}