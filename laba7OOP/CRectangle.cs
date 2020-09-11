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
    class CRectangle : CPoint {
        private int a, b; // а - ширина, b - длина, x,y - центр прямоугльника

        public CRectangle() : base() { }

        public CRectangle(int _x, int _y) : base(_x, _y) {
            a = 40;
            b = 40;
        }

        override public int getA() {
            return a;
        }

        override public bool IsObjectSelected() { 
            return selected;
        }

        override public string classname() {
            return "CRectangle";
        }

        override public void select() {
            if (selected == false)
                selected = true;
            else
                selected = false;
        }

        override public void Draw(PaintEventArgs e) {
            RectangleF r = new RectangleF(x - a / 2, y - b / 2, a, b);
            myPath.Reset();
            myPath.AddRectangle(r);
            if (selected == true) {
                e.Graphics.DrawRectangle(new Pen(ObjColor, 2), x - a / 2, y - b / 2, a, b);
            }
            else {
                e.Graphics.DrawRectangle(new Pen(ObjColor), x - a / 2, y - b / 2, a, b);
            }
        }

        override public bool IsA(string name) {
            if (name == "Point" || name == "CRectangle")
                return true;
            else return false;
        }

        override public bool IsMouseInObject(MouseEventArgs e) {
            if (e.X > x - a / 2 && e.X < x + a / 2 && e.Y > y - b / 2 && e.Y < y + b / 2)
                return true;
            else
                return false;
        }
        override public bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            switch (e) {
                case Keys.Up:
                    if (y - b / 2 - 2 >= 27)
                        return true;
                    break;
                case Keys.Down:
                    if (y + b / 2 + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Left:
                    if (x - a / 2 - 2 >= 0)
                        return true;
                    break;
                case Keys.Right:
                    if (x + a / 2 + 2 <= MAXx)
                        return true;
                    break;
                case Keys.Add:
                    if (x + b / 2 + 2 <= MAXx && y + a / 2 + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Subtract:
                    if (b >= 4 && a >= 4)
                        return true;
                    break;
            }
            return false;
        }

        public override void resize(int change) {
            a = a + change;
            b = b + change;
        }

        public override void save(StreamWriter writer) {
            writer.WriteLine("Rectangle");
            writer.WriteLine("а - ширина, b - длина и (x,y) - координаты центра");
            writer.WriteLine($"a = {a}, b = {b}, ({x},{y}), {ObjColor}");
        }

        public override void load(StreamReader reader, CMyPointFactory factor) {
            reader.ReadLine();
            string line = reader.ReadLine();
            string[] split = line.Split(new Char[] { ' ', ',', '(', ')', '[', ']', '\n' });
            a = Convert.ToInt32(split[2]);
            b = Convert.ToInt32(split[6]);
            x = Convert.ToInt32(split[8]);
            y = Convert.ToInt32(split[9]);
            ObjColor = Color.FromName(split[14]);
        }
    }
}
