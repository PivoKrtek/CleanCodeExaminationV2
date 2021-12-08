using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    class ConsoleIO : IUserInterface
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string s, bool newline)
        {
            if (newline)
            {
                Console.WriteLine(s);
            }
            else
            {
                Console.Write(s);
            }

        }

        public void Output(List<OutputWithColor> list)
        {
            foreach (var outputWithColor in list)
            {
                Console.ForegroundColor = outputWithColor.Color;
                Output(outputWithColor.Output, outputWithColor.NewLine);
            }
            
        }
    }
}
