using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public delegate void VectorChangedHandler(Vector v);
    public class Vector
    {
        private Point p1;
        private Point p2;

        public event VectorChangedHandler OnChanged;
        public Point P1 
        { 
            get => p1; 
            set
            {
                Point oldValue = p1;
                p1 = value;
                if(p1 != oldValue)
                {
                    OnChanged?.Invoke(this);
                }
            }
        }
        public Point P2
        {
            get => p2;
            set
            {
                Point oldValue = p2;
                p2 = value;
                if(p2 != oldValue)
                {
                    OnChanged?.Invoke(this);
                }
            }
        }
        public int Length
        {
            get
            {
                return (int)Math.Sqrt(Math.Pow(P2.X - P1.X, 2) + Math.Pow(P2.Y - P1.Y, 2));
            }
        }
    }
}
