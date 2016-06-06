using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Memos
{
    enum Side { FRONT,BACK};
    abstract class Memo: Button, MemoI
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public Point position{ get; set; }
        public Side side { get; set; }
        public abstract void transform(object sender, RoutedEventArgs e);
        public bool isSelected { get; set; }
    }
}
