using System;
using System.Diagnostics.Metrics;
using System.Media;
using System.Reflection;

namespace Hangman
{
    public partial class Form1 : Form
    {
        int randomNumber = -1;
        readonly int maxGuesses = 6;
        int Guesses = 0;
        private readonly List<Label> labels = [];
        readonly string[] wordList = ["Elephant", "Chocolate", "Rainbow", "Bicycle", "Adventure", "Computer", "Butterfly", "Mountain", "Dinosaur", "Galaxy"];
        private Random random;
        private readonly int MaxLenghtWordList = 9;
        private SoundPlayer _soundPlayer;
        public Form1()
        {
            InitializeComponent();
            FillData();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _soundPlayer = new SoundPlayer(@"..\..\..\..\Resources\clapping.wav");
        }

        private void FillData()
        {
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
        }

        private void InitializeData()
        {
            Guesses = 0;
            lblGuesses.Text = Guesses.ToString();
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            btnG.Enabled = true;
            btnH.Enabled = true;
            btnI.Enabled = true;
            btnJ.Enabled = true;
            btnK.Enabled = true;
            btnL.Enabled = true;
            btnM.Enabled = true;
            btnN.Enabled = true;
            btnO.Enabled = true;
            btnP.Enabled = true;
            btnQ.Enabled = true;
            btnR.Enabled = true;
            btnS.Enabled = true;
            btnT.Enabled = true;
            btnU.Enabled = true;
            btnV.Enabled = true;
            btnW.Enabled = true;
            btnX.Enabled = true;
            btnY.Enabled = true;
            btnZ.Enabled = true;
            label1.Text = "__";
            label2.Text = "__";
            label3.Text = "__";
            label4.Text = "__";
            label5.Text = "__";
            label6.Text = "__";
            label7.Text = "__";
            label8.Text = "__";
            label9.Text = "__";
            _soundPlayer.Stop();
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            InitializeData();
            random = new Random();
            randomNumber = random.Next(0, wordList.Length); // Generate a random number between 0 and wordList.Length
            for (int i = 0; i < MaxLenghtWordList; i++)
            {
                if (i < wordList[randomNumber].Length)
                {
                    labels[i].Visible = true;
                }
                else
                {
                    labels[i].Visible = false;
                }
            }
        }

        private void btnLetter_Click(object sender, EventArgs e)
        {
            if (randomNumber != -1 && Guesses < maxGuesses)
            {
                ((Button)sender).Enabled = false;
                string Letter = ((Button)sender).Text;
                string word = wordList[randomNumber].ToUpper();
                if (word.Contains(Letter))
                {
                    int letterPosition = -1;
                    letterPosition = word.IndexOf(Letter, letterPosition + 1);
                    while (letterPosition != -1)
                    {
                        labels[letterPosition].Text = Letter;
                        letterPosition = word.IndexOf(Letter, letterPosition + 1);
                    }
                    if (CheckWin())
                    {
                        _soundPlayer.Play();
                        MessageBox.Show($"You won, Congratulations!!!!");
                        Guesses = maxGuesses;
                        
                    }
                }
                else
                {
                    Guesses++;
                    lblGuesses.Text = Guesses.ToString();
                    if (Guesses >= maxGuesses)
                    {
                        MessageBox.Show($"You have reach the max guesses allowed. Sorry, you lose. The word was: {wordList[randomNumber]}");
                    }
                }
            }
            else
            {
                MessageBox.Show($"Please, Start a new game");
            }
        }

        private bool CheckWin()
        {
            int Correct = 0;
            foreach (Label label in labels)
            {
                if (label.Visible && !label.Text.Equals("__"))
                {
                    Correct++;
                }
            }
            return Correct == wordList[randomNumber].Length;
        }
    }
}
