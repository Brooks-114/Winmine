using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winmine
{
    public enum Level
    {
        primary,
        middle,
        senior,
        custom
    }


    public class MineField
    {
        public int x { get; set; }
        public int y { get; set; }
        public int mines { get; set; }
        public Level level { get; set; }
    }
}
