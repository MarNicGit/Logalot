using Bogus;
using log4net;
using System;

namespace Logalot
{
    internal class Logspammer
    {
        private static readonly ILog Log4NetLog = log4net.LogManager.GetLogger(typeof(Program));

        internal static void StartSpamming()
        {
            do
            {
                while(!Console.KeyAvailable)
                {
                    Spam();
                    System.Threading.Thread.Sleep(new Random().Next(100, 2000));
                }                
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Escape key pressed! Quitting!");
            Console.ResetColor();
        }

        private static void Spam()
        {            
            string message = new Faker().Lorem.Sentence(3, 8);

            var values = Enum.GetValues(typeof(LogLevel));
            var randomLevel = (LogLevel)values.GetValue(new Random().Next(values.Length));
            switch (randomLevel)
            {
                case LogLevel.Info: LogInfo(message);break;
                case LogLevel.Warning: LogWarning(message);break;
                case LogLevel.Error: LogError(message);break;
                case LogLevel.Debug: LogDebug(message);break;
                case LogLevel.Fatal: LogFatal(message);break;
                default:
                    break;
            }

            Console.WriteLine(message);
        }

        private static void LogFatal(string message)
        {
            Log4NetLog.Fatal(message);
        }

        private static void LogDebug(string message)
        {
            Log4NetLog.Debug(message);
        }

        private static void LogError(string message)
        {
            Log4NetLog.Error(message);
        }

        private static void LogWarning(string message)
        {
            Log4NetLog.Warn(message);
        }

        private static void LogInfo(string message)
        {
            Log4NetLog.Info(message);
        }
    }

    internal enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug,
        Fatal
    }
}