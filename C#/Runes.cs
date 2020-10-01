/*using NUnit.Framework;
using System;  

[TestFixture]
public class RunesTest 
{
  [Test]
  public void testSample()
  {    
    Assert.AreEqual(2, Runes.solveExpression("1+1=?"), "Answer for expression '1+1=?' ");
    Assert.AreEqual(6, Runes.solveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");      
    Assert.AreEqual(0, Runes.solveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
    Assert.AreEqual(-1, Runes.solveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
    Assert.AreEqual(5, Runes.solveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
    Assert.AreEqual(2, Runes.solveExpression("?*11=??"), "Answer for expression '?*11=??' ");
    Assert.AreEqual(2, Runes.solveExpression("??*1=??"), "Answer for expression '??*1=??' ");
    Assert.AreEqual(-1, Runes.solveExpression("??+??=??"), "Answer for expression '??+??=??' ");
    
  }
}
*/

using System;
using System.Collections.Generic;
public class Runes
{
  public static int solveExpression(string expression)
  {
    string[] pts = expression.Split("=");
    
    // p1 +-* p2 = ans
    string p1 = pts[0][0].ToString(); //adds the first digit to the p1
    string op = "";
    string p2 = "";
    string ans = pts[1];
    
    //end with subtraction last, due to negative numbers. 
    if (pts[0].Contains("+")) {op = "+";}
    else if (pts[0].Contains("*")) {op = "*";}
    else 
    {
      op = "-"; //ignoring division
      bool p2Reached = false;
      for (int i = 1; i < pts[0].Length; i++)
      { //assign p1 & p2
        string c = pts[0][i].ToString();
        if (c == "-") {p2Reached = true;}
        else if (!p2Reached) {p1 += c;}
        else {p2 += c;}
      }
    } 
    if (op == "+" || op == "*") 
    { // assign p1 & p2
      string[] tmp = pts[0].Split(op);
      p1 = tmp[0];
      p2 = tmp[1];
    }
    List<string> unavailable = new List<string>();
    foreach (char c in expression) {unavailable.Add(c.ToString());}
    
    int current = 0;
    //string current = p1 + "." + op + "." + p2 + "=" + ans + "\n";
    
    try 
    {
      for (int i = 0; i < 10; i++)
      {
        //current = i;
      if (!unavailable.Contains(i.ToString())) 
      {
        /*if (i == 0 && (p1[0] == '?' || p2[0] == '?' || ans[0] == '?')) 
            {
          //do nothing
        } 
        else 
        {
          
        }*/
        int t1 = Int32.Parse(p1.Replace("?", i.ToString()));
        
        int t2 = Int32.Parse(p2.Replace("?", i.ToString()));
        int tAns = Int32.Parse(ans.Replace("?", i.ToString()));
        if (t1.ToString().Length == p1.Length && p2.ToString().Length == p2.Length && tAns.ToString().Length == ans.Length)
        {
          int testAnswer = 0;
          if (op == "+") {testAnswer = t1 + t2;}
          else if (op == "*") {testAnswer = t1 * t2;}
          else testAnswer = t1 - t2;
          if (testAnswer == tAns) {return i;}  
        }
        
        
        
        
      }
    }
    }
    catch
    {
      return current;
    }
              
    return -1; //nothing found
  }
}

