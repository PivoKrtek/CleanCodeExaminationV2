using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    class GameController
    {
        public IUserInterface UI { get; set; }
        public IGame Game { get; set; }
        public IHighScore HighScore { get; set; }
        public PlayerData PlayerData { get; set; }

        public string Guess = "";
        
        public GameController(IUserInterface userInterface, IGame game, IHighScore highScore)
        {
            UI = userInterface;
            Game = game;
            PlayerData = new();
            HighScore = highScore;
        }

        public void Run()
        {
            SetPlayerName();
            
            do
            {
                StartGame();
                
                //ta bort nedan
                UI.Output(Game.GetAnswer());

                do
                {
                    MakeGuess();

                } while (!Game.Validate(Guess));

                GameFinished();
                PrintHighScore();

                UI.Output("Do you want to play again? y/n");

            } while (!UI.Input().StartsWith('n'));
        }

        private void PrintHighScore()
        {
            UI.Output(HighScoreFormat("Name", "Games", "Average guess"));
            foreach (var playerData in HighScore.GetHighScore())
            {
                UI.Output(HighScoreFormat(playerData.Name, playerData.NumberOfGames, playerData.Average()));
            }
        }
        private string HighScoreFormat(object firstColumn, object secondColumn, object thirdColumn)
        {
            return string.Format("{0,-12}{1,-9}{2,-10:F2}", firstColumn, secondColumn, thirdColumn);
        }

        private void GameFinished()
        {
            UI.Output($"Congratulations, right answer! You managed on {PlayerData.Guesses} guesses.");
            HighScore.Save(PlayerData);
        }

        private void MakeGuess()
        {
            Guess = UI.Input();
            UI.Output(Game.Feedback(Guess));
            PlayerData.Guesses++;
        }

        private void StartGame()
        {
            UI.Clear();
            UI.Output(Game.Instructions());
            Console.ReadLine();
            Game.SetUp();
            PlayerData.Guesses = 0;
        }

        private void SetPlayerName()
        {
            UI.Output("Enter your name:");
            PlayerData.SetName(UI.Input());
        }
    }
}
