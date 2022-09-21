// See https://aka.ms/new-console-template for more information
using Assignment4;
using System;

//int[][] b = new int[3][];
//b[0] = new int[3];
//b[1] = new int[3];
//b[2] = new int[3];
//int i = 1;
//for(int r = 0; r<3; r++)
//{
//    for (int c = 0; c<3; c++)
//    {
//        b[r][c] = i;
//        Console.Write(i + " ");
//        i++;
//    }
//    Console.Write("\n");
//}


////int[] nums = { 7,10,4,3,20,15};
//var a = Solution.SpiralOrder(b);
//foreach ( var f in a)
//    Console.Write(f + " ");
//Console.WriteLine(a);

int[] a = { 2, 5,2,6,-1,9999,5,8,8,8 };
int[] b = Solution.SortedbyFrenquency(a);
foreach (int i in b)
    Console.Write(i + ", ");
Console.Read();
