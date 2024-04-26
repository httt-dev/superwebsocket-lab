using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\workspace\\c#\\SuperWebSocketLab\\LogParse\\20240410.log";

            LogParser parser = new LogParser();
            parser.ParseLog(filePath);

            Console.ReadLine();
        }
    }
}
