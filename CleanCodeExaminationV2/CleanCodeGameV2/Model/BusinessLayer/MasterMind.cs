using System;
using System.Collections.Generic;

namespace CleanCodeExaminationV2
{
    class MasterMind : IGame
    {
        public string Name => "Master mind";
        public string Code { get; set; }

        private bool[] SpotsEvaluatedGuess;
        private bool[] SpotsEvaluatedCode;
        public List<OutputWithColor> Instructions()
        {
            List<OutputWithColor> list = new();
            list.Add(new("\n\t███████╗███████╗ ██████╗██████╗ ███████╗████████╗     ██████╗ ██████╗ ██████╗ ███████╗\n\t██╔════╝██╔════╝██╔════╝██╔══██╗██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██╔══██╗██╔════╝\n\t███████╗█████╗  ██║     ██████╔╝█████╗     ██║       ██║     ██║   ██║██║  ██║█████╗  \n\t╚════██║██╔══╝  ██║     ██╔══██╗██╔══╝     ██║       ██║     ██║   ██║██║  ██║██╔══╝  \n\t███████║███████╗╚██████╗██║  ██║███████╗   ██║       ╚██████╗╚██████╔╝██████╔╝███████╗\n\t╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚══════╝   ╚═╝        ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝\n", 7));
            list.Add(new("\t\t\t-----------------------------------------------------------\n\t\t\t\t    ----------------------------------\n\t\t\t\t     *Here under is your secret code*\n\t\t\t\t    ----------------------------------\n\t\t\t-----------------------------------------------------------", 0));
            list.AddRange(ColorChoices());
            return list;
        }
        public List<OutputWithColor> ColorChoices()
        {
            List<OutputWithColor> list = new()
            {
                new("\n\n\t\t\t1.\t2.\t3.\t4.\t5.\t6.\t7.\t8.\n"),
                new("\t\t\t██", 1),
            };
            for (int i = 2; i < 8; i++)
            {
                list.Add(new("\t██", i));
            }
            list.Add(new("\t██\n", 8));
            return list;
        }
       
        public string GetAnswer()
        {
            return Code;
        }

        public void SetUp()
        {
            NewCode();
        }

        private void NewCode()
        {
            Random r = new();
            Code = "";

            for (int i = 0; i < 4; i++)
            {
                Code += r.Next(1,9);
            }
        }

        public bool Validate(string guess)
        {
            return guess == Code;
        }

        public List<OutputWithColor> Feedback(string guess)
        {
            List<OutputWithColor> list = GuessInColorSquares(guess);
            list.AddRange(ShowEvaluationOfCode(guess));
            list.Add(AddRow());

            return list;
        }

        private static OutputWithColor AddRow()
        {
            return new("\n\t\t\t-----------------------------------------------------------\n");
        }

        private static List<OutputWithColor> GuessInColorSquares(string guess)
        {
            List<OutputWithColor> list = new();
            list.Add(new("\n\t\t\t\tGUESS:  ", 0));
            for (int i = 0; i < (guess.Length < 4 ? guess.Length : 4); i++)
            {
                if (int.TryParse(guess[i].ToString(), out int number))
                {
                    list.Add(new("   ██", number));
                }
            }

            return list;
        }

        private string AddTabsToString(int amount)
        {
            string tabs = "";
            for (int i = 0; i < amount; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }

        private int RightAnswersOnRightSpot(string guess)
        {
            
            int rightAnswer = 0;
            for (int i = 0; i < (guess.Length < 4 ? guess.Length : 4); i++)
            {
                if(Code[i] == guess[i])
                { rightAnswer++;
                    SpotsEvaluatedGuess[i] = true;
                    SpotsEvaluatedCode[i] = true;
                }
            }
            return rightAnswer;
        }
        private int RightAnswersOnWrongSpot(string guess)
        {
            int rightAnswer = 0;
            for (int i = 0; i < (guess.Length < 4 ? guess.Length : 4); i++)
            {
                for (int j = 0; j < Code.Length; j++)
                {
                    if(Code[j] == guess[i] && !SpotsEvaluatedCode[j] && !SpotsEvaluatedGuess[i])
                    {
                        rightAnswer++;
                        SpotsEvaluatedGuess[i] = true;
                        SpotsEvaluatedCode[j] = true;
                    }
                }
            }
            return rightAnswer;
        }

        private List<OutputWithColor> ShowEvaluationOfCode(string guess)
        {
            SpotsEvaluatedCode = new bool[4] { false, false, false, false };
            SpotsEvaluatedGuess = new bool[4] { false, false, false, false };

            List<OutputWithColor> list = new();
            list.Add(new("\t\t", 0));
            int rightAnswerOnRightSpot = RightAnswersOnRightSpot(guess);
            for (int i = 0; i < rightAnswerOnRightSpot; i++)
            {
                list.Add(new("\u2584 ", 0));
            }
            int rightAnswerOnWrongSpot = RightAnswersOnWrongSpot(guess);
            for (int i = 0; i < rightAnswerOnWrongSpot; i++)
            {
                list.Add(new("\u2584 ", 1));
            }
            return list;
        }
    }
}
