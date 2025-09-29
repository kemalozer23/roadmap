#region Arrays and Strings
// Interview Questions

// 1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?

// Solution 1: Using a Set (Extra Data Structure)
using System.Text;

bool IsUnique1(string str)
{
    HashSet<char> seen = new();

    foreach (var c in str)
    {
        if (seen.Contains(c))
            return false;

        seen.Add(c);
    }

    return true;
}
Console.WriteLine(IsUnique1("asd"));

// Solution 2: Using Boolean Array (Only if ASCII)
bool IsUnique2(string str)
{
    if (str.Length > 128) return false;

    bool[] charSet = new bool[128];
    foreach (char c in str)
    {
        if (charSet[c])
        {
            return false;
        }
        charSet[c] = true;
    }
    return true;
}
Console.WriteLine(IsUnique2("asda"));

// Solution 3: Without Additional Data Structures
bool IsUnique3(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (str[i] == str[j])
                return false;
        }
    }
    return true;
}
Console.WriteLine(IsUnique3("asd"));

// 1.2 Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.

// Solution 1: Sort and Compare
bool CheckPermutation1(string s1, string s2)
{
    if (s1.Length != s2.Length) return false;

    var arr1 = s1.ToCharArray();
    var arr2 = s2.ToCharArray();

    Array.Sort(arr1);
    Array.Sort(arr2);

    return arr1.SequenceEqual(arr2);
}

// Solution 2: Using Dictionary (for Unicode or more flexibility)
bool CheckPermutation2(string s1, string s2)
{
    if (s1.Length != s2.Length) return false;

    Dictionary<char, int> charCounts = new();

    foreach (var c in s1)
    {
        if (!charCounts.ContainsKey(c))
            charCounts[c] = 0;

        charCounts[c]++;
    }

    foreach (var c in s2)
    {
        if (!charCounts.ContainsKey(c)) return false;
        charCounts[c]--;
        if (charCounts[c] < 0) return false;
    }

    return true;
}

// 1.3 URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string has sufficient space at the end to hold the additional characters, and that you are given the utrue" length of the string.

// Solution 1
void URLify(char[] str, int trueLength)
{
    int spaceCount = 0;

    // Count spaces within the true length
    for (int i = 0; i < trueLength; i++)
    {
        if (str[i] == ' ')
        {
            spaceCount++;
        }
    }

    int index = trueLength + spaceCount * 2;

    // If we're allowed to print the final string:
    // Console.WriteLine(new string(str, 0, index));

    // Start from the end and move characters
    for (int i = trueLength - 1; i >= 0; i--)
    {
        if (str[i] == ' ')
        {
            str[index - 1] = '0';
            str[index - 2] = '2';
            str[index - 3] = '%';
            index -= 3;
        }
        else
        {
            str[index - 1] = str[i];
            index--;
        }
    }
}

// Solution 2: if immutability is okay
string URLify2(string str, int trueLength)
{
    StringBuilder result = new();

    for (int i = 0; i < trueLength; i++)
    {
        if (str[i] == ' ')
            result.Append("%20");
        else
            result.Append(str[i]);
    }

    return result.ToString();
}

// 1.4 Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palin- drome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.

// Solution 1:
bool IsPermutationOfPalindrome(string input)
{
    Dictionary<char, int> charCounts = new Dictionary<char, int>();
    input = input.ToLower();

    foreach (char c in input)
    {
        if (c == ' ') continue;

        if (!charCounts.ContainsKey(c))
            charCounts[c] = 0;

        charCounts[c]++;
    }

    int oddCount = 0;
    foreach (var count in charCounts.Values)
    {
        if (count % 2 != 0)
        {
            oddCount++;
            if (oddCount > 1)
                return false;
        }
    }

    return true;
}

// 1.5 One Away: There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character. Given two strings, write a function to check if they are one edit (or zero edits) away.

// Solution 1:
bool OneEditAway(string first, string second)
{
    if (Math.Abs(first.Length - second.Length) > 1)
        return false;

    if (first.Length == second.Length)
        return OneEditReplace(first, second);
    else if (first.Length + 1 == second.Length)
        return OneEditInsert(first, second);
    else if (first.Length - 1 == second.Length)
        return OneEditInsert(second, first);

    return false;
}

bool OneEditReplace(string s1, string s2)
{
    bool foundDifference = false;
    for (int i = 0; i < s1.Length; i++)
    {
        if (s1[i] != s2[i])
        {
            if (foundDifference)
                return false;
            foundDifference = true;
        }
    }
    return true;
}

bool OneEditInsert(string shorter, string longer)
{
    int index1 = 0;
    int index2 = 0;
    bool foundDifference = false;

    while (index1 < shorter.Length && index2 < longer.Length)
    {
        if (shorter[index1] != longer[index2])
        {
            if (foundDifference)
                return false;
            foundDifference = true;
            index2++; // skip one char in longer string
        }
        else
        {
            index1++;
            index2++;
        }
    }
    return true;
}

// 1.6 String Compression: Implement a method to perform basic string compression using the counts of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the "compressed"string would not become smaller than the original string, your method shouId return the original string. You can assume the string has only uppercase and lowercase letters (a - z).

// Solution 1:
string CompressString(string input)
{
    if (string.IsNullOrEmpty(input)) return input;

    StringBuilder compressed = new StringBuilder();
    int count = 1;

    for (int i = 1; i < input.Length; i++)
    {
        if (input[i] == input[i - 1])
        {
            count++;
        }
        else
        {
            compressed.Append(input[i - 1]);
            compressed.Append(count);
            count = 1;
        }
    }

    // Add the last group
    compressed.Append(input[input.Length - 1]);
    compressed.Append(count);

    string result = compressed.ToString();
    return result.Length < input.Length ? result : input;
}

// 1.7 Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees. Can you do this in place?

// Solution 1:
void RotateMatrix(int[,] matrix)
{
    int n = matrix.GetLength(0); // assume it's n x n

    for (int layer = 0; layer < n / 2; layer++)
    {
        int first = layer;
        int last = n - 1 - layer;

        for (int i = first; i < last; i++)
        {
            int offset = i - first;

            // Save top
            int top = matrix[first, i];

            // Left → Top
            matrix[first, i] = matrix[last - offset, first];

            // Bottom → Left
            matrix[last - offset, first] = matrix[last, last - offset];

            // Right → Bottom
            matrix[last, last - offset] = matrix[i, last];

            // Top → Right
            matrix[i, last] = top;
        }
    }
}

// 1.8 Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
void SetZeroes(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    bool firstRowHasZero = false;
    bool firstColHasZero = false;

    // Step 1: Check first row
    for (int j = 0; j < cols; j++)
    {
        if (matrix[0, j] == 0)
        {
            firstRowHasZero = true;
            break;
        }
    }

    // Step 1: Check first column
    for (int i = 0; i < rows; i++)
    {
        if (matrix[i, 0] == 0)
        {
            firstColHasZero = true;
            break;
        }
    }

    // Step 2: Use first row and column as markers
    for (int i = 1; i < rows; i++)
    {
        for (int j = 1; j < cols; j++)
        {
            if (matrix[i, j] == 0)
            {
                matrix[i, 0] = 0;
                matrix[0, j] = 0;
            }
        }
    }

    // Step 3: Zero cells based on markers
    for (int i = 1; i < rows; i++)
    {
        for (int j = 1; j < cols; j++)
        {
            if (matrix[i, 0] == 0 || matrix[0, j] == 0)
            {
                matrix[i, j] = 0;
            }
        }
    }

    // Step 4: Zero first row
    if (firstRowHasZero)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[0, j] = 0;
        }
    }

    // Step 5: Zero first column
    if (firstColHasZero)
    {
        for (int i = 0; i < rows; i++)
        {
            matrix[i, 0] = 0;
        }
    }
}

// 1.9 StringRotation:Assumeyou haveamethod isSubstringwhichchecks ifoneword isa substring of another.Given two strings, s l and s2, write code to check if s2 is a rotation of s l using only one call to isSubstring (e.g., "waterbottle"is a rotation of"erbottlewat").

// Solution 1:
bool IsRotation(string s1, string s2)
{
    if (s1.Length != s2.Length || s1.Length == 0)
        return false;

    string combined = s1 + s1;
    return combined.Contains(s2); // using built-in substring check
}


#endregion