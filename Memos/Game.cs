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
        private string[] vla = { "ABBA", "ADCBCBDAEHGFGFEH" };
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
        private List<string> mValues;
        private int _score;
        private int _time;
        private static Random rng = new Random();
        
        public int selectionsCount { get; set; }
        public Game(int level,int score)
        {
            this.level = level;
            this.numberX = this.level * 2;
            this.numberY = this.level * 2;
            this.score = score;
            // this.level = 1;
            this.time = 50;
            memos = new List<Memo>();
            mValues = new List<string>();

            this.addMValues();

            this.taken = 0;
            this.init();
        }

        private void addMValues()
        {
            string[] g = "A A B B C C D D E E F F G G H H I I J J K K L L M M N N O O P P R R S S T T U U W W X X Y Y Z Z 0 0 1 1 2 2 3 3 4 4 5 5 6 6 7 7 8 8 9 9".Split(' ');
            for (int i = 0; i < this.numberX*this.numberY; i++)
            {
                mValues.Add(g[i]);
            }
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
        private string getRandomSymbol()
        {
            var randomId = rng.Next(0, this.mValues.Count);
            var value = "";
            try
            {
                value = this.mValues.ElementAt(randomId);
                this.mValues.RemoveAt(randomId);
            }catch(ArgumentOutOfRangeException e)
            {
                value = "X";
            }
            //TODO:
            //GET random element from list, delete that element from list, return
            return value;
        }
        private void init()
        {
            for (int i = 0; i < this.numberY; i++)
            {
                for (int j = 0; j < this.numberX; j++)
                {
                    TextMemo memoButton = new TextMemo(this);
                    memoButton.Width = 200/this.numberX;
                    memoButton.Height = 200/this.numberY;
                    memoButton.FontSize = 40 - this.numberX*3;
                    memoButton.side = Side.FRONT;
                    var symbol = this.getRandomSymbol();
                    memoButton.symbol = symbol;
                    memoButton.Content = symbol;
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
