using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        Vector Vector { get; set; }
        Point Button1Center { get => new Point(this.button1.Location.X + this.button1.Size.Width / 2, this.button1.Location.Y + this.button1.Size.Height / 2); }
        public Form1()
        {
            InitializeComponent();
            this.Vector = new Vector();
            this.Vector.OnChanged += Vector_OnChanged;
            Vector.P2 = this.Button1Center;
            IterateControls(this);

            Button[] buttons = { this.button1, this.button2 };
        }

        private void IterateControls(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                control.Controls[i].MouseMove += Control_MouseMove;
                IterateControls(control.Controls[i]);
            }
        }

        Point ToFormCoordinates(Control control, Point position)
        {
            Point parentLocation = AddParentLocation(control);

            Point result = new Point(parentLocation.X + position.X, parentLocation.Y + position.Y);

            return result;
        }

        Point AddParentLocation(Control control)
        {
            Point parentLocation = new Point();

            if (control.Parent != null && control.Parent != this)
            {
                parentLocation = AddParentLocation(control.Parent);
            }

            return new Point(control.Location.X + parentLocation.X, control.Location.Y + parentLocation.Y);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Control current = sender as Control;



            Point p = ToFormCoordinates(current, e.Location);
            this.txtX.Text = p.X.ToString();
            this.txtY.Text = p.Y.ToString();

            Vector.P1 = p;
        }

        private void Vector_OnChanged(Vector v)
        {
            this.txtVLength.Text = v.Length.ToString();
            int len = 75 - v.Length;
            if(len > 0)
            {
                int newX = 0;
                int newY = 0;

                int deltaX = v.P2.X - v.P1.X;
                int deltaY = v.P2.Y - v.P1.Y;

                if(Math.Abs(deltaX) > this.button1.Size.Width * 0.15)
                {
                    newX =  75 / deltaX;
                }

                if (Math.Abs(deltaY) > this.button1.Size.Height * 0.15)
                {
                    newY = 75 / deltaY;
                }

                this.button1.Location = new Point(this.button1.Location.X + newX, this.button1.Location.Y + newY);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка була натиснута!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            this.txtX.Text = p.X.ToString();
            this.txtY.Text = p.Y.ToString();

            Vector.P1 = p;
        }

        private void button1_LocationChanged(object sender, EventArgs e)
        {
            Button b = sender as Button;
            this.txtBX.Text = b.Location.X.ToString();
            this.txtBY.Text = b.Location.Y.ToString();
            Vector.P2 = this.Button1Center;
        }
    }
}
