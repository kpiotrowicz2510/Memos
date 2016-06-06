using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memos
{
    class Game
    {
        public int numberX { get; set; }
        public int numberY { get; set; }
        public List<Memo> memos;
        public int selectionsCount { get; set; }
        public Game()
        {
            this.numberX = 3;
            this.numberY = 2;
            memos = new List<Memo>();
            this.init();
        }
        public void ClearSelection()
        {
            for (int i = 0; i < this.memos.Count; i++)
            {
                this.memos.ElementAt(i).isSelected = false;
                this.memos.ElementAt(i).side = Side.FRONT;
                this.memos.ElementAt(i).transform(null, null);
            }
            this.selectionsCount = 0;
        }
        private void init()
        {
            for (int i = 0; i < this.numberY; i++)
            {
                for (int j = 0; j < this.numberX; j++)
                {
                    TextMemo memoButton = new TextMemo(this);
                    memoButton.Width = 150;
                    memoButton.Height = 150;
                    memoButton.FontSize = 40;
                    memoButton.side = Side.FRONT;
                    memoButton.symbol = (i ).ToString();
                    memoButton.Content = (i * this.numberX + j).ToString();
                    memoButton.isSelected = false;
                    memoButton.id = i*this.numberX + j;
                    memoButton.position = new System.Windows.Point(j, i);
                    memoButton.Click += memoButton.transform;
                    this.memos.Add(memoButton);
                }
            }
        }
    }
}
