using TelegramParse.Interfaces;

namespace TelegramParse.Service
{
    public class ConsoleLogger : ILoggerError
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
