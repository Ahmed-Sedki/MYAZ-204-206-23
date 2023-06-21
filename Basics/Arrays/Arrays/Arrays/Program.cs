//insertion at the end of the array O(1)

using System;

int[] intArray = new int[6];

//this variable here is to keep track of the index
int length = 0;

//adding elements to the array
for (int i = 0; i < 3; i++)
{
    intArray[i] = i;
    length++;
}

intArray[length] = 10;
length++;

