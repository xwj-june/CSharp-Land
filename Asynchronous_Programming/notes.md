# Asynchronous Programming

## Benefit

Improve application's ability to scala out by stopping blocking main thread.
Main thread examples: UI thread in WPF application; request in Web API application.

### Not blocking the main thread

An example is in a client program, user clicks a button, so some logic need to be processed.

In synchronous code, the program will freeze, in other words, the UI thread is blocked and only allow user to continue work after completing the process.

In asynchronous code, the program will not block the UI thread, rather than blocking, it will release the thread and do the process work at the back then come back to the main logic after process is completed.

In C#, simply making a method to be a asynchronous method by adding `async` and `await` keywords. Remember to `await` the method every time invoking it, which will achieve the purpose to not blocking the main thread.

### Start task concurrently and control workflow

A business logic is likely to contain many tasks, some of them can start executing without worrying about the order, however, we would still want to process the outcomes in a certain way. We can achieve this by starting tasks together at a similar time. Then getting the outcome and process in whatever order we want.

In C#, `Task` object exists to represent these tasks. Simply calling methods return Task will kick off the processes. Then continue other logics that don't need the Task outcome. When the outcome is needed, `await` the task will give us the results and handling these outcome in a expected logical order or process.

### Reference

https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
https://blog.stephencleary.com/2012/02/async-and-await.html
https://learn.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming
