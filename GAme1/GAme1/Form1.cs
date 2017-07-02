using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            this.BackColor = Color.AliceBlue;
            p1 = new Player(10,68);
            p2 = new Player(460,68);
            cube = new Cube(220,220);
                //Draw shapes
                
                //Calculations
        }

        Graphics g;
        Player p1, p2;
        Cube cube;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_Paint(sender, new PaintEventArgs(g, this.ClientRectangle));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Up)
            {
                p1.Move(-20);
            }
            else if (e.KeyChar == (char)Keys.Down)
            {
                p1.Move(20);
            }
            Form1_Paint(sender, new PaintEventArgs(g, this.ClientRectangle));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillRectangle(Brushes.Crimson, new Rectangle(0, 0, 500, 500));
            p1.Draw(g);
            p2.Draw(g);
            cube.Draw(g);
        }
    }

    public class Cube : Shape
    {
        public Cube(int x, int y)
        {
            X = x;
            Y = y;
            Width = 30;
            Height = 30;
        }
    }

    public class Player : Shape
    {
        
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Width = 30;
            Height = 125;
        }
    }

    public class Shape : Pos
    {
        private int _width, _height;
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.White,X,Y,Width,Height);
        }
    }

    public class Pos
    {
        private int _x, _y;
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }

        public void Move(int y)
        {
            Y += y;
        }
    }
}
