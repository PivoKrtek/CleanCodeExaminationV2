using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    class PlayerData
    {
        public PlayerData()
        {
        }
        public PlayerData(string name, int guesses)
        {
            Name = name;
            Guesses = guesses;
            NumberOfGames = 1;
        }
        public string Name { get; private set; }
        public int Guesses { get; set; }
        public int NumberOfGames { get; set; }

        internal void Update(int guesses)
        {
            Guesses += guesses;
            NumberOfGames++;
        }
        public double Average()
        {
            return (double)Guesses/NumberOfGames;
        }

        internal void SetName(string name)
        {
            Name = name;
        }

    }
}
