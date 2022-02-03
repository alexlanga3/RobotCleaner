using RobotCleaner.ConsoleApp.Helpers.Interfaces;
using System;

namespace RobotCleaner.ConsoleApp.Helpers
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
