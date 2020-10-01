public class Kata
{
  public static string DuplicateEncode(string word)
  {
    word = word.ToLower();
    string result = "";
    for (int i = 0; i < word.Length; i++)
    {
      int count = 0;
      foreach (char c in word)
      {
        if (c == word[i])
        {
          count ++;
        }
      }
      result += count > 1 ? ')' : '('; // if count > 1, add ), otherwise add (
     
    }
    return result;
  }
}
