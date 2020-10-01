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
