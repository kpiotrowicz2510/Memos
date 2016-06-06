using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MainWindow()
        {
            InitializeComponent();
            Game game = new Game();
            Grid memoGrid = new Grid();
            memoGrid.Width = 500;
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
            game.ClearSelection();
            Binding myBinding = new Binding();
            myBinding.Source = game;
            myBinding.Path = new PropertyPath("score");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(scoreLabel, Label.ContentProperty, myBinding);
            ButtonGrid.Children.Add(memoGrid);
        }
        private void button_PreviewMouseLeftButtonDown(object sender, MouseEventArgs e)
        {

            //some your code
            e.Handled = true;
        }
    }
}
