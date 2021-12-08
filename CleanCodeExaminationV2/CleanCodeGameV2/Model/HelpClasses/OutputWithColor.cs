using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    public class OutputWithColor
    {
        public string Output { get; set; }
        public ConsoleColor Color { get; set; }
        public int ColorNumber { get; set; }
        public bool NewLine { get; set; }

        public OutputWithColor(string output, bool newline = true)
        {
            Output = output;
            ColorNumber = 2;
            Color = ReturnColor(2);
            NewLine = newline;
        }
        public OutputWithColor(string output, int colorNumber, bool newline = false)
        {
            Output = output;
            ColorNumber = colorNumber;
            Color = ReturnColor(colorNumber);
            NewLine = newline;
        }

        public ConsoleColor ReturnColor(int number)
        {
            switch (number)
            {
                case 1:
                    return ConsoleColor.DarkGray;
                case 2:
                    return ConsoleColor.White;
                case 3:
                    return ConsoleColor.Yellow;
                case 4:
                    return ConsoleColor.Red;
                case 5:
                    return ConsoleColor.Magenta;
                case 6:
                    return ConsoleColor.Blue;
                case 7:
                    return ConsoleColor.Cyan;
                case 8:
                    return ConsoleColor.Green;
                default:
                    return ConsoleColor.White;
            }
            
        }
    }
    
}
