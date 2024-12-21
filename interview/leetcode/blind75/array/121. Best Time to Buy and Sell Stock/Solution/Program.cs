static int MaxProfit(int[] prices) {

    // my solution
    var minPrice = prices[0];
    var maxProfit = 0;

    for (int i = 1; i < prices.Length; i++)
    {
        if (prices[i] - minPrice > maxProfit)
        {
            maxProfit = prices[i] - minPrice;
        }

        if (prices[i] < minPrice)
        {
            minPrice = prices[i];
        }
    }

    return maxProfit;

    // O(n^2) brute force
    // var maxProfit = 0;
    // for (var i = 0; i < prices.Length; i++)
    // {
    //     for (var j = i + 1; j < prices.Length; j++)
    //     {
    //         var buy = prices[i];
    //         var sell = prices[j];
            
    //         if (sell - buy > maxProfit)
    //         {
    //             maxProfit = sell - buy;
    //         }
    //     }
    // }

    // return maxProfit;

    // gtp
    // if (prices.Length == 0) return 0;

    // int minPrice = int.MaxValue;
    // int maxProfit = 0;

    // foreach (int price in prices) {
    //     if (price < minPrice) {
    //         minPrice = price; // Update the minimum price.
    //     } else {
    //         maxProfit = Math.Max(maxProfit, price - minPrice); // Calculate the profit and update the maxProfit.
    //     }
    // }

    // return maxProfit;
}

System.Console.WriteLine(MaxProfit([7,1,5,3,6,4]));
System.Console.WriteLine(MaxProfit([7,6,4,3,1]));