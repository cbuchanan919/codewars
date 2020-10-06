using System;
using System.Collections.Generic;
public class Josephus
    {
        public static List<object> JosephusPermutation(List<object> items, int k)
        {
            int curIndex = 0;
            int kIndex = 0;
            int tries = 0;
            List<object> Result = new List<object>();
            while (items.Count > 0 && tries < 1000)
            {
                if (kIndex == k - 1)
                {   // add to result
                    Result.Add(items[curIndex]);
                    //Console.WriteLine("kIndex: " + kIndex.ToString() + " curIndex: " + curIndex.ToString() + " maxIndex: " + (items.Count - 1).ToString() + " item: " + items[curIndex].ToString());
                    items.RemoveAt(curIndex);
                    //don't add to the current index since one was removed
                    kIndex = 0;
                }
                else
                {
                    kIndex++;
                    curIndex++;
                }
                if (curIndex > items.Count - 1)
                {
                    curIndex = 0;
                }
                tries++;
            }
            return Result;
        }
    }
    
    
    /*
//Testing:
using NUnit.Framework;
using System;
using System.Collections.Generic;
public class JosephusTestSample
{

    [Test]
    public void Test1()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    }

    [Test]
    public void Test2()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new object[] { 2, 4, 6, 8, 10, 3, 7, 1, 9, 5 });
    }

    [Test]
    public void Test3()
    {
        JosephusTest(new object[] { "C", "o", "d", "e", "W", "a", "r", "s" }, 4, new object[] { "e", "s", "W", "o", "C", "d", "r", "a" });
    }

    [Test]
    public void Test4()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new object[] { 3, 6, 2, 7, 5, 1, 4 });
    }

    [Test]
    public void Test5()
    {
        JosephusTest(new object[] { }, 3, new object[] { });
    }

    private void JosephusTest(object[] items, int k, object[] result)
    {
        Assert.AreEqual(new List<object>(result), Josephus.JosephusPermutation(new List<object>(items), k));
    }
}
    */
    
    
    /*
    Instructions:
    
    This problem takes its name by arguably the most important event in the life of the ancient historian Josephus: 
    according to his tale, he and his 40 soldiers were trapped in a cave by the Romans during a siege.

Refusing to surrender to the enemy, they instead opted for mass suicide, with a twist: they formed a circle and proceeded to kill one man every three, 
until one last man was left (and that it was supposed to kill himself to end the act).

Well, Josephus and another man were the last two and, as we now know every detail of the story, 
you may have correctly guessed that they didn't exactly follow through the original idea.

You are now to create a function that returns a Josephus permutation, 
taking as parameters the initial array/list of items to be permuted as if they were in a circle and counted out every k places until none remained.

Tips and notes: it helps to start counting from 1 up to n, instead of the usual range 0..n-1; k will always be >=1.

For example, with n=7 and k=3 josephus(7,3) should act this way.

[1,2,3,4,5,6,7] - initial sequence
[1,2,4,5,6,7] => 3 is counted out and goes into the result [3]
[1,2,4,5,7] => 6 is counted out and goes into the result [3,6]
[1,4,5,7] => 2 is counted out and goes into the result [3,6,2]
[1,4,5] => 7 is counted out and goes into the result [3,6,2,7]
[1,4] => 5 is counted out and goes into the result [3,6,2,7,5]
[4] => 1 is counted out and goes into the result [3,6,2,7,5,1]
[] => 4 is counted out and goes into the result [3,6,2,7,5,1,4]
So our final result is:

josephus([1,2,3,4,5,6,7],3)==[3,6,2,7,5,1,4]
    */
    
