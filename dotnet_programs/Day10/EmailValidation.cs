using System.Text.RegularExpressions;

public class EmailValidation
{
    public static bool IsValidEmail(string email)
    {
       string pattern = @"\b[\w.-]+@[\w-]+(\.[A-Za-z]{2,})+$";
        return Regex.IsMatch(email, pattern);
    }
}
