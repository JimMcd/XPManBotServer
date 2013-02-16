using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
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

            var readCount = 0;
            while (!validResponses.Contains(result) && readCount < 100)
            {
                result = _output.ReadLine();
                Console.WriteLine("Got {0} from: {1}", result, Name);
                readCount++;
            }
            if (readCount == 100)
                return "FOLD";
            return result;
        }

        public void SendGameOver()
        {
            SendMessage("GAME_OVER");
            _input.Close();
            _output.Close();

            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
                if (process.ProcessName.ToLower().Contains(Name.ToLower()))
                    process.Kill();
            }

            _process.Kill();
            _process.Close();
            _process.Dispose();
        }
    }
}
