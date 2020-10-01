/*
The goal of this exercise is to convert a string to a new string where each character in the new string is "(" if that character appears only once in the original string, or ")"
if that character appears more than once in the original string. Ignore capitalization when determining if a character is a duplicate.

Examples
"din"      =>  "((("
"recede"   =>  "()()()"
"Success"  =>  ")())())"
"(( @"     =>  "))(("
*/
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
