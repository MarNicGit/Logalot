using log4net;
using System;

namespace Logalot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Setting up the loggers..");

            InitializeLoggers();

            Console.WriteLine("Time to spam some random logs!");

            Logspammer spammer = new();

            Logspammer.StartSpamming();
        }
        
        private static void InitializeLoggers()
        {
            
        }
    }
}
