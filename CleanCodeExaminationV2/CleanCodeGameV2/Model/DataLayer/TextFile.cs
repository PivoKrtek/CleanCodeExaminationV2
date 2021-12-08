using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    class TextFile : IHighScore
    {
        public string GameName { get; set; }
        public TextFile(string gameName)
        {
			GameName = gameName;
        }
        public List<PlayerData> GetHighScore()
        {
			string[] lines = File.ReadAllLines(GameName + ".txt");
			List<PlayerData> highScore = new();
            foreach (var line in lines)
            {
				string[] nameAndGuesses = line.Split(':');
				if(highScore.Any(x => x.Name == nameAndGuesses[0]))
                {
					highScore.First(x => x.Name == nameAndGuesses[0]).Update(int.Parse(nameAndGuesses[1]));

                }
                else
                {
					PlayerData playerData = new(nameAndGuesses[0], int.Parse(nameAndGuesses[1]));
					highScore.Add(playerData);
				}
				
            }
			return highScore.OrderBy(x => x.Average()).ToList();
		}

        public void Save(PlayerData p)
        {
			StreamWriter sw = new StreamWriter(GameName + ".txt", append: true);
			sw.WriteLine($"{p.Name}:{p.Guesses}");
			sw.Close();
		}
    }
}
