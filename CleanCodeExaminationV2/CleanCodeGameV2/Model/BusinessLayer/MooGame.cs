using System;
using System.Collections.Generic;

namespace CleanCodeExaminationV2
{
    public class MooGame : IGame
    {
        public string Name => "MOO GAME";
        public string Code { get; private set; }
        public MooGame(string code = "")
        {
            Code = code;
        }
        public List<OutputWithColor> Instructions()
        {
            return StringToOutputWithColor(Name);
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

        private string FeedbackString(string guess)
        {
            string cows = "", bulls = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (guess.Length < 4 ? guess.Length : 4); j++)
                {
                    if (Code[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls += "B";
                        }
                        else
                        {
                            cows += "C";
                        }
                    }
                }
            }
            return bulls + (bulls.Length > 0 && cows.Length > 0 ? "," : "") + cows;
        }

        public string NewCode()
        {
            Random r = new();
            Code = "";
            int digit;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                   digit = r.Next(10);
                } while (Code.Contains(digit.ToString()));
                              
                Code += digit;
            }
            return Code;
        }
        public bool Validate(string guess)
        {
            return Code == guess;
        }

        public void SetUp()
        {
           NewCode();
        }

        public string GetAnswer()
        {
            return Code;
        }

        
    }
}
