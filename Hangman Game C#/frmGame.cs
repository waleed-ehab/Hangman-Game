using CuoreUI.Controls;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;

namespace Hangman_Game_C_
{
    public partial class frmGame : Form
    {
        private const string _space = " ";
        private const char _placeHolder = '_';

        private string _wordToGuess = string.Empty;
        private int _counter = 0;

        public frmGame()
        {
            InitializeComponent();

            this.Paint += Draw;
        }

        private bool IsGuessCorrect(char character)
        {
            return _wordToGuess.Contains(character);
        }

        private string GetPlaceholders()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < _wordToGuess.Length; ++i)
            {
                str.Append(_placeHolder);
            }

            return str.ToString();
        }

        private void SetPlaceholders()
        {
            txtWord.Text = string.Join(_space, GetPlaceholders().ToCharArray());
        }

        private void ReplacePlaceholdersWithCharacter(char character)
        {
            char[] current = txtWord.Text.Replace(_space, "").ToCharArray();
            string original = _wordToGuess;

            for (int i = 0; i < original.Length; ++i)
            {
                if (original[i] == character)
                {
                    current[i] = character;
                }
            }

            txtWord.Text = string.Join(_space, current);
        }

        private bool IsGuessComplete()
        {
            return !txtWord.Text.Contains(_placeHolder);
        }

        private void DrawBodyPart()
        {
            _counter++;

            // This will trigger the Paint event,
            // during which the Draw method will be called to render the body part.

            this.Invalidate();
        }

        private bool IsGallowComplete()
        {
            return _counter >= 6;
        }

        private void ShowRightGuess()
        {
            txtWord.Text = string.Join(_space, _wordToGuess.ToCharArray());
        }

        private void PerformChoice(char character)
        {
            if (IsGuessCorrect(character))
            {
                ReplacePlaceholdersWithCharacter(character);

                if (IsGuessComplete())
                {
                    keyboard.Enabled = false;
                    MessageBox.Show("Well done! You've saved the man!", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DrawBodyPart();

                if (IsGallowComplete())
                {
                    keyboard.Enabled = false;
                    ShowRightGuess();
                    MessageBox.Show("Game Over! You've been hanged!", "Defeat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetGame()
        {
            foreach (cuiButton btn in keyboard.Controls.OfType<cuiButton>())
            {
                btn.Enabled = true;
                btn.NormalBackground = Color.White;
            }

            keyboard.Enabled = true;
            _counter = 0;

            this.Invalidate();
            frmGame_Load(null, null);
        }

        private void PerformClick(object sender, EventArgs e)
        {
            cuiButton button = sender as cuiButton;

            char character = Convert.ToChar(button.Tag.ToString().Trim());

            button.Enabled = false;
            button.NormalBackground = Color.Silver;

            PerformChoice(character);
        }

        private void DrawLine(Graphics g, int x1, int y1, int x2, int y2, int width, Color color)
        {
            using (Pen pen = new Pen(color, width))
            {
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void DrawBody(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 449, 130, 449, 220, 3, Color.White);
        }

        private void DrawLeftLeg(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 449, 220, 488, 250, 3, Color.White);
        }

        private void DrawRightLeg(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 449, 220, 410, 250, 3, Color.White);
        }

        private void DrawLeftHand(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 449, 150, 488, 170, 3, Color.White);
        }

        private void DrawRightHand(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 449, 150, 410, 170, 3, Color.White);
        }

        private void DrawHead(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.White, 3))
            {
                g.DrawEllipse(pen, 434, 100, 30, 30);
            }
        }

        private void DrawGallows(object sender, PaintEventArgs e)
        {
            DrawLine(e.Graphics, 330, 290, 430, 290, 3, Color.White);
            DrawLine(e.Graphics, 360, 290, 360, 80, 3, Color.White);
            DrawLine(e.Graphics, 360, 80, 450, 80, 3, Color.White);
            DrawLine(e.Graphics, 450, 80, 450, 100, 3, Color.White);
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            DrawGallows(sender, e);

            if (_counter >= 1)
            {
                DrawHead(sender, e);
            }

            if (_counter >= 2)
            {
                DrawBody(sender, e);
            }

            if (_counter >= 3)
            {
                DrawRightHand(sender, e);
            }

            if (_counter >= 4)
            {
                DrawLeftHand(sender, e);
            }

            if (_counter >= 5)
            {
                DrawRightLeg(sender, e);
            }

            if (_counter >= 6)
            {
                DrawLeftLeg(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCloseEvent_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            _wordToGuess = Word.GetRandomWord();

            SetPlaceholders();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
