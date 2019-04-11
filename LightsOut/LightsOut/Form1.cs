using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Reset();
            Populate();
        }

    

        private void Button26_Click(object sender, EventArgs e)
        {
            Reset();
            Populate();
            Count();
        }

                                    
            private int[] getSquares()
        {
            Random randNum = new Random();
            int[] squares = new int[12];
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 12)
            {
                numbers.Add(randNum.Next(0, 26));
            }
            squares = numbers.ToArray();
            return squares;
        }

        private void Reset()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name is "button26") { }

                else { if (control.Name != "button26") { control.BackColor = Color.Green; } }
            }

        }

        private void Populate()
        {
            string button;
            for (int i = 0; i < getSquares().Length; i++)
            {
                button = getSquares()[i].ToString();
                foreach (Control control in this.Controls)
                {
                    if (control.Name.Remove(0, 6) == button & control.BackColor != Color.Yellow) { control.BackColor = Color.Yellow; break; }

                    else { if ((control.BackColor != Color.Yellow) && (control.Name != "button26")) { control.BackColor = Color.Green; } }
                }

            }
                       
        }

        private void OnOff(int button)
        {
            string buttonString = button.ToString();
            foreach (Control c in this.Controls)
            {
                if ((c.Name.Remove(0, 6) == buttonString) && (c.Name != "button26"))
                {
                    if (c.BackColor == Color.Yellow)
                    {
                        c.BackColor = Color.Green;
                    }
                    else if (c.BackColor == Color.Green)
                    {
                        c.BackColor = Color.Yellow;
                    }
                    break;
                }

                else { }
            }

        }
        private void Count()
        { string color = button1.BackColor.ToString();
            foreach (Control c in this.Controls)
            {
                if (Convert.ToInt16(c.Name.Remove(0, 6)) < 26)
                {
                    if (c.BackColor.ToString() != color) { return; }
                    else
                    {
                        MessageBox.Show("Congratulations !");
                    }
                }
            }
        }

        private void Switch(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int i = Convert.ToInt16(control.Name.ToString().Remove(0, 6));

            Button[,] lights = new Button[5, 5];
            string button = i.ToString();
            OnOff(i);

            var bothorizontal = new[] { 22, 23, 24};
            var leftvertical = new[] { 6, 11, 16};
            var tophorizontal = new[] { 2, 3, 4};
            var righvertical = new[] { 10, 15, 20 };
            var middle9 = new[] { 7, 8, 9, 12, 13, 14, 17, 18, 19 };
           
            if (middle9.Contains(i))
            {
                OnOff(i + 1);
                OnOff(i - 1);
                OnOff(i - 5);
                OnOff(i + 5);
                
            }

            if (leftvertical.Contains(i))
            {
                OnOff(i + 1);
                OnOff(i - 5);
                OnOff(i + 5);
                
            }

            if (righvertical.Contains(i))
            {
                OnOff(i - 1);
                OnOff(i - 5);
                OnOff(i + 5);
                
            }
            if (bothorizontal.Contains(i))
            {
                OnOff(i + 1);
                OnOff(i - 1);
                OnOff(i + 5);
                
            }
            if (tophorizontal.Contains(i))
            {
                OnOff(i - 1);
                OnOff(i - 5);
                OnOff(i + 5);
                
            }
            switch (i)
            {
                case 1:
                    OnOff(i + 1);
                    OnOff(i +5);
                    break;
                case 5:
                    OnOff(i - 1);
                    OnOff(i + 5);
                    break;
                case 21:
                    OnOff(i +1);
                    OnOff(i - 5);
                    break;
                case 25:
                    OnOff(i - 1);
                    OnOff(i - 5);
                    break;
            }





        }
    }
}
