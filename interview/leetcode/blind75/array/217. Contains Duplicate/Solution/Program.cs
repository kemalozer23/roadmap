static bool ContainsDuplicate(int[] nums) {
    
    // my solution -> O(n) space O(n) space
    var hashMap = new Dictionary<int, int>();

    for (var i = 0; i < nums.Length; i++)
    {
        if (hashMap.ContainsKey(nums[i]))
        {
            return true;
        }
        else
        {
            hashMap.Add(nums[i], i);
        }
    }

    return false;

    // gpt -> O(n) time O(n) space
    // var seen = new HashSet<int>();

    // foreach (int num in nums) {
    //     if (seen.Contains(num)) {
    //         return true; // Duplicate found.
    //     }
    //     seen.Add(num); // Add the number to the set.
    // }

    // return false;

    // gpt -> O(nlogn) time O(1) space
    // Array.Sort(nums); // Sort the array.
    
    // for (int i = 1; i < nums.Length; i++) {
    //     if (nums[i] == nums[i - 1]) {
    //         return true; // Duplicate found.
    //     }
    // }

    // return false;
}

System.Console.WriteLine(ContainsDuplicate([1,2,3,1]));
System.Console.WriteLine(ContainsDuplicate([1,2,3,4]));
System.Console.WriteLine(ContainsDuplicate([1,1,1,3,3,4,3,2,4,2]));