using System;

namespace EventApplication.Shared.Interceptor
{
    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine("EF Message: {0} ", message);
        }
    }
}
