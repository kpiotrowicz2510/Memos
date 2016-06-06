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
        private string vla = "ABCDDBACEFGHEFGHIJKLIJKLMNOPMNOPRSTURSTUWXYZWXYZ";
        public int numberX { get; set; }
        public int numberY { get; set; }
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
        public Game()
        {
            this.numberX = 4;
            this.numberY = 4;
            this.score = 0;
            this.level = 1;
            this.time = 50;
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
        
        public void end()
        {
            MessageBox.Show("Your time has passed! Your score is: "+this.score);
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
                    memoButton.symbol = this.vla[this.numberX*i + j].ToString();
                    memoButton.Content = this.vla[this.numberX * i + j];
                    memoButton.isSelected = false;
                    memoButton.id = i*this.numberX + j;
                    memoButton.position = new System.Windows.Point(j, i);
                    memoButton.Click += memoButton.transform;
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
