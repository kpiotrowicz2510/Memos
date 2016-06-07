using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Memos
{
    class TextMemo: Memo
    {
        Game game;
        public TextMemo(Game g)
        {
            game = g;
            this.Content = this.symbol;
            this.FontSize = 20;
        }
        public override void transform(object sender, RoutedEventArgs e)
        {
            if(this.side == Side.FRONT)
            {
                this.Content = "";
                this.side = Side.BACK;
                this.Background = Brushes.Black;
                this.Focusable = false;
                this.isSelected = false;
                this.game.selectionsCount--;
            }
            else
            {
                this.isSelected = true;
                this.game.selectionsCount++;
                this.Content = this.symbol;
                this.side = Side.FRONT;
                this.Background = Brushes.Wheat;
                this.Focusable = false;
                for (int i = 0; i < game.memos.Count; i++)
                {
                    if (game.memos.ElementAt(i).symbol == this.symbol
                        && game.memos.ElementAt(i).id != this.id)
                    {
                        if (game.memos.ElementAt(i).isSelected)
                        {
                            this.Content = this.symbol;
                            this.side = Side.FRONT;
                            this.Background = Brushes.Gainsboro;
                            this.Focusable = false;
                            this.IsEnabled = false;
                            game.memos.ElementAt(i).IsEnabled = false;
                            game.selectionsCount = 0;
                            game.score += 100 * game.level;
                            game.memos.RemoveAt(i);
                            game.memos.Remove(this);
                            game.taken += 2;
                            break;
                        }
                    }
                }
                if (game.selectionsCount == 2)
                {
                    game.ClearSelection();
                }
            }
        }
    }
}
