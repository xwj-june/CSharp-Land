#region LINQ - original Where

List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

var nums_greater_than_3 = nums.Where(n => n > 3);
foreach (var item in nums_greater_than_3)
{
    System.Console.WriteLine(item);
}
System.Console.WriteLine("------------------------------------------------");

#endregion

#region Custom LINQ - MyWhere

var filteredResult = nums.MyWhere(x => x < 2);
//nums.MyWhere(x => x < 2)
//equals to
//nums.MyWhere(delegate (int x) {return x < 2; });

foreach (var item in filteredResult)
{
    System.Console.WriteLine(item);
}

public static class CustomLinq
{
    public static List<int> MyWhere(this List<int> nums, Func<int, bool> deleg)
    {
        var nums1 = new List<int>();
        foreach (var num in nums)
        {
            if (deleg(num))
            {
                nums1.Add(num);
            }
        }
        return nums1;
    }
}
#endregion