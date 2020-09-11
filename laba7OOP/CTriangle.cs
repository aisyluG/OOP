using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace laba7OOP {
    class CTriangle : CPoint {
        private int a;//половина высоты треугольника
        PointF[] F;

        public CTriangle() : base() { }

        public CTriangle(int _x, int _y) : base(_x, _y) {
            a = 20;
           
        }

        override public bool IsObjectSelected() {
            return selected;
        }

        override public string classname() {
            return "CTriangle";
        }

        override public void select() {
            if (selected == false)
                selected = true;
            else
                selected = false;
        }

        override public void Draw(PaintEventArgs e) {
            Point[] F = new Point[3];
            F[0] = new Point(x, y - a);
            F[1] = new Point(x - a, y + a);
            F[2] = new Point(x + a, y + a);
            myPath.Reset();
            myPath.AddPolygon(F);
            if (selected == true) {
                e.Graphics.DrawPolygon(new Pen(ObjColor, 2), F);
            }
            else {
                e.Graphics.DrawPolygon(new Pen(ObjColor), F);
            }
        }

        override public bool IsA(string name) {
            if (name == "Point" || name == "CTriangle")
                return true;
            else return false;
        }

        override public bool IsMouseInObject(MouseEventArgs e) {
            if (e.X <= x + a && e.X >= x - a && e.Y <= y + a && e.Y >= y - a && e.Y >= 2 * e.X + y - a - 2 * x && e.Y >= -2 * e.X + y - a + 2 * x) 
                return true;
            else
                return false;
        }

        override public bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            switch (e) {
                case Keys.Up:
                    if (y - a - 2 >= 27)
                        return true;
                    break;
                case Keys.Down:
                    if (y + a + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Left:
                    if (x - a - 2 >= 0)
                        return true;
                    break;
                case Keys.Right:
                    if (x + a + 2 <= MAXx)
                        return true;
                    break;
                case Keys.Add:
                    if (x + a + 2 <= MAXx && y + a + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Subtract:
                    if (a >= 4)
                        return true;
                    break;
            }
            return false;
        }

        public override void resize(int change) {
            a = a + change;
        }

        public override void save(StreamWriter writer) {
            writer.WriteLine("Triangle");
            writer.WriteLine("h - высота, (x,y) - координаты центра");
            writer.WriteLine($"h = {2 * a}, ({x},{y}), {ObjColor}");
        }

        public override void load(StreamReader reader, CMyPointFactory factor) {
            reader.ReadLine();
            string line = reader.ReadLine();
            string[] split = line.Split(new Char[] { ' ', ',', '(', ')', '[', ']', '\n' });
            a = Convert.ToInt32(split[2]) / 2;
            x = Convert.ToInt32(split[5]);
            y = Convert.ToInt32(split[6]);
            ObjColor = Color.FromName(split[11]);
        }
    }
}
