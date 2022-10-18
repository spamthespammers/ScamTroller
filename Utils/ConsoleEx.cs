using System;
namespace ScamTroller.Utils
{
    public static class ConsoleEx
    {
        static string LogFile;

        static ConsoleEx()
        {
            LogFile = $"scamtroller-{DateTime.Now:yyyy-MM-dd--HH-mm}.txt";
        }

        public static void WriteLine(object value, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            Console.ForegroundColor = foreground ?? Console.ForegroundColor;
            Console.BackgroundColor = background ?? Console.BackgroundColor;
            Console.WriteLine(value);
            File.AppendAllText(LogFile, $"{value}{Environment.NewLine}");
            if(foreground.HasValue || background.HasValue)
            {
                Console.ResetColor();
            }
        }
    }
}

