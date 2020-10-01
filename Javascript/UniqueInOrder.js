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
