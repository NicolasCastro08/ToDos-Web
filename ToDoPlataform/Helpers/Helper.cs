using System.Net.Mail;

namespace ToDoPlataform.Helpers;

public class Helper
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            MailAddress mail = new(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
