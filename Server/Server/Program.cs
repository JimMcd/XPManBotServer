using System;
using System.Diagnostics;
using System.IO;

namespace Server
{
    class Program
    {
        public static void Main(string[] args)
        {
            var botFinder = new BotFinder();
            var bots = botFinder.Find();

            var bot1 = new Bot(bots[0]);
            var bot2 = new Bot(bots[1]);

            bot1.SendMessage("GO");
            var bot1Input = bot1.GetMessage();
            Console.WriteLine(bot1Input);

            bot2.SendMessage("GO");
            var bot2Input = bot2.GetMessage();
            Console.WriteLine(bot2Input);
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