using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        Timer timer;
        bool warmUp = true;
        public MainWindow()
        {
            InitializeComponent();
            this.game = new Game(2,0);
            this.start();
        }
        private void start()
        {
            Grid memoGrid = new Grid();
            this.timer = new Timer();
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.Interval = 100;
            this.game.time = 50;
            this.warmUp = true;
            //memoGrid.Width = Grid.;
            if (this.game.level > 2)
            {
                ButtonGrid.Children.RemoveAt(0);
            }
            for (int i = 0; i < game.numberY * game.numberX; i++)
            {
                if (i < game.numberY)
                {
                    RowDefinition rowDef = new RowDefinition();
                    memoGrid.RowDefinitions.Add(rowDef);
                }
                if (i < game.numberX)
                {
                    ColumnDefinition columnDef = new ColumnDefinition();
                    memoGrid.ColumnDefinitions.Add(columnDef);
                }
                var memoButton = game.memos.ElementAt(i);
                memoButton.PreviewMouseMove += button_PreviewMouseLeftButtonDown;
                Grid.SetColumn(memoButton, (int)memoButton.position.X);
                Grid.SetRow(memoButton, (int)memoButton.position.Y);
                memoGrid.Children.Add(memoButton);
            }
            Binding myBinding = new Binding();
            myBinding.Source = game;
            myBinding.Path = new PropertyPath("score");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(scoreLabel, Label.ContentProperty, myBinding);
            Binding myBinding2 = new Binding();
            myBinding2.Source = game;
            myBinding2.Mode = BindingMode.TwoWay;
            myBinding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            myBinding2.Path = new PropertyPath("time");
            BindingOperations.SetBinding(timeBar, ProgressBar.ValueProperty, myBinding2);
            ButtonGrid.Children.Add(memoGrid);
            this.timer.Enabled = true;
        }
        public void disableButtons()
        {
            for (int i = 0; i < game.memos.Count; i++)
            {
                game.memos.ElementAt(i).IsEnabled = false;
            }
        }
        public void newGame(int level)
        {
            this.game = new Game(level, this.game.score);
            this.start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.game.time -= 1;
            if (this.game.time < 0)
            {
                if (this.warmUp == false)
                {
                    this.timer.Enabled = false;
                    this.Dispatcher.Invoke((Action)(() => { this.disableButtons(); }));
                    if (this.game.taken == this.game.numberX * this.game.numberY)
                    {
                        this.Dispatcher.Invoke((Action)(() =>
                        {
                            this.newGame(this.game.level + 1);
                        }));
                    }
                    else
                    {
                        this.game.end();
                    }
                }
                else
                {
                    this.timer.Interval = 100;
                    this.game.time = 100;
                    this.warmUp = false;
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        this.game.ClearSelection();
                    }));
                }

            }
        }

        private void button_PreviewMouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.game = new Game(1, 0);
            this.timer.Enabled = false;
            this.start();
        }
    }
}
