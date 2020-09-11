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
    class CPoint: CObserver {
        protected int x, y;
        protected bool selected;
        protected Color ObjColor = Color.Black;
        protected GraphicsPath myPath = new GraphicsPath();

        public CPoint() {
            selected = true;
        }

        public CPoint(int _x, int _y) {
            x = _x;
            y = _y;
            selected = true;
        }

        public int getX() {
            return x;
        }

        public int getY() {
            return y;
        }

        virtual public int getA() { 
            return 0;
        }

        virtual public GraphicsPath getPath() {
            return myPath;
        }

        public Color getColor() {
            return ObjColor;
        }

        public virtual string classname() {
            return "CPoint";
        }

        public virtual bool IsA(string name) {
            if (name == "CPoint")
                return true;
            else return false;
        }

        public virtual void Draw(PaintEventArgs e) { }

        public virtual bool IsMouseInObject(MouseEventArgs e) {
            return false;
        }

        public virtual void select() { }

        virtual public bool IsObjectSelected() {
            return selected;
        }

        public void setX(int _x) {
            x = _x;
        }

        public void setY(int _y) {
            y = _y;
        }

        virtual public bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            return false;
        }

        public void setСolor(Color mycolor) {
            ObjColor = mycolor;
        }

        virtual public void move(int dx, int dy) {
            x = x + dx;
            y = y + dy;
        }

        virtual public void resize(int change) { }

        virtual public void load(StreamReader reader, CMyPointFactory factory) { }

        virtual public void save(StreamWriter writer) { }

        public  void onSubjectChanged(CStickyObject point) {
            move(point.getDX(), point.getDY());
        }
    }
}
