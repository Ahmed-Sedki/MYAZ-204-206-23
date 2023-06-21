//insertion at the beginning of array
int[] intArray = new int[6];

//this variable here is to keep track of the index
int length = 0;

//adding elements to the array
for (int i = 0; i < 3; i++)
{
    intArray[i] = i;
    length++;
}

//insertion at the beginning of array
for (int i = 3; i >=0; i--)
{
    intArray[i] = intArray[i+1];
}

intArray[0] = 10;

int rubbish = 9;