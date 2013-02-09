using System;
using System.Diagnostics;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var botFinder = new BotFinder();
            var bots = botFinder.Find();

            var bot = new Bot(bots[0]);

            bot.SendMessage("GO");
            var botInput = bot.GetMessage();
            Console.WriteLine(botInput);
            Console.ReadLine();

        }
    }


    public class Bot
    {
        private string _name;
        private Process _process;
        private StreamReader _output;
        private StreamWriter _input;

        public Bot(string botname)
        {
            _name = botname;
            var psi = new ProcessStartInfo(@"c:\bots\" + _name + @"\run.bat")
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                WorkingDirectory = @"c:\bots\" + _name
                
            };

            _process = Process.Start(psi);
            
            _output = _process.StandardOutput;
            _input = _process.StandardInput;
        }

        public string GetMessage()
        {
            var result = "";

            while (String.IsNullOrEmpty(result) || result.Contains(_name)) 
            {
                result = _output.ReadLine();
            }

            return result;
        }

        public void SendMessage(string message)
        {
           _input.WriteLine(message); 
        }
    }
}