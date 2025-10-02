using System;
using System.Windows.Forms;

namespace TicTacToe_Game_Gonzales

{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}