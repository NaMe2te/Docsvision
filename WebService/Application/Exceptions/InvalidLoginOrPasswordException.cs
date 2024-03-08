namespace Application.Exceptions;

public class InvalidLoginOrPasswordException : Exception
{
    public InvalidLoginOrPasswordException()
        : base("Invalid username or password") { }
}