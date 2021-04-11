using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class Kata
{
    /// <summary>
    /// The goal of this exercise is to convert a string to a new string where each character in the new string is "(" if that character appears only once in the original string, or ")"
    /// if that character appears more than once in the original string. Ignore capitalization when determining if a character is a duplicate.
    /// Examples
    /// "din"      =>  "((("
    /// "recede"   =>  "()()()"
    /// "Success"  =>  ")())())"
    /// "(( @"     =>  "))(("
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
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
                    count++;
                }
            }
            result += count > 1 ? ')' : '('; // if count > 1, add ), otherwise add (

        }
        return result;
    }
}





public class Kata
{
    /// <summary>
    /// Verifies if the given string is 4 or 6 digits.
    /// </summary>
    /// <param name="pin"></param>
    /// <returns></returns>
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



public class Runes
{
    /// <summary>
    /// Returns the correct numeral for question marks in equation strings. ('123*45?=5?088' returns 6), or ('-5?*-1=5?' returns 0) Returns -1 if no match found
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static int solveExpression(string expression)
    {
        /*
            1+1=?           (2)
            123*45?=5?088   (6)
            -5?*-1=5?       (0)
            19--45=5?       (-1, no answer found)
            ??*??=302?      (5)
            ?*11=??         (2)
        */
        string[] pts = expression.Split("=");

        // p1 +-* p2 = ans
        string p1 = pts[0][0].ToString(); //adds the first digit to the p1
        string op = ""; //operator
        string p2 = ""; //second part
        string ans = pts[1];

        //discovering operator. end with subtraction last, due to negative numbers. 
        if (pts[0].Contains("+")) { op = "+"; }
        else if (pts[0].Contains("*")) { op = "*"; }
        else
        {
            op = "-"; //ignoring division
            bool p2Reached = false;
            for (int i = 1; i < pts[0].Length; i++)
            { //assign p1 & p2
                string c = pts[0][i].ToString();
                if (c == "-" && !p2Reached) { p2Reached = true; }
                else if (!p2Reached) { p1 += c; }
                else { p2 += c; }
            }
        }

        if (op == "+" || op == "*")
        { // assign p1 & p2
            string[] tmp = pts[0].Split(op);
            p1 = tmp[0];
            p2 = tmp[1];
        }

        List<string> unavailable = new List<string>();
        foreach (char c in expression) { unavailable.Add(c.ToString()); }

        for (int i = 0; i < 10; i++)
        {
            if (!unavailable.Contains(i.ToString()))
            {
                int tryP1 = Int32.Parse(p1.Replace("?", i.ToString()));

                int tryP2 = Int32.Parse(p2.Replace("?", i.ToString()));
                int tryAns = Int32.Parse(ans.Replace("?", i.ToString()));
                if (tryP1.ToString().Length == p1.Length && tryP2.ToString().Length == p2.Length && tryAns.ToString().Length == ans.Length)
                {
                    int testAnswer = 0;
                    if (op == "+") { testAnswer = tryP1 + tryP2; }
                    else if (op == "*") { testAnswer = tryP1 * tryP2; }
                    else testAnswer = tryP1 - tryP2;
                    if (testAnswer == tryAns) { return i; }
                }

            }
        }
        return -1; //nothing found

    }
}

public class Kata
{
    /// <summary>
    /// You live in the city of Cartesia where all roads are laid out in a perfect grid. You arrived ten minutes too early to an appointment, so you decided to take the opportunity to go for a short walk. 
    /// The city provides its citizens with a Walk Generating App on their phones -- everytime you press the button it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']). 
    /// You always walk only a single block for each letter (direction) and you know it takes you one minute to traverse one city block, so create a function that will return true if the walk the app gives you will take you exactly ten minutes 
    /// (you don't want to be early or late!) and will, of course, return you to your starting point. Return false otherwise.
    /// Note: you will always receive a valid array containing a random assortment of direction letters ('n', 's', 'e', or 'w' only). It will never give you an empty array (that's not a walk, that's standing still!).
    /// </summary>
    /// <param name="walk"></param>
    /// <returns></returns>
    public static bool IsValidWalk(string[] walk)
    {

        if (walk.Length != 10)
        {
            return false;
        }
        else
        {
            int ew = 0;
            int ns = 0;
            for (int i = 0; i < walk.Length; i++)
            {
                switch (walk[i])
                {
                    case "n":
                        ns += 1;
                        break;

                    case "s":
                        ns -= 1;
                        break;

                    case "e":
                        ew += 1;
                        break;

                    case "w":
                        ew -= 1;
                        break;
                }
            }
            if (ew == 0 && ns == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
