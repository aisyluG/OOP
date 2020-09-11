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
    class CCircle : CPoint {
        private int r;

        public CCircle() : base() { }

        public CCircle(int _x, int _y) : base(_x, _y) {
            r = 20;
            selected = true;
            myPath.AddEllipse(x + r, y + r, 2 * r, 2 * r);
        }

        override public int getA() {
            return r;
        }

        override public bool IsObjectSelected() {
            return selected;
        }

        override public string classname() {
            return "CCircle";
        }

        override public void select() {
            if (selected == false)
                selected = true;
            else
                selected = false;
        }

        override public void Draw(PaintEventArgs e) {
            myPath.Reset();
            myPath.AddEllipse(x - r, y - r, 2 * r, 2 * r);
            if (selected == true) {
                e.Graphics.DrawEllipse(new Pen(ObjColor, 2), x - r, y - r, r * 2, r * 2);
            }
            else
                e.Graphics.DrawEllipse(new Pen(ObjColor), x - r, y - r, r * 2, r * 2);
        }

        override public bool IsA(string name) {
            if (name == "Point" || name == "CCircle")
                return true;
            else return false;
        }

        override public bool IsMouseInObject(MouseEventArgs e) {
            int dx = (x - (e.X)) * (x - (e.X));
            int dy = (y - (e.Y)) * (y - (e.Y));
            int distance = dx + dy;
            if (Math.Sqrt(dx + dy) < r)
                return true;
            else
                return false;
        }

        override public bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            switch (e) {
                case Keys.Up:
                    if (y - r - 2 >= 27)
                        return true;
                    break;
                case Keys.Down:
                    if (y + r + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Left:
                    if (x - r - 2 >= 0)
                        return true;
                    break;
                case Keys.Right:
                    if (x + r + 2 <= MAXx)
                        return true;
                    break;
                case Keys.Add:
                    if (x - r - 2 >= 0 && y - r - 2 >= 27 && x + r + 2 <= MAXx && y + r + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Subtract:
                    if (r >= 4)
                        return true;
                    break;
            }
            return false;
        }

        public override void resize(int change) {
            r = r + change;
        }

        public override void save(StreamWriter writer) {
            writer.WriteLine("Circle");
            writer.WriteLine("r - радиус, (x,y) - координаты центра");
            writer.WriteLine($"r = {r}, ({x},{y}), {ObjColor}");
        }

        public override void load(StreamReader reader, CMyPointFactory factory) {
            reader.ReadLine();
            string line = reader.ReadLine();
            string[] split = line.Split(new Char[] { ' ', ',', '(', ')', '[', ']', '\n' });
            r = Convert.ToInt32(split[2]);
            x = Convert.ToInt32(split[5]);
            y = Convert.ToInt32(split[6]);
            ObjColor = Color.FromName(split[11]);
        }
    }
}
