//The following are examples of my work, proceeded by instructions from the code wars website.


/*
Instructions:
Complete the method/function so that it converts dash/underscore delimited words into camel casing. The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case).

Examples
toCamelCase("the-stealth-warrior") // returns "theStealthWarrior"
toCamelCase("The_Stealth_Warrior") // returns "TheStealthWarrior"
*/

/*
Tests:
Test.assertEquals(toCamelCase(''), '', "An empty string was provided but not returned")
Test.assertEquals(toCamelCase("the_stealth_warrior"), "theStealthWarrior", "toCamelCase('the_stealth_warrior') did not return correct value")
Test.assertEquals(toCamelCase("The-Stealth-Warrior"), "TheStealthWarrior", "toCamelCase('The-Stealth-Warrior') did not return correct value")
Test.assertEquals(toCamelCase("A-B-C"), "ABC", "toCamelCase('A-B-C') did not return correct value")
*/

function toCamelCase(str){
    var result = "";
    for (var i = 0; i < str.length; i++){
      if (str[i] == "-" || str[i] == "_") {
        i++;
        result += str[i].toUpperCase();
      } else {
        result += str[i];
      }
      
    }
    return result;
  }



  
/*
Instructions:
Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, 
which is the number of times you must multiply the digits in num until you reach a single digit.

For example:

 persistence(39) === 3 // because 3*9 = 27, 2*7 = 14, 1*4=4
                       // and 4 has only one digit

 persistence(999) === 4 // because 9*9*9 = 729, 7*2*9 = 126,
                        // 1*2*6 = 12, and finally 1*2 = 2

 persistence(4) === 0 // because 4 is already a one-digit number
 */

 
 function persistence(num) {
    var numStr = num.toString();
    var count = 0;
    while (numStr.length > 1) {
      var current = 1;
      for (var i = 0; i < numStr.length; i++) {
        current *= parseInt(numStr[i]);
      }
      numStr = current.toString();
      count++;
    }
    return count;
  }

  



/* Instructions:
Well met with Fibonacci bigger brother, AKA Tribonacci.

As the name may already reveal, it works basically like a Fibonacci, but summing the last 3 (instead of 2) numbers of the sequence to generate the next. And, worse part of it, regrettably I won't get to hear non-native Italian speakers trying to pronounce it :(

So, if we are to start our Tribonacci sequence with [1, 1, 1] as a starting input (AKA signature), we have this sequence:

[1, 1 ,1, 3, 5, 9, 17, 31, ...]
But what if we started with [0, 0, 1] as a signature? As starting with [0, 1] instead of [1, 1] basically shifts the common Fibonacci sequence by once place, you may be tempted to think that we would get the same sequence shifted by 2 places, but that is not the case and we would get:

[0, 0, 1, 1, 2, 4, 7, 13, 24, ...]
Well, you may have guessed it by now, but to be clear: you need to create a fibonacci function that given a signature array/list, returns the first n elements - signature included of the so seeded sequence.

Signature will always contain 3 numbers; n will always be a non-negative number; if n == 0, then return an empty array (except in C return NULL) and be ready for anything else which is not clearly specified ;)

If you enjoyed this kata more advanced and generalized version of it can be found in the Xbonacci kata

[Personal thanks to Professor Jim Fowler on Coursera for his awesome classes that I really recommend to any math enthusiast and for showing me this mathematical curiosity too with his usual contagious passion :)]

*/

/*Testing:
Test.describe("Basic tests",function(){
Test.assertSimilar(tribonacci([1,1,1],10),[1,1,1,3,5,9,17,31,57,105])
Test.assertSimilar(tribonacci([0,0,1],10),[0,0,1,1,2,4,7,13,24,44])
Test.assertSimilar(tribonacci([0,1,1],10),[0,1,1,2,4,7,13,24,44,81])
Test.assertSimilar(tribonacci([1,0,0],10),[1,0,0,1,1,2,4,7,13,24])
Test.assertSimilar(tribonacci([0,0,0],10),[0,0,0,0,0,0,0,0,0,0])
Test.assertSimilar(tribonacci([1,2,3],10),[1,2,3,6,11,20,37,68,125,230])
Test.assertSimilar(tribonacci([3,2,1],10),[3,2,1,6,9,16,31,56,103,190])
Test.assertSimilar(tribonacci([1,1,1],1),[1])
Test.assertSimilar(tribonacci([300,200,100],0),[])
Test.assertSimilar(tribonacci([0.5,0.5,0.5],30),[0.5,0.5,0.5,1.5,2.5,4.5,8.5,15.5,28.5,52.5,96.5,177.5,326.5,600.5,1104.5,2031.5,3736.5,6872.5,12640.5,23249.5,42762.5,78652.5,144664.5,266079.5,489396.5,900140.5,1655616.5,3045153.5,5600910.5,10301680.5])
})
*/



function tribonacci(signature,n){
    var result = [];
    var i;
    for (i = 0; i < n; i++){
      var len = result.length;
      if (len <= 2) {
        //base of signature, just add to n
        result.push(signature[i]);
        } else {
        // start adding
        var sum = result[len - 1] + result[len - 2] + result[len - 3];
        result.push(sum);
      }
    }
    return result;
  }
  
  


  /*Implement the function unique_in_order which takes as argument a sequence and returns a list of items without any elements with the same value next to each other and preserving the original order of elements.

For example:

uniqueInOrder('AAAABBBCCDAABBB') == ['A', 'B', 'C', 'D', 'A', 'B']
uniqueInOrder('ABBCcAD')         == ['A', 'B', 'C', 'c', 'A', 'D']
uniqueInOrder([1,2,2,3,3])       == [1,2,3]*/

var uniqueInOrder=function(iterable){
    let newA = []; //array to return
    let i = 0;
    let lastLetter = ""; //last letter added to array
    for (i = 0; i < iterable.length; i++)
      {
        if (lastLetter != iterable[i])
          {
            let L = iterable[i];
            lastLetter = L;          
            newA.push(L);
          }
        
      }
    return newA;
  }
  