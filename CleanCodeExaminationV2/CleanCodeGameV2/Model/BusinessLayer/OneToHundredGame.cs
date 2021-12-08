using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    class OneToHundredGame : IGame
    {
        public string Name => "1 to 100";
        public int Number { get; set; }

        public List<OutputWithColor> Instructions()
        {
            return StringToOutputWithColor(Name);
        }
       

        public string FeedbackString(string guess)
        {
            if(!(guess == Number.ToString()))
            { return "Wrong answer, try again."; }
            else { return "RIGHT ANSWER!"; }
        }

        public string GetAnswer()
        {
            return Number.ToString();
        }

        public void SetUp()
        {
            Random r = new();
            Number = r.Next(1, 101);
           
        }

        public bool Validate(string guess)
        {
            return guess == Number.ToString();
        }
       
        public List<OutputWithColor> Feedback(string guess)
        {
            return StringToOutputWithColor(FeedbackString(guess));
        }
        private List<OutputWithColor> StringToOutputWithColor(string s)
        {
            List<OutputWithColor> list = new();
            list.Add(new OutputWithColor(s));
            return list;
        }
    }
}
