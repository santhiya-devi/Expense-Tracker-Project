using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI.Home
{
    public partial class Logo : UserControl
    {
        public Logo()
        {
            InitializeComponent();
            timer1.Start();
            gif.Hide();
            pictureBox2.Hide();
            pictureBox4.Hide();
            this.BackColor = GUIStyles.primaryColor;
            panel1.Location = new Point(panel1.Location.X, 120);
        }

        int count = 0, stop = 0, show = 0;
        bool flag = false;
        public event EventHandler TimerStop;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!flag)
            {
                count++;
                if (count >= 5)
                {
                    pictureBox1.Hide();
                    pictureBox4.Location = new Point(307, 98);
                    pictureBox4.Show();
                    if (count == 6)
                    {
                        pictureBox4.Location = new Point(307, 98);
                    }
                    if (count == 7)
                    {
                        pictureBox4.Location = new Point(383, 120);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 8)
                    {
                        pictureBox4.Location = new Point(412, 184);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 9)
                    {
                        pictureBox4.Location = new Point(347, 210);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 10)
                    {
                        pictureBox4.Location = new Point(262, 210);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 11)
                    {
                        pictureBox4.Location = new Point(195, 184);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 12)
                    {
                        pictureBox4.Location = new Point(151, 127);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 13)
                    {
                        pictureBox4.Location = new Point(180, 62);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 14)
                    {
                        pictureBox4.Location = new Point(249, 11);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 15)
                    {
                        pictureBox4.Location = new Point(325, 11);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 16)
                    {
                        pictureBox4.Location = new Point(399, 30);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 17)
                    {
                        pictureBox4.Location = new Point(479, 53);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                    }
                    if (count == 18)
                    {
                        pictureBox4.Location = new Point(525, 96);
                        pictureBox4.Size = new Size(pictureBox4.Width + 5, pictureBox4.Height + 5);
                        pictureBox1.Size = pictureBox4.Size;
                        pictureBox1.Location = new Point(525, 96);
                    }
                    if (count > 18)
                    {
                        timer1.Stop();
                        pictureBox1.Show();
                        pictureBox4.Hide();
                        timer2.Start();
                    }
                }
            }
            else
            {
                stop++;
                gif.Show();
                if (stop == 20)
                {
                    TimerStop?.Invoke(this, EventArgs.Empty);
                }
            }            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            show++;
            panel3.Width -= 15;
            pictureBox1.Location = new Point(pictureBox1.Location.X - 15, 115);
            if (show <= 15)
            {
                pictureBox1.Size = new Size(pictureBox1.Width - 2, pictureBox1.Height - 2);
            }
            if (panel3.Width <= 70)
            {
                timer2.Stop();
                flag = true;
                timer1.Start();
                panel3.Hide();
            }
        }
    }
}