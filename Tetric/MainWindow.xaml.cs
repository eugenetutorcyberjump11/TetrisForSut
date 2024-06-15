﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tetric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game(GameCanvas);
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += GameTick;

            this.KeyDown += MainWindow_KeyDown;     
        }

        private void GameTick(object sender, EventArgs e)
        {
            _game.MoveDown();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game == null) return;

            switch (e.Key) {
                case Key.Left:
                    _game.MoveLeft();
                    break;
                case Key.Right:
                    _game.MoveRight();
                    break;
                case Key.Up:
                    _game.Rotate();
                    break;
                case Key.Down:
                    _game.MoveDown();
                    break;
            }

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _game.StartNewGame();
            _timer.Start();
        }
    }
}