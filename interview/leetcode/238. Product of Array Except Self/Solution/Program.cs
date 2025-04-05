static int[] ProductExceptSelf(int[] nums) {
    
    int n = nums.Length;
    int[] result = new int[n];

    result[0] = 1;
    for (int i = 1; i < n; i++) 
        result[i] = result[i - 1] * nums[i - 1];

    int rightProduct = 1;
    for (int i = n - 1; i >= 0; i--) 
    {
        result[i] *= rightProduct;
        rightProduct *= nums[i];
    }

    return result;
}

System.Console.WriteLine(string.Join(",", ProductExceptSelf([1,2,3,4])));
System.Console.WriteLine(string.Join(",", ProductExceptSelf([-1,1,0,-3,3])));