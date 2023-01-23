# SuperPrimeFinder
An algorithm that can find all the primes on the positive number line. What fun!

TODO - Duplicate program and data structures in C++ and run parallel on GPU

Here's how it works, super simplified -

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
INPUT CONDITIONS

List int setA = {2} (We can call this the Continuous Number Line)
List int setB = {2}
List int setC = {2} (We can call this All Generated Numbers)
List int Primes
int small = 2
int lastContinuousNumber = 2
int ceiling = { lastContinuousNumber * 2 }
  

RUN  
  foreach(a in setA)
    foreach(b in setB)
      p = a * b
      setC.AddUnique(p)
  
  int lastC = lastContinuousNumber
  foreach(c in setC.Where(i => i > lastContinuousNumber && i <= ceiling))
    int possiblePrime = c-1
    if(possiblePrime != lastC)
      Primes.Add(possiblePrime)
      setC.Insert(possiblePrime)
    lastC = c
  
  small = lastContinuousNumber + 1
  lastContinuousNumber = Last member of setC where the next number is that number +1
  setA = setC.Where(i=> i >=2 && i <= lastContinuousNumber)
  setB = setC.Where(i=> i >= small)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
  
What we're doing -
  1. Beginning with 3 sets of numbers which can increase over time, starting them all at 2, which is the first number that can be multiplied to generate a new number
  2. We multiply all members within 2 of the sets, adding the generated numbers to the third set, which holds all our numbers
  3. We loop over the third set, constrained to the Ceiling and find any case where the number -1 does not equal the last listed number. This number is a Prime Number, guaranteed, as all the numbers surrounding it have been factored
  4. Those numbers are inserted where they belong in the third set
  5. The new Last Continuous Number is determined
  6. The first set has numbers up to and including the Last Continuous Number added to it
  7. The second set has all the numbers greater than and equal to the Previous Smallest Generated Number added to it
  8. The Previous Smallest Generated Number is set to the new smallest generated number
  9. The loop is run again
  
What this does -
  1. Generates expanding batches of numbers using a 'natural birthing' logarithm that builds off all previous iterations
  2. Using the Last Continuous Number * 2 as a constraint, one can then iterate through the factored numbers and 'weed out' any skipped numbers smaller than that ceiling
  3. Those weeded out numbers are all numbers that cannot be defined by multiplying any combination of numbers smaller than them, which is the definition of a Prime
  4. Each iteration expands the sets of numbers used, generating more and more complex numbers in the same way I suppose the universe might do so
  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
First Iteration Example -
  CONDITIONS
    setA = {2}
    setB = {2}
    setC = {2}
    small = 2
    lastContinuousNumber = 2
    ceiling = 4
  
  RUNNING
    Double Loop
      2 * 2 = 4
      setC.Add(4) , setC{2,4}
      
    Prime Finding Loop
      lastC = 2
      c = 4
      p = 3 (c-1)
      p != lastC (true)
      Primes.Add(p)
      setC.Insert(p)
      
    Setting Next Batch Conditions
      small = 3 (2(the lastContinuousNumber)+1)
      lastContinuousNumber = 4
      setA = {2,3,4} (2 to lastContinuousNumber)
      setB = {3,4} (small and up)
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Using the batches generated by this algorithm, a few conclusions can be drawn.
  1. As the number of Numbers defined in each batch increases exponentially, it can be deduced that there are an infinite number of Regular Numbers
  2. As the number of Primes defined in each batch increases, it can be deduced that there are an infinite number of Prime Numbers
  3. As the number of Twin Primes remains fixed or increases with each batch, it can be deduced that there are an **infinite number of Twin Primes

Included is a file titled SuperPrimeFinder_Results.txt, with the first 1600ish Prime Numbers defined using this method. The batches are listed out, and all the numbers have their Factorization at the bottom as proof
