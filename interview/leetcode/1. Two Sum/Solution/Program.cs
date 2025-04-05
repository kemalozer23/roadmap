static int[] TwoSum(int[] nums, int target)
{

    var numToIndex = new Dictionary<int, int>();
    
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        
        if (numToIndex.ContainsKey(complement)) {
            return new int[] { numToIndex[complement], i };
        }
        
        numToIndex[nums[i]] = i;
    }
    
    throw new ArgumentException("No solution found");

    // (On2) algorithm:
    // loop over nums twice
    // if it hits the target return the indices
    // for (int i = 0; i < nums.Count(); i++)
    // {
    //     for (int j = 1; j < nums.Count(); j++)
    //     {
    //         var sum = nums[i] + nums[j];
    //         if (sum == target)
    //             return new int[] { i, j };
    //     }
    // }

    // throw new ArgumentException("No solution found");
}

var test1 = TwoSum(new int[] {2, 7, 11, 15}, 9);
System.Console.WriteLine($"[{test1[0]},{test1[1]}]");

var test2 = TwoSum(new int[] {3,2,4}, 6);
System.Console.WriteLine($"[{test2[0]},{test2[1]}]");

var test3 = TwoSum(new int[] {3,3}, 6);
System.Console.WriteLine($"[{test3[0]},{test3[1]}]");