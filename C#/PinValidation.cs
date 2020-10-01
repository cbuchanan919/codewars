using System;
using System.Text.RegularExpressions;

public class Kata
{
  public static bool ValidatePin(string pin)
  {
    //this regex will accept either 4 or 6 numeral digits
    Regex regex = new Regex(@"^\d{4}$|^\d{6}$");
    if (pin.Length == 4 || pin.Length == 6)
    { //double checks that the pin length is either 4 or 6 characters
      Match match = regex.Match(pin);
      if (match.Success)
        {
          return true;
        }
    }
    return false;
  }
}
