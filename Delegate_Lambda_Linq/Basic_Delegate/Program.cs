#region define methods

void PrintMethod()
{
    Console.WriteLine("Print method is called");
}
void PrintPassedData(string a, string b)
{
    Console.WriteLine($"Print a: {a}  b: {b}");
}

int ReturnZero()
{
    Console.WriteLine("Return 0");
    return 0;
}
int SumMethod(int i, int j)
{
    Console.WriteLine($"Return {i} + {j} = {i + j}");
    return i + j;
}

#endregion

#region invoking delegate

SimpleDelegate_No_Params_No_Return s1 = PrintMethod;
s1();

SimpleDelegate_Has_Params_No_Return s2 = PrintPassedData;
s2("abc", "123");

SimpleDelegate_No_Params_Has_Return_Zero s3 = ReturnZero;
s3();

SimpleDelegate_Has_Params_Has_Return_Sum s4 = SumMethod;
s4(1, 2);

#endregion

#region define and invoke C# pre-defined delegate methods

//C# pre-defined delegate method - Action - do not return value
Action SimpleActionDelegate = PrintMethod;
SimpleActionDelegate.Invoke();

Action<string, string> ActionDelegate_Has_Params = PrintPassedData;
ActionDelegate_Has_Params.Invoke("abc", "123");

//C# pre-defined delegate method - Func - must return value
Func<int> SimpleFuncDelegate = ReturnZero;
SimpleFuncDelegate.Invoke();

Func<int, int, int> FuncDelegate_Has_Params = SumMethod;
FuncDelegate_Has_Params.Invoke(1, 2);

#endregion

#region define basic delegates
delegate void SimpleDelegate_No_Params_No_Return();
delegate int SimpleDelegate_No_Params_Has_Return_Zero();
delegate void SimpleDelegate_Has_Params_No_Return(string i, string j);
delegate int SimpleDelegate_Has_Params_Has_Return_Sum(int i, int j);
#endregion

