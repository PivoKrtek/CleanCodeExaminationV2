using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeExaminationV2
{
    interface IUserInterface
    {
        public string Input();
        public void Output(string s = null, bool newline = true);
        public void Output(List<OutputWithColor> list);
        public void Clear();
        public void Exit();
    }
}
