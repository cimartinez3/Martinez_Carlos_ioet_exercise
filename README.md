# Martinez Carlos IOET exercise

For the development of this exercise I used C# as language and .NET 5.0 with Visual Studio 2019. 

## Solution

My solution consists in 3 steps:

1. Read the data from file "inputs.txt" and save it in a string array.
2. Work with each element from the string array and split it to get the name and the schedule worked. Then from each shcedule I split it to get the days, the init hours and end hours.
3. Finally calculate the payment from each interval and add each payment from every single worker.

## Architecture

I used was N-Tier Architecture:

1. Data tier: Here I read the file and return the string array
2. Logic Tier: Here I calculate the payments 
3. Presentation Layer: Here I ask for the payments from logic tier and show it in a console aplication. 

## Methodology

To solve this exercise I used the "Divide and conquer" method. It means to take a big problem and divide it in a group o small problems to solve each one separately. So as I explained in the solution field, I divided it in 3 sub-problems: take data, split data and calculate the payments. 


## How to run it

You can open "MartínezCarlos_Ioet_exercise.sln" with Visual Studio and run it

or

You can go to: "you_download_direcotry"\MartínezCarlos_Ioet_exercise\MartínezCarlos_Ioet_exercise\bin\Debug\net5.0
```bash
run "MartínezCarlos_Ioet_exercise.exe"
