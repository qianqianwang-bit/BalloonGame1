using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace BalloonGame
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 气球列表
        /// </summary>
        ///
        
        List<Balloon> balloons = new List<Balloon>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Balloon balloon in balloons)
            {
                balloon.Up(this.ClientRectangle.Height,this.ClientRectangle.Width);
            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Balloon balloon in balloons)
            {
           
                balloon.Draw(e.Graphics);
            }
          
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                Balloon balloon = new Balloon
                {
                    X = random.Next(0, this.ClientRectangle.Width),
                    Y = this.ClientRectangle.Height,
                    Speed = random.Next(5, 10),
                    Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                    With = random.Next(80, 120)
                };
                balloons.Add(balloon);
                
            }
           
            timer1.Start();
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @"H:\c#窗体练习\BalloonGame\BalloonGame\July - 봄의 태양.wav";
            sp.PlayLooping();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = balloons.Count - 1; i >= 0; i--)
            {
                Balloon balloon = balloons[i];


                if (balloon.IsHit(e.X, e.Y))
                {
                    Random random = new Random();
                    balloons.RemoveAt(i);
                    NewBalloon();                 
                    break;
                }
                
            }
        }
        private void Form1_MouseEnter(object sender,EventArgs e)//追气球
        {
            
        }
        private void NewBalloon()
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(10,100); i++)
            {
                
                    Balloon balloon = new Balloon
                    {
                        X = random.Next(0, this.ClientRectangle.Width),
                        Y = random.Next(0, this.ClientRectangle.Height),
                        Speed = random.Next(20,30),
                        Color = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                        With = random.Next(10, 50)
                    };
                    balloons.Add(balloon);
            }
        }
        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            for (int i = balloons.Count - 1; i >= 0; i--)
            {
                Balloon balloon = balloons[i];
                if (balloon.IsEnter(e.X, e.Y))
                {
                    balloons[i].X = random.Next(0, ClientSize.Width - 1);
                    balloons[i].Y = random.Next(0, ClientSize.Height - 1);
                }
               }
            }

            private void button1_Click(object sender, EventArgs e)
        {
            if (balloons.Count >21)
            {
                MessageBox.Show("你赢了");
                this.Close();
            }
            else
            {
                MessageBox.Show("你输了");
                this.Close();
                
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = balloons.Count.ToString();
            //MessageBox.Show($"当前气球个数{balloons.Count}");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
