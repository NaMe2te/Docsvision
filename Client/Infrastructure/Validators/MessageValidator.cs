using Client.Models;

namespace Client.Infrastructure.Validators;

public static class MessageValidator
{
    public static bool ValidateTitle(string messageTitle)
    {
        return IsValidString(messageTitle);
    }

    public static bool ValidateContent(string messageContent)
    {
        return IsValidString(messageContent);
    }

    public static bool ValidateSelectedAddressee(Guid? selectedAddresseeId)
    {
        return selectedAddresseeId is not null;
    }

    private static bool IsValidString(string str) 
    {
        if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
        {
            return false;
        }

        return true;
    }
}
