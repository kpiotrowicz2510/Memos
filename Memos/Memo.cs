using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memos
{
    enum Side { FRONT,BACK};
    abstract class Memo: MemoI
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public Point position{ get; set; }
        public Side side { get; set; }
    }
}
