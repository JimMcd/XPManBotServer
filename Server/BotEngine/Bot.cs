using System;
using System.Diagnostics;
using System.IO;
using GameEngine.HeadsUp;

namespace BotEngine
{
    public class Bot : IAmABot
    {
        private readonly string _name;
        private readonly Process _process;
        private readonly StreamReader _output;
        private readonly StreamWriter _input;

        public Bot(string name)
        {
            _name = name;
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

        public void SendMessage(string message)
        {
            _input.WriteLine(message); 
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

        public void SendGameOver()
        {
            _input.Close();
            _output.Close();
            _process.Kill();
        }
    }
}
