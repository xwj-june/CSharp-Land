#region anonymous method with Action

Action<string> action_has_prams = delegate (string name)
{
    Console.WriteLine($"I am {name}");
};
action_has_prams("June");

#endregion

#region anonymous method with Func

Func<int, int, int> func_has_prams = delegate (int a, int b)
{
    return a + b;
};
var f1 = func_has_prams(1, 2);

//anonymous method to Lambda
Func<int, int, int> func_lambda = (int a, int b) =>
{
    return a + b;
};

//anonymous method to Lambda - simplified 1
//when method body only have one line
Func<int, int, int> func_lambda_1 = (int a, int b) => a + b;

//anonymous method to Lambda - simplified 2
//simplified param types which can be determined by .NET in compile time
Func<int, int, int> func_lambda_2 = (a, b) => a + b;

//anonymous method to Lambda - simplified 3
//when there is only one parameter
Func<int, int> func_lambda_one = (int a) =>
{
    return a + 1;
};

Func<int, int> func_lambda_one_1 = a => a + 1;

#endregion