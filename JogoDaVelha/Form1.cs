using System;

using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        int Xplayer = 0, Oplayer = 0, tie = 0, rounds = 0;
        bool turn = true, endGame = false;
        string[] texto = new string[9]; //create array

        private void button9_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";

            rounds = 0;
            endGame = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;
            if (btn.Text == "" && endGame == false)
            {
                if (turn) //altern in X and O
                {
                    btn.Text = "X";
                    texto[buttonIndex] = btn.Text;
                    rounds++;
                    turn = !turn;
                    Check(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rounds++;
                    turn = !turn;
                    Check(2);
                } //end turn
            }

        }//end method button click

        void Winner(int PlayerWin) 
        {
            endGame = true;

            if (PlayerWin == 1 )
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Player 1 Win!");
                turn = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Player 2 Win!");
                turn = false;   
            }
        }
        void Check(int checkPlayer)
        {
            string suporte;
            if (checkPlayer == 1)
            {
                suporte = "X";
            }
            else
            {
                suporte = "O";
            }
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2]) //check array 
                    {
                        Winner(checkPlayer);
                        return;
                    }//end check horizontal
                }
            }//end loop horizon
            for (int vertical = 0; vertical < 3; vertical ++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6]) //check array 
                    {                        
                        Winner(checkPlayer);
                        return;
                    }//end check Vertical
                }
            }//end loop vertical
            //check diagon
            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {                    
                    Winner(checkPlayer);
                    return;
                }//main diagon
                
            }
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Winner(checkPlayer);
                    return;
                }//secound diagon
            }
            if (rounds == 9 && endGame == false)
            {
                tie++;
                tiePoints.Text = Convert.ToString(tie);
                MessageBox.Show("TIE");
                endGame = true;
                return;
            }

        }
    }
}
