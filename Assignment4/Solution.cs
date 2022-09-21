using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public static class Solution
    {
        public static int MaxSubarray(int[] nums)
        {
            int currsum = nums[0];
            int maxsum = nums[0];
            if (nums.Length == 1)
                return nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                currsum = Math.Max(nums[i], currsum + nums[i]);
                maxsum = Math.Max(currsum, maxsum);
            }
            return maxsum;
        }

        
        public static int FindMissing(int[]nums)
        {
            int arraysum = nums.Sum();
            int total = 0;
            for (int i = 1; i <= nums.Length+1; i++)
            {
                total = total + i;
            }
            return total - arraysum;
        }
        public static List<int> AddsGivenNumber(int[] nums, int sum)
        {
            
   
            int i = 0;
            int j = 0;
            int cur = nums[0];
            while (j< nums.Length && i<=j)
            {

                if (cur < sum)
                {
                    j++;
                    cur+=nums[j];
                }
                else if (cur > sum)
                {
                    cur = cur - nums[i];
                    i++;
                }
                else
                {
                    var result = new List<int> { i,j};
                    return result;
                }      
            }
            return new List<int>();
        }

        //may negative print any of them
        public static List<int> AddGivenNumber2(int[] nums, int sum)
        {
            int cur = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                cur += nums[i];
                int diff = cur - sum;
                if (!map.ContainsKey(diff))
                {
                    if (!map.ContainsKey(sum))
                        map.Add(cur, i);
                }
                else
                {
                    var result = new List<int> { i, map[diff] +1 };
                    return result;
                }
            }
            return new List<int>();
        }

        //5. Write a program to sort an array of 0's,1's and 2's in ascending order.
        public static void SortThreeNumberArray(int[] nums)
        {
            int curr = 0;
            int r = nums.Length - 1;
            int l = 0;
            while (curr <= r)
            {

                if (nums[curr] == 1)
                {
                    curr++;
                }
                else if (nums[curr] == 0)
                {
                    Swap(nums, curr, l);
                    l++;
                    curr++;
                }
                else
                {
                    Swap(nums, r, curr);
                    r--;
                }
            }

        }

        public static int FindEqualIndex(int[]nums)
        {
            int n = nums.Length;
            int sum = nums.Sum();
            int sumleft = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum-nums[i];
                if (sumleft == sum)
                    return i;
                else
                    sumleft = sumleft + nums[i];
            }
            return -1;
        }

        public static int KSmallest(int[]arr, int k)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int> ();
            foreach(int i in arr)
            {
                pq.Enqueue(i, -i);
                if (pq.Count > k)
                    pq.Dequeue();
            }
            return pq.Peek();
        }
        public static int[] SpiralOrder(int[][] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix[0].Length;
            //initiate boundaries
            int up = 0;
            int down = rows - 1;
            int left = 0;
            int right = columns - 1;
            int[] result = new int[rows*columns];
            int i = 0;

            while( i< rows*columns)
            {
                //traverse from left to right
                for( int col = left; col<= right; col++)
                {
                    result[i] = matrix[up][col];
                    i++;
                }
                //traverse up -> down
                for ( int row = up+1; row<= down; row++)
                {
                    result[i] = matrix[row][right];
                    i++;
                }

                //makesure in diff row/
                if(up != down)
                {
                    //traverse right -> left
                    for (int col = right - 1; col>= left; col--)
                    {
                        result[i] = matrix[down][col];
                        i++;
                    }
                }
                //make sure in diff column
                if (left != right)
                {
                    //traverse down -> up
                    for(int row = down-1; row > up; row--)
                    {
                        result[i] = matrix[row][left];
                        i++;
                    }    
                }
                left++;
                right--;
                up++;
                down--;
            }
            return result;
            
        }

        public static int[] SortedbyFrenquency(int[] nums)
        {
            //put element and frequency into dictionary
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach( var num in nums)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]+=1;
            }

            //put element in dic into maxheap
            PriorityQueue<KeyValuePair<int, int>, int> maxHeap = new PriorityQueue<KeyValuePair<int, int>, int>();
            foreach(var d in dic)
            {
                maxHeap.Enqueue(d, -d.Value);
            }
            int heapcount = maxHeap.Count;  
            int count = 0;
            for( int i = 0; i<heapcount; i++)
            {
                KeyValuePair<int, int> k = maxHeap.Dequeue();
                nums[count] = k.Key;
                count++;
                if ( k.Value>1)
                {
                    for(int j = 1; j<k.Value; j++)
                    {
                        nums[count] = k.Key;
                        count++;
                    }
                }                
            }
            return nums;

        }

        private static void Swap(int[]nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

    }
}
