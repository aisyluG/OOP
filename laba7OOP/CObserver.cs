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
    class CObject {
        protected Dictionary<int, CObserver> observers = new Dictionary<int, CObserver>();
        protected int countObservers;

        public CObject() {
            countObservers = 0;
        }

        virtual public void addObserver(CObserver observer) {
            observers.Add(countObservers, observer);
            countObservers++;
        }

        virtual public void notifyEveryone() {
            for(int i = 0; i < countObservers; i++)  {
                if (observers[i] != null)
                    observers[i].onSubjectChanged(this);
            }
        } 
    }

    class CObserver {
        public virtual void onSubjectChanged(CObject storage) { }
    }

    class CTree : CObserver{
        TreeView myTree;
        MyStorage storage;

        public CTree(TreeView mytree) {
            myTree = mytree;
            myTree.Nodes.Add("Objects", "Objects");
        }

        public TreeView getTree() {
            return myTree;
        }


        public override void onSubjectChanged(CObject _storage) {
           if (myTree.Nodes["Objects"].Nodes != null)
              myTree.Nodes["Objects"].Nodes.Clear();
            storage = (MyStorage)_storage;
           for (int i = 0; i < storage.getCount(); i++) //{
                processNode(myTree.Nodes["Objects"], storage.getObject(i), i);
            myTree.Focus();
            myTree.ExpandAll();
        }

        public void processNode(TreeNode tree, CPoint point, int k) {
            if (tree == null || tree.Nodes[point.classname()] == null) {
                tree.Nodes.Add(point.classname(), point.classname());
            }
            if (point.IsA("CGroup") == true) {
                tree.Nodes[point.classname()].Nodes.Add(k.ToString(), "group");
                CGroup g = (CGroup)point;
                for (int i = 0; i < g.getCount(); i++)
                    processNode(tree.Nodes["CGroup"].Nodes[k.ToString()], g.getObj(i), i);
            }
            else
                tree.Nodes[point.classname()].Nodes.Add(k.ToString(), $"({point.getX()}, {point.getY()})");            
            if (point.IsObjectSelected() == true)
                myTree.SelectedNode = tree.Nodes[point.classname()].LastNode;
        }        

        virtual public void notify() {
            storage.onSubjectChanged(this);
        }
    }
}
