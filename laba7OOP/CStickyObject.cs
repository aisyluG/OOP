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
    class CStickyObject: CPoint {
        private CPoint point;
        private Dictionary<int, CPoint> observers;
        private  int countObservers;
        private int dx;
        private int dy;

        public CStickyObject(CPoint _point) {
            point = _point;
            x = point.getX();
            y = point.getY();
            selected = true;
            countObservers = 0;
            observers = new Dictionary<int, CPoint>();
        }

        public CPoint getCPoint() {
            return point;
        }

        public int getDX() {
            return dx;
        }

        public int getDY() {
            return dy;
        }

        virtual public void addObserver(CPoint observer) {
            observers.Add(countObservers, observer);
            countObservers++;
        }

        public override void move(int _dx, int _dy) {
            base.move(_dx, _dy);
            point.move(_dx, _dy);
            dx = _dx;
            dy = _dy;
            notifyEveryone();
        }

        virtual public void notifyEveryone() {
            for (int i = 0; i < countObservers; i++){
                if (observers[i] != null)
                    observers[i].onSubjectChanged(this);
            }
        }

        public override string classname() {
            return point.classname();
        }

        public override bool IsA(string name) {
            if (point.IsA(name) == true || name == "CStickyObject")
                return true;
            else
                return false;
        }

        public override void Draw(PaintEventArgs e) {
            point.Draw(e);
        }

        public override bool IsMouseInObject(MouseEventArgs e) {
            return point.IsMouseInObject(e);
        }

        public override void select() {
            point.select();
            selected = point.IsObjectSelected();
        }

        public override bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            return point.IsObjectInForm(e, MAXx, MAXy);
        }

        public  override void resize(int change) {
            point.resize(change);
        }

        public override void load(StreamReader reader, CMyPointFactory factory) {
            point.load(reader, factory);
        }

        public override void save(StreamWriter writer) {
            point.save(writer);
        }

        public void roll(CPoint p) {
            bool flag = false;
            for(int i = 0; i < countObservers; i++) {
                if (observers[i] == p)
                    flag = true;
            }
            if(flag == false) {                
                foreach (PointF tP in p.getPath().PathPoints) {
                    foreach(PointF tPoint in point.getPath().PathPoints) {
                        if (Math.Abs(tPoint.X - tP.X) <= 2 &&  Math.Abs(tPoint.Y - tP.Y) <= 2) {
                            addObserver(p);
                            flag = true;
                            break;
                        }
                    }
                    if (flag == true)
                        break;
                }
            }
        }
    }
}

