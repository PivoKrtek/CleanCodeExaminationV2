using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    interface IHighScore
    {
        public void Save(PlayerData p);
        public List<PlayerData> GetHighScore();
        //public List<string> GetHighScore();
    }
}
