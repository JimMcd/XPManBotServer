using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Server
{
    public class ProcessBot
    {
        
        private string _name;
        private Process _process;
        private StreamReader _output;
        private StreamWriter _input;

        public ProcessBot(string botname)
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
