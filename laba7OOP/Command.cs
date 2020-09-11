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

namespace laba7OOP { 
    class Command {
        virtual public void execute() { }
        virtual public void execute(CPoint p, int MAXx, int MAXy) { }
        virtual public void unexecute() { }
        virtual public bool  IsA(string name) {
            if (name == "Command")
                return true;
            else return false;
        }
        virtual public Command clon() { return new Command(); }
    }

    class MoveCommand: Command {
        private CPoint p;
        private int dx;
        private int dy;
        private Keys e;
        private int MAXx;
        private int MAXy;

        public MoveCommand(int _dx, int _dy, Keys _e) {
            dx = _dx;
            dy = _dy;
            e = _e;
            p = null;
            MAXx = 0;
            MAXy = 0;
        }

        override public void execute() {
            if(p != null) {
                if (p.IsObjectInForm(e, MAXx, MAXy) == true)
                    p.move(dx, dy);
            }
        }

        override public void execute(CPoint x, int _MAXx, int _MAXy) {
            p = x;
            MAXx = _MAXx;
            MAXy = _MAXy;
            if (p.IsObjectInForm(e, MAXx, MAXy) == true)
                p.move(dx, dy);           
        }

        override public void unexecute() {
            if (p != null)
                p.move(-dx, -dy);
        }

        override public Command clon() {
            return new MoveCommand(dx, dy, e);
        }
    }

    class ResizeCommand: Command {
        private CPoint p;
        private int change;
        private Keys e;
        private int MAXx;
        private int MAXy;

        public ResizeCommand(int _change, Keys _e){
            change = _change;
            e = _e;
            p = null;
        }

        override public void execute(){
            if (p != null) {
                if (p.IsObjectInForm(e, MAXx, MAXy) == true)
                    p.resize(change);
            }
        }

        override public void execute(CPoint x, int _MAXx, int _MAXy) {
            p = x;
            MAXx = _MAXx;
            MAXy = _MAXy;
            if (p.IsObjectInForm(e, MAXx, MAXy) == true)
                p.resize(change);
        }

        override public void unexecute() {
            if (p != null) {
                if (p.IsObjectInForm(e, MAXx, MAXy) == true)
                    p.resize(change);
            }
        }

        override public Command clon() {
            return new ResizeCommand(change, e);
        }
    }

    class CreateCommand : Command {
        CMyPointFactory factory;
        string classname;
        CPoint p;
        MyStorage storage;
        int i = 0;
        int x = 0;
        int y = 0;

        public CreateCommand(){
            factory = new CMyPointFactory();
            p = null;
        }    

        public void execute(string _classname, int _x, int _y, MyStorage _storage) {
            classname = _classname;
            x = _x;
            y = _y;
            storage = _storage;
            p = factory.createPoint(classname, x, y);
            i = storage.setObject(p);
        }

        override public void execute() {
            p = factory.createPoint(classname, x, y);
            i =  storage.setObject(p);
        }

        override public void unexecute() {
            storage.deleteObject(i); 
        }

        override public Command clon() {
            return new CreateCommand();
        }        
    }

    class LoadCommand: Command {
        private MyStorage storage;
        private MyStorage copy;
        private string readFile;

        public LoadCommand() {
            storage = new MyStorage();
            readFile = null;
        }


        public void execute(string _readFile, MyStorage _storage) {
            storage = _storage;
            copy = _storage;
            readFile = _readFile;
            storage.loadFromFile(readFile);
        }

        public override void execute() {
            storage.loadFromFile(readFile);
        }

        override public void unexecute() {
            storage = copy; 
        }

        override public Command clon(){
            return new LoadCommand();
        }
    }

    class GroupCommand: Command {
        private MyStorage storage;
        CGroup g;
        int i;

        public GroupCommand() {
            i = 0;
        }

        public void execute(MyStorage _storage){
            storage = _storage;
            i = storage.groupChoosen();
        }

        public override void execute() {
            i = storage.groupChoosen();
        }

        public override void unexecute() {
            g = (CGroup)storage.getObject(i);
            g.ungroup(storage, i);
        }

        public override Command clon() {
            return new GroupCommand();
        }
    }

    class UngroupCommand: Command {
        private MyStorage storage;
        CGroup g;
        int i;

        public UngroupCommand() {
            i = 0;
        }

        public void execute(MyStorage _storage) {
            storage = _storage;
            storage.ungroupChoosen();
        }

        public override void execute() {
           storage.ungroupChoosen();
        }

        public override void unexecute() {
            storage.groupChoosen();
        }

        public override Command clon() {
            return new GroupCommand();
        }

    }

    class DeleteCommand: Command {
        MyStorage storage;
        private CPoint[] objects;
        private int Count;

        public DeleteCommand() {
            Count = 0;
        }

        public void execute(MyStorage _storage) {
            storage = _storage;
            Count = storage.getNumSelected();
            objects = new CPoint[Count];
            int k = 0;
            for(int i = storage.getCount() - 1; i >= 0; i--) {
                if(storage.getObject(i).IsObjectSelected() == true) {
                    objects[k] = storage.getObject(i);
                    storage.deleteObject(i);
                    k++;
                }
            }
        }

        override public void execute() {
            for (int i = storage.getCount() - 1; i >= 0 ; i--) {
                if (storage.getObject(i).IsObjectSelected() == true)
                    storage.deleteObject(i);
            }
        }

        public override void unexecute() {
            for (int i = 0; i < Count; i++)
                storage.setObject(objects[i]);
        }

        public override Command clon() {
            return new DeleteCommand();
        }
    }

    class ChangeColorCommand : Command {
        Color mycolor;
        Color[] p;
        int count;
        MyStorage storage;

        public ChangeColorCommand() { }

        public void execute(MyStorage _storage, Color _mycolor) {
            storage = _storage;
            mycolor = _mycolor;
            count = storage.getNumSelected();
            int k = 0;
            p = new Color[count];
            for (int i = 0; i < storage.getCount(); i++) {
                if (storage.getObject(i).IsObjectSelected() == true) {
                    p[k] = storage.getObject(i).getColor();
                    storage.getObject(i).setСolor(mycolor);
                    k++;
                }
            }

        }

        public override void execute() {
            for (int i = 0; i < storage.getCount(); i++) {
                if (storage.getObject(i).IsObjectSelected() == true) {
                    storage.getObject(i).setСolor(mycolor);
                }
            }
        }

        public override void unexecute() {
            int k = 0;
            for (int i = 0; i < storage.getCount(); i++) {
                if (storage.getObject(i).IsObjectSelected() == true) {
                    storage.getObject(i).setСolor(p[k]);
                    k++;
                }
            }
        }

        public override Command clon() {
            return new ChangeColorCommand();
        }


    }

    class SelectCommand: Command {
        MyStorage storage;
        int index;

        public SelectCommand() {
            index = 0;
        }

        public void execute(MyStorage _storage, int _ind) {
            storage = _storage;
            index = _ind;
            storage.getObject(index).select();
            storage.notifyEveryone();
            
        }

        override public void execute() {
            storage.getObject(index).select();
        }

        public override void unexecute() {
            storage.getObject(index).select();
        }

        public override Command clon() {
            return new SelectCommand();
        }

    }

    class StickyObjCommand : Command {
        MyStorage storage;
        CStickyObject obj;
        int index;

        public StickyObjCommand() {
            index = 0;
        }

        public void execute(MyStorage _storage, int _ind)  {
            storage = _storage;
            index = _ind;
            obj = new CStickyObject(storage.getObject(index));
            storage.deleteObject(index);
            index = storage.setObject(obj);
            Console.WriteLine(index);
        }

        override public void execute() {
            obj = new CStickyObject(storage.getObject(index));
            storage.deleteObject(index);
            index = storage.setObject(obj);
        }

        public override void unexecute() {            
            storage.deleteObject(index);
            index = storage.setObject(obj.getCPoint());

        }

        public override Command clon() {
            return new StickyObjCommand();
        }

    }

    class MoveByMouseCommand : Command {
        private Dictionary<int, CPoint> points;
        Stack<int> historyX;
        Stack<int> historyY;
        private int count;
        private int x;
        private int y;
        private int MAXx;
        private int MAXy;

        public MoveByMouseCommand() {
            MAXx = 0;
            MAXy = 0;
            count = 0;
            x = 0;
            y = 0;
            points = new Dictionary<int, CPoint>();
            historyX = new Stack<int>();
            historyY = new Stack<int>();
        }

        public void addPoint(CPoint point, MouseEventArgs e) {
            points.Add(count, point);
            x = e.X;
            y = e.Y;
            historyX.Push(point.getX());
            historyY.Push(point.getY());
            count++;
        }

        public void execute(MouseEventArgs e) {
            if (points != null) {
                for (int i = 0; i < count; i++) {
                    points[i].move(e.X - x, e.Y - y);
                    
                }
                x = e.X;
                y = e.Y;
            }
        }

        override public void execute () {
           for(int i = 0; i < count; i++) {
                points[i].move(x - points[i].getX(), y - points[i].getY());
            }

        }

        override public void unexecute() {
            for(int  i = count - 1; i >= 0; i--) {
                points[i].move(historyX.Pop() - x, historyY.Pop() - y);
            }
        }

        public void stopMove() {

        }

        override public Command clon() {
            return new MoveByMouseCommand();
        }

        override  public bool IsA(string name) {
            if (name == "Command" || name  == "MoveByMouseCommand")
                return true;
            else return false;
        }
    }
}
