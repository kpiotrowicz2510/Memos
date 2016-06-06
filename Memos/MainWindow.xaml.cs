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
            for (int i = 0; i < game.numberY; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                memoGrid.RowDefinitions.Add(rowDef);
                for (int j = 0; j < game.numberX; j++)
                {
                    if (i == 0)
                    {
                        ColumnDefinition columnDef = new ColumnDefinition();
                        memoGrid.ColumnDefinitions.Add(columnDef);
                    }
                    Button memoButton = new Button();
                    memoButton.Content = "Hello " + i;
                    memoButton.Width = 150;
                    memoButton.Height = 150;
                    Grid.SetColumn(memoButton, j);
                    Grid.SetRow(memoButton, i);
                    memoGrid.Children.Add(memoButton);
                }
            }
            ButtonGrid.Children.Add(memoGrid);
        }
    }
}
