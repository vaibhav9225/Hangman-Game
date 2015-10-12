using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Hangman
{
    public partial class Form1 : Form
    {
        List<char> charHold = new List<char>();
        List<Button> buttonList = new List<Button>();
        int xStart;
        int yStart;
        int count;
        int randomMovieNumber;
        int mistakes = 0;
        int score=0;
        static Stream musicStream = Properties.Resources.HangmanTrack;
        SoundPlayer musicPlayer = new SoundPlayer(musicStream);
        bool musicPlayback = false;
        string highScoreString=Properties.Resources.HighScore;
        int highScore;
        char[] movieCharacters;
        int x = Screen.PrimaryScreen.Bounds.Width;
        int y = Screen.PrimaryScreen.Bounds.Height;
         
        public Form1()
        {
            InitializeComponent();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            mistakes = 0;
            pictureBox1.Image = Properties.Resources.Hangman9;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            Form1 formHangman = new Form1();
            int listCount = buttonList.Count;
            for (int startDisposing = 0; startDisposing < listCount; startDisposing++)
            {
                buttonList[startDisposing].Dispose();
            }
            buttonList.Clear();
            charHold.Clear();
            yStart = 120;
            xStart = 20;
            string movieList = Properties.Resources.BollywoodMovies;
            string[] movieName = movieList.Split('\n');
            Random random = new Random();
            randomMovieNumber = random.Next(movieName.Length - 1);
            movieCharacters = movieName[randomMovieNumber].ToCharArray();
            count = -1;
            for (int character = 0; character < movieCharacters.Length - 1; character++)
            {
                if (movieCharacters[character] != ' ')
                {
                    buttonList.Add(new Button());
                    count++;
                    buttonList[count].Text = "_";
                    charHold.Add(movieCharacters[character]);
                    buttonList[count].SetBounds(xStart, yStart, 39, 36);
                    buttonList[count].FlatStyle = FlatStyle.Flat;
                    buttonList[count].Font = new Font("Times New Roman", 12);
                    buttonList[count].BackColor = Color.DarkOliveGreen;
                    buttonList[count].SetBounds((buttonList[count].Location.X * x) / 1366, (buttonList[count].Location.Y * y) / 768, (buttonList[count].Width * x) / 1366, (buttonList[count].Height * y) / 768);
                    buttonList[count].Font = new Font("Times New Roman", (buttonList[count].Font.Size * x) / 1366);
                    this.Controls.Add(buttonList[count]);
                    xStart = xStart + 50;
                }
                else if (movieCharacters[character] == ' ')
                {
                    yStart = yStart + 50;
                    xStart = 20;
                }
            }
            button27.Enabled = false;
            timer1.Enabled = true;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Player";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            charCheck('A', 'a');
            victoryLap();
            gameChecker();
        }

        void charCheck(char upperCase, char lowerCase)
        {
            int loopCheck = 0;
            int listCount = charHold.Count;
            for (int startDisposing = 0; startDisposing < listCount; startDisposing++)
            {
                if (charHold[startDisposing] == upperCase)
                {
                    buttonList[startDisposing].Text = upperCase.ToString();
                    loopCheck++;
                    mistakeMade(upperCase);
                }
                else if (charHold[startDisposing] == lowerCase)
                {
                    buttonList[startDisposing].Text = lowerCase.ToString();
                    loopCheck++;
                    mistakeMade(upperCase);
                }
            }
            if (loopCheck == 0)
            {
                    mistakes++;
                    imageChange();
                    mistakeMade(upperCase);
            }
        }

        void imageChange()
        {
            if (mistakes==1)
                pictureBox1.Image = Properties.Resources.Hangman7;
            else if (mistakes==2)
                pictureBox1.Image = Properties.Resources.Hangman6;
            else if (mistakes==3)
                pictureBox1.Image = Properties.Resources.Hangman5;
            else if (mistakes==4)
                pictureBox1.Image = Properties.Resources.Hangman4;
            else if (mistakes==5)
                pictureBox1.Image = Properties.Resources.Hangman3;
            else if (mistakes==6)
                pictureBox1.Image = Properties.Resources.Hangman2;
            else if (mistakes==7)
                pictureBox1.Image = Properties.Resources.Hangman1;
            else if (mistakes==8)
                pictureBox1.Image = Properties.Resources.Hangman8;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            charCheck('B', 'b');
            victoryLap();
            gameChecker();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (x > 800 && y > 600)
            {
                this.Width = (this.Width * x) / 1366;
                this.Height = (this.Height * y) / 768;
                foreach(Control c in this.Controls)
                {
                    c.SetBounds((c.Location.X * x) / 1366, (c.Location.Y * y) / 768, (c.Width * x) / 1366, (c.Height * y) / 768);
                    c.Font = new Font("Times New Roman", (c.Font.Size * x) / 1366);
                }
            }
            if (x == 800 && y == 600)
            {
                this.Width = (this.Width * x) / 1250;
                this.Height = (this.Height * y) / 668;
                this.Location = new Point(150, 7);
                foreach (Control c in this.Controls)
                {
                    if (c == label5)
                    {
                        c.SetBounds((c.Location.X * x) / 1237, (c.Location.Y * y) / 780, (c.Width * x) / 1300, (c.Height * y) / 780);
                        c.Font = new Font("Times New Roman", (c.Font.Size * x) / 1250);
                    }
                    else
                    {
                        c.SetBounds((c.Location.X * x) / 1250, (c.Location.Y * y) / 780, (c.Width * x) / 1250, (c.Height * y) / 780);
                        c.Font = new Font("Times New Roman", (c.Font.Size * x) / 1250);
                    }
                }
            }

            if (File.Exists(@"C:\HangmanGameData\HighScore.hgd"))
            {
                highScoreString = File.ReadAllText(@"C:\HangmanGameData\HighScore.hgd");
                highScore = Convert.ToInt32(highScoreString);
            }
            else
            {
                Directory.CreateDirectory(@"C:\HangmanGameData");
                File.WriteAllText(@"C:\HangmanGameData\HighScore.hgd", "0");
            }
            label5.Text = highScoreString;
            musicPlayer.PlayLooping();
            pictureBox1.Image = Properties.Resources.Hangman9;
            
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button10.Enabled = false;
                button9.Enabled = false;
                button8.Enabled = false;
                button7.Enabled = false;
                button6.Enabled = false;
                button15.Enabled = false;
                button14.Enabled = false;
                button13.Enabled = false;
                button12.Enabled = false;
                button11.Enabled = false;
                button20.Enabled = false;
                button19.Enabled = false;
                button18.Enabled = false;
                button17.Enabled = false;
                button16.Enabled = false;
                button21.Enabled = false;
                button26.Enabled = false;
                button25.Enabled = false;
                button24.Enabled = false;
                button23.Enabled = false;
                button22.Enabled = false;
        }

        void mistakeMade(char charCase)
        {
            switch (charCase)
            {
                case 'A': button1.Enabled = false; break;
                case 'B': button2.Enabled = false; break;
                case 'C': button3.Enabled = false; break;
                case 'D': button4.Enabled = false; break;
                case 'E': button5.Enabled = false; break;
                case 'F': button10.Enabled = false; break;
                case 'G': button9.Enabled = false; break;
                case 'H': button8.Enabled = false; break;
                case 'I': button7.Enabled = false; break;
                case 'J': button6.Enabled = false; break;
                case 'K': button15.Enabled = false; break;
                case 'L': button14.Enabled = false; break;
                case 'M': button13.Enabled = false; break;
                case 'N': button12.Enabled = false; break;
                case 'O': button11.Enabled = false; break;
                case 'P': button20.Enabled = false; break;
                case 'Q': button19.Enabled = false; break;
                case 'R': button18.Enabled = false; break;
                case 'S': button17.Enabled = false; break;
                case 'T': button16.Enabled = false; break;
                case 'U': button21.Enabled = false; break;
                case 'V': button26.Enabled = false; break;
                case 'W': button25.Enabled = false; break;
                case 'X': button24.Enabled = false; break;
                case 'Y': button23.Enabled = false; break;
                case 'Z': button22.Enabled = false; break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            charCheck('C', 'c');
            victoryLap();
            gameChecker();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            charCheck('D', 'd');
            victoryLap();
            gameChecker();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            charCheck('E', 'e');
            victoryLap();
            gameChecker();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            charCheck('F', 'f');
            victoryLap();
            gameChecker();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            charCheck('G', 'g');
            victoryLap();
            gameChecker();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            charCheck('H', 'h');
            victoryLap();
            gameChecker();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            charCheck('I', 'i');
            victoryLap();
            gameChecker();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            charCheck('J', 'j');
            victoryLap();
            gameChecker();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            charCheck('K', 'k');
            victoryLap();
            gameChecker();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            charCheck('L', 'l');
            victoryLap();
            gameChecker();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            charCheck('M', 'm');
            victoryLap();
            gameChecker();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            charCheck('N', 'n');
            victoryLap();
            gameChecker();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            charCheck('O', 'o');
            victoryLap();
            gameChecker();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            charCheck('P', 'p');
            victoryLap();
            gameChecker();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            charCheck('Q', 'q');
            victoryLap();
            gameChecker();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            charCheck('R', 'r');
            victoryLap();
            gameChecker();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            charCheck('S', 's');
            victoryLap();
            gameChecker();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            charCheck('T', 't');
            victoryLap();
            gameChecker();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            charCheck('U', 'u');
            victoryLap();
            gameChecker();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            charCheck('V', 'v');
            victoryLap();
            gameChecker();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            charCheck('W', 'w');
            victoryLap();
            gameChecker();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            charCheck('X', 'x');
            victoryLap();
            gameChecker();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            charCheck('Y', 'y');
            victoryLap();
            gameChecker();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            charCheck('Z', 'z');
            victoryLap();
            gameChecker();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (!musicPlayback)
            {
                musicPlayer.Stop();
                musicPlayback = true;
                button28.Text = "Resume Music !";
            }
            else
            {
                musicPlayer.PlayLooping();
                musicPlayback = false;
                button28.Text = "Pause Music";
            }
        }

        private void victoryLap()
        {
            int gameCount = 0;
            int listCount = buttonList.Count;
            for (int startDisposing = 0; startDisposing < listCount; startDisposing++)
            {
                if (buttonList[startDisposing].Text != "_")
                {
                    gameCount++;
                }
                if (listCount == gameCount)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button10.Enabled = false;
                    button9.Enabled = false;
                    button8.Enabled = false;
                    button7.Enabled = false;
                    button6.Enabled = false;
                    button15.Enabled = false;
                    button14.Enabled = false;
                    button13.Enabled = false;
                    button12.Enabled = false;
                    button11.Enabled = false;
                    button20.Enabled = false;
                    button19.Enabled = false;
                    button18.Enabled = false;
                    button17.Enabled = false;
                    button16.Enabled = false;
                    button21.Enabled = false;
                    button26.Enabled = false;
                    button25.Enabled = false;
                    button24.Enabled = false;
                    button23.Enabled = false;
                    button22.Enabled = false;
                    score++;
                    label3.Text = score.ToString();
                    if (score > Convert.ToInt32(label5.Text))
                    {
                        highScore = score;
                        highScoreString = highScore.ToString();
                        label5.Text = highScoreString;
                        File.WriteAllText(@"C:\HangmanGameData\HighScore.hgd", highScoreString);
                    }
                    SystemSounds.Exclamation.Play();
                    Form2 victoryForm = new Form2();
                    victoryForm.ShowDialog();
                    button27.Enabled = true;
                    button27.Text = "Next Word !";
                    timer1.Enabled = false;
                    break;
                }
            }
        }

        private void gameChecker()
        {
            if (mistakes == 8)
            {
                button27.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button10.Enabled = false;
                button9.Enabled = false;
                button8.Enabled = false;
                button7.Enabled = false;
                button6.Enabled = false;
                button15.Enabled = false;
                button14.Enabled = false;
                button13.Enabled = false;
                button12.Enabled = false;
                button11.Enabled = false;
                button20.Enabled = false;
                button19.Enabled = false;
                button18.Enabled = false;
                button17.Enabled = false;
                button16.Enabled = false;
                button21.Enabled = false;
                button26.Enabled = false;
                button25.Enabled = false;
                button24.Enabled = false;
                button23.Enabled = false;
                button22.Enabled = false;
                button27.Text = "Replay !";
                if (score > Convert.ToInt32(label5.Text))
                {
                    highScore = score;
                    highScoreString = highScore.ToString();
                    label5.Text = highScoreString;
                    File.WriteAllText(@"C:\HangmanGameData\HighScore.txt", highScoreString);
                }
                score = 0;
                label3.Text = score.ToString();
                SystemSounds.Asterisk.Play();
                Form3 gameOverForm = new Form3();
                gameOverForm.ShowDialog();
                SystemSounds.Asterisk.Play();
                int fillCount = 0;
                for (int character = 0; character < movieCharacters.Length - 1; character++)
                {
                    if (movieCharacters[character] != ' ')
                    {
                        buttonList[fillCount].Text = movieCharacters[character].ToString();
                        fillCount++;
                    }
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Form4 aboutForm = new Form4();
            aboutForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}