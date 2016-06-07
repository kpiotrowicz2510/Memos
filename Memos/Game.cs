using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memos
{
    class Game : INotifyPropertyChanged
    {
        private string vla = "ABCDDBACEFGHEFGHIJKLIJKLMNOPMNOPRSTURSTUWXYZWXYZ1234123456785678";
        public int numberX { get; set; }
        public int numberY { get; set; }
        public int taken { get; set; }
        public int time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged("time");
            }
        }
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged("score");
            }
        }
        public int level { get; set; }
        public List<Memo> memos;
        private int _score;
        private int _time;
        private static Random rng = new Random();
        
        public int selectionsCount { get; set; }
        public Game(int level,int score)
        {
            this.level = level;
            this.numberX = this.level*2;
            this.numberY = this.level*2;
            this.score = score;
           // this.level = 1;
            this.time = 50;
            memos = new List<Memo>();
            this.taken = 0;
            this.init();
        }
        public void ClearSelection()
        {
            for (int i = 0; i < this.memos.Count; i++)
            {
                this.memos.ElementAt(i).isSelected = false;
                this.memos.ElementAt(i).IsEnabled = true;
                this.memos.ElementAt(i).side = Side.FRONT;
                this.memos.ElementAt(i).transform(null, null);
            }
            this.selectionsCount = 0;
        }
        
        public void end()
        {
            MessageBox.Show("Your time has passed! Your score is: "+this.score);
        }
        private void init()
        {
            Random rnd = new Random(12412414);
            List<int> randsX = new List<int>();
            List<int> randsY = new List<int>();
            for (int i = 0; i < this.numberY; i++)
            {
              //  randsX.Add(rnd.Next()
            }
            for (int i = 0; i < this.numberY; i++)
            {

            }
            for (int i = 0; i < this.numberY; i++)
            {
                for (int j = 0; j < this.numberX; j++)
                {
                    TextMemo memoButton = new TextMemo(this);
                    memoButton.Width = 200/this.numberX;
                    memoButton.Height = 200/this.numberY;
                    memoButton.FontSize = 40 - this.numberX*4;
                    memoButton.side = Side.FRONT;
                    memoButton.symbol = this.vla[this.numberX*i + j].ToString();
                    memoButton.Content = this.vla[this.numberX * i + j];
                    memoButton.isSelected = false;
                    memoButton.id = i*this.numberX + j;
                    memoButton.position = new System.Windows.Point(j, i);
                    memoButton.Click += memoButton.transform;
                    memoButton.IsEnabled = false;
                    this.memos.Add(memoButton);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
