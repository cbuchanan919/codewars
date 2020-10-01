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
    string op = ""; //operator
    string p2 = ""; //second part
    string ans = pts[1];
    
    //discovering operator. end with subtraction last, due to negative numbers. 
    if (pts[0].Contains("+")) {op = "+";}
    else if (pts[0].Contains("*")) {op = "*";}
    else 
    {
      op = "-"; //ignoring division
      bool p2Reached = false;
      for (int i = 1; i < pts[0].Length; i++)
      { //assign p1 & p2
        string c = pts[0][i].ToString();
        if (c == "-" && !p2Reached) {p2Reached = true;}
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
            if (op == "+") {testAnswer = tryP1 + tryP2;}
            else if (op == "*") {testAnswer = tryP1 * tryP2;}
            else testAnswer = tryP1 - tryP2;
            if (testAnswer == tryAns) {return i;}  
          }
          
        }
      }     
      return -1; //nothing found
    
  }
}
