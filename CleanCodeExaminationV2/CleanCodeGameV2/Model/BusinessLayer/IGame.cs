using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    public interface IGame
    {
        public string Name { get; }

        public List<OutputWithColor> Instructions();
        public void SetUp();
        public string GetAnswer();
        public bool Validate(string guess);
        public List<OutputWithColor> Feedback(string guess);
        

        //public List<PlayerData> GetHighScore();

    }
}
