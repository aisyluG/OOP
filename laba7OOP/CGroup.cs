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

namespace laba7OOP
{
    class CGroup : CPoint {
        CPoint[] group;
        int size;
        int count;

        public CGroup() : base() { }

        public CGroup(int k) {
            size = k;
            count = 0;
            group = new CPoint[size];
            selected = true;
        }

        public int getCount() {
            return count;
        }

        override public string classname() {
            return "CGroup";
        }

        public CPoint getObj(int i) {
            return group[i];
        }

        public bool addToGroup(CPoint p) {
            if (count != size) {
                group[count] = p;
                count++;
            }
            else
                return false;
            return true;
        }

        override public bool IsA(string name) {
            if (name == "CPoint" || name == "CGroup")
                return true;
            else return false;
        }

        override public void Draw(PaintEventArgs e) {
            for (int i = 0; i < count; i++) {
                group[i].Draw(e);
            }
        }

        override public bool IsMouseInObject(MouseEventArgs e) {
            for (int i = 0; i < count; i++) {
                if (group[i].IsMouseInObject(e) == true)
                    return true;
            }
            return false;
        }

        override public void select() {
            for (int i = 0; i < count; i++) {
                group[i].select();
            }
            if (selected == true)
                selected = false;
            else
                selected = true;
        }

        override public bool IsObjectInForm(Keys e, int MAXx, int MAXy) {
            for(int i = 0; i < count; i++) {
                if (group[i].IsObjectInForm(e, MAXx, MAXy) == false)
                    return false;
            }
            return true;
        }

        override public void move(int dx, int dy) {
            for (int i = 0; i < count; i++)
                group[i].move(dx, dy);
        }

        override public void resize(int change) {
            for (int i = 0; i < count; i++) 
                group[i].resize(change);
        }

        public void ungroup(MyStorage storage, int k) {
            for (int i = count - 1; i >= 0; i--) {
                storage.setObject(group[i]);
            }
            storage.deleteObject(k);
        }

        public override void save(StreamWriter writer) {
            writer.WriteLine("Group");
            writer.WriteLine($"Объектов в группе: {count}");
            for (int i = 0; i < count; i++)
                group[i].save(writer);
        }

        public override void load(StreamReader reader, CMyPointFactory factory) {
            string line = reader.ReadLine();
            string[] split = line.Split(new Char[] { ' ', ',', '(', ')', '\n' });
            count = Convert.ToInt32(split[3]);
            group = new CPoint[count];
            for (int i = 0; i < count; i++) {
                line = reader.ReadLine();
                group[i] = factory.createPoint(line);
                group[i].load(reader, factory);               
            }
        }

    }
}
