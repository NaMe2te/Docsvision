namespace Application.Exceptions;

public class AccountWithEmailAlreadyExistException : Exception
{
    public AccountWithEmailAlreadyExistException(string email)
        : base($"Account with email \"{email}\" already exist") { }
}