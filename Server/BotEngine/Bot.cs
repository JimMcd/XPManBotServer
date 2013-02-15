using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GameEngine.HeadsUp;

namespace BotEngine
{
    public class Bot : IAmABot
    {
        private readonly Process _process;
        private readonly StreamReader _output;
        private readonly StreamWriter _input;

        public Bot(string name)
        {
            Name = name;
            var psi = new ProcessStartInfo(@"c:\bots\" + Name + @"\run.bat")
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                WorkingDirectory = @"c:\bots\" + Name
                
            };

            _process = Process.Start(psi);

            _output = _process.StandardOutput;
            _input = _process.StandardInput;
        }

        public string Name { get; private set; }

        public void SendMessage(string message)
        {
            Console.WriteLine("Sending to {0}: {1}", Name, message);
            _input.WriteLine(message); 
        }

        public string GetMessage()
        {
            var result = "";
            var validResponses = new List<string> {"FOLD", "CALL", "BET"};

            while (!validResponses.Contains(result))
            {
                _input.WriteLine("PING");
                result = _output.ReadLine();
                Console.WriteLine("Got {0} from: {1}", result, Name);
            }
            return result;
        }

        public void SendGameOver()
        {
            _input.Close();
            _output.Close();
            _process.Kill();
        }
    }
}
