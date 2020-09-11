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
    class CSegment : CPoint {
        //Point p;
        int len; //длина отрезка

        public CSegment() : base() { }

        public CSegment(int _x, int _y) : base(_x, _y) {
            len = 40;
            myPath.AddLine(x, y, x + len, y);
        }

        override public bool IsObjectSelected() {
            return selected;
        }

        override public string classname() {
            return "CSegment";
        }

        override public void select() {
            if (selected == false)
                selected = true;
            else
                selected = false;
        }

        override public void Draw(PaintEventArgs e) {
            myPath.Reset();
            myPath.AddLine(x, y, x + len, y);
            if (selected == true) {
                e.Graphics.DrawLine(new Pen(ObjColor, 2), x, y, x + len, y);
            }
            else {
                e.Graphics.DrawLine(new Pen(ObjColor), x, y, x + len, y);
            }
        }

        override public bool IsA(string name) {
            if (name == "Point" || name == "CSegment")
                return true;
            else return false;
        }

        override public bool IsMouseInObject(MouseEventArgs e) {
            if (x <= e.X && x + len >= e.X && y + 2 >= e.Y && y - 2 <= e.Y)
                return true;
            else
                return false;
        }

        public override bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            switch (e) {
                case Keys.Up:
                    if (y - 2 >= 27)
                        return true;
                    break;
                case Keys.Down:
                    if (y + 2 <= MAXy)
                        return true;
                    break;
                case Keys.Left:
                    if (x - 2 >= 0)
                        return true;
                    break;
                case Keys.Right:
                    if (x + len + 2 <= MAXx)
                        return true;
                    break;
                case Keys.Add:
                    if (x - 2 >= 0 && x + len + 2 <= MAXx)
                        return true;
                    break;
                case Keys.Subtract:
                    if (len > 2)
                        return true;
                    break;
            }
            return false;
        }

        public override void resize(int change) {
            x = x - change;
            len = len + 2*change;
        }

        public override void save(StreamWriter writer) {
            writer.WriteLine("Segment");
            writer.WriteLine("l - длина, (x,y) - координаты начала отрезка.");
            writer.WriteLine($"l = {len}, ({x},{y}), {ObjColor}");
        }

        public override void load(StreamReader reader, CMyPointFactory factor) {
            reader.ReadLine();
            string line = reader.ReadLine();
            string[] split = line.Split(new Char[] {' ', ',', '(', ')', '[',']','\n'});
            len = Convert.ToInt32(split[2]);
            x = Convert.ToInt32(split[5]);
            y = Convert.ToInt32(split[6]);
            ObjColor = Color.FromName(split[11]);
        }
    }
}
