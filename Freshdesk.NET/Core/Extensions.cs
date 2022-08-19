using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Freshdesk.Core;

public static class Extensions
{
    public static string ToQueryString(this NameValueCollection collection)
    {
        return string.Concat("?", string.Join("&", collection.AllKeys.Select(key => string.Concat(key, "=", Uri.EscapeDataString(collection[key]))).ToArray()));
    }
}

// Detailed explanation of ConfigureAwait(false) can be found on Medium:
// https://medium.com/bynder-tech/c-why-you-should-use-configureawait-false-in-your-library-code-d7837dce3d7f

// Detailed explanation of WaitAndUnwrapException can be found on StackOverflow:
// https://stackoverflow.com/questions/9343594/how-to-call-asynchronous-method-from-synchronous-method-in-c

/// <summary>
/// Provides synchronous extension methods for tasks.
/// Adapted from the AsyncEx library written by <see href="https://github.com/StephenCleary/AsyncEx/">Stephen Cleary</see>.
/// </summary>
public static class TaskExtensions
{
    /// <summary>
    /// Waits for the task to complete, unwrapping any exceptions.
    /// </summary>
    /// <typeparam name="TResult">The type of the result of the task.</typeparam>
    /// <param name="task">The task. May not be <c>null</c>.</param>
    /// <returns>The result of the task.</returns>
    public static TResult WaitAndUnwrapException<TResult>(this Task<TResult> task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));
        return task.GetAwaiter().GetResult();
    }
}