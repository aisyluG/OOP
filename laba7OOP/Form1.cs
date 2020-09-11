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
    public partial class Form1 : Form {
        string readFile = @"D:\учеба\ооп\laba7OOP\storage.txt";
        string writeFile = @"D:\учеба\ооп\laba7OOP\storage.txt";
        int MAXx = 450;//макс размеры 
        int MAXy = 800;//формы
        string choosen = "Circle";//какая фигура создается
        MyStorage storage = new MyStorage(100);
        Dictionary<string, Command> commands = new Dictionary<String, Command>();
        Stack<Command> history = new Stack<Command>() ;
        Stack<Command> undo = new Stack<Command>();
        System.Windows.Forms.TreeView treeView1 = new System.Windows.Forms.TreeView();
        CTree tree;

        public Form1() {
            InitializeComponent();
            commands.Add("Down", new MoveCommand(0, 2, Keys.Down));
            commands.Add("Up", new MoveCommand(0, -2, Keys.Up));
            commands.Add("Right", new MoveCommand(2, 0, Keys.Right));
            commands.Add("Left", new MoveCommand(-2, 0, Keys.Left));
            commands.Add("Add", new ResizeCommand(2, Keys.Add));
            commands.Add("Subtract", new ResizeCommand(-2, Keys.Subtract));
            commands.Add("Create", new CreateCommand());
            commands.Add("Load", new LoadCommand());
            commands.Add("Group", new GroupCommand());
            commands.Add("Ungroup", new UngroupCommand());
            commands.Add("Delete", new DeleteCommand());
            commands.Add("Select", new SelectCommand());
            commands.Add("ChangeColor", new ChangeColorCommand());
            commands.Add("StickyObject", new StickyObjCommand());
            commands.Add("MoveByMouse", new MoveByMouseCommand());
            
            treeView1.BackColor = System.Drawing.SystemColors.ControlLight;
            treeView1.Dock = System.Windows.Forms.DockStyle.Right;
            treeView1.Location = new System.Drawing.Point(800 - 150, 28);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(150, 423);
            treeView1.TabIndex = 1;
            treeView1.Anchor = AnchorStyles.Top;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            tree = new CTree(treeView1);
            storage.addObserver(tree);
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.ClientSize = new System.Drawing.Size(800, 450);
        }

        private void Form1_Resize(object sender, EventArgs e) {//при изменении размеров формы
            MAXx = this.ClientSize.Width;
            MAXy = this.ClientSize.Height;
        }

        private void btCircle_Click(object sender, EventArgs e) {
            choosen = "Circle";
            toolStripLabel1.Text = "Круг";
        }

        private void btRectangle_Click(object sender, EventArgs e) {
            choosen = "Rectangle";
            toolStripLabel1.Text = "Прямоугольник";
        }

        private void btTriangle_Click(object sender, EventArgs e) {
            choosen = "Triangle";
            toolStripLabel1.Text = "Треугольник";
        }

        private void btSegment_Click(object sender, EventArgs e) {
            choosen = "Segment";
            toolStripLabel1.Text = "Отрезок";
        }

        private void btCursor_Click(object sender, EventArgs e) {
            choosen = "Cursor";
            toolStripLabel1.Text = "Указатель";
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {//рисование на форме
            for (int i = 0; i < storage.getCount(); i++)
                storage.getObject(i).Draw(e);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {//создание и выделение объектов 
            bool flag = false;
            for(int i = 0; i < storage.getCount(); i++) {
                if(storage.getObject(i).IsMouseInObject(e) == true) {
                    SelectCommand ch = new SelectCommand();
                    ch.execute(storage, i);
                    history.Push(ch);
                    flag = true;
                }
                //treeView1.Focus();
                //storage.notifyEveryone();
                this.Focus();
            }
            if (flag == false) {
                for (int i = 0; i < storage.getCount(); i++) {
                    if (storage.getObject(i).IsObjectSelected() == true) {
                        SelectCommand ch = new SelectCommand();
                        ch.execute(storage, i);
                        history.Push(ch);
                        flag = true;
                    }
                }
                if (choosen != "Cursor") {
                    CreateCommand create = (CreateCommand)commands["Create"].clon();
                    create.execute(choosen, e.X, e.Y, storage);
                    history.Push(create);
                }                   
            }
            btUnexecute.Enabled = true;
            this.Refresh();
        }

        private void btColor_Click(object sender, EventArgs e) {//изменение цвета 
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                Color mycolor = colorDialog1.Color;
                ChangeColorCommand g = new ChangeColorCommand();
                g.execute(storage, mycolor);
                history.Push(g);
            }
            this.Refresh();  
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e){//движение и изменение размера объектов
            try {
                storage.ChangeChoosenObjects(commands[$"{e.KeyCode}"], MAXx, MAXy, history);
                this.Refresh();
            }
            catch { }
        }

        private void btGroup_Click(object sender, EventArgs e) {//группировка объектов
            //GroupCommand g = (GroupCommand)commands["Group"].clon();
            GroupCommand g = new GroupCommand();
            g.execute(storage);
            history.Push(g);
        }

        private void btUngroup_Click(object sender, EventArgs e) {//разгруппировка
            UngroupCommand u = (UngroupCommand)commands["Ungroup"].clon();
            u.execute(storage);
            history.Push(u);
        }

        private void btSave_Click(object sender, EventArgs e) {//кнопка сохранения
            DialogResult result = MessageBox.Show("Вы уверены, что хотите сохранить объекты в файл?", "Сохранение", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                if(SaveToFile.ShowDialog() == DialogResult.OK) {
                    writeFile = SaveToFile.FileName;
                    storage.saveToFile(writeFile);
                }
            }
        }

        private void btLoad_Click(object sender, EventArgs e) {//кнопка загрузки
            DialogResult result = MessageBox.Show("Вы уверены, что хотите загрузить объекты из файла?", "Загрузка",MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                if(OpenFile.ShowDialog() == DialogResult.OK) {
                    readFile = OpenFile.FileName;
                    LoadCommand load = (LoadCommand)commands["Load"].clon();
                    load.execute(readFile, storage);
                    history.Push(load);
                }
            }          
            this.Refresh();
        }

        private void btUnexecute_Click(object sender, EventArgs e) {//отмена действия
            if (history.Count != 0) {
                history.Peek().unexecute();
                undo.Push(history.Pop());
                if (history.Count == 0)
                    btUnexecute.Enabled = false; 
                btExecute.Enabled = true;
                this.Refresh();
            }
        }

        private void btExecute_Click(object sender, EventArgs e) {//вернуть действие
            if(undo.Count != 0) {
                undo.Peek().execute();
                history.Push(undo.Pop());
                if (undo.Count == 0)
                    btExecute.Enabled = false;
                btUnexecute.Enabled = true;
                this.Refresh();
            }
        }

        private void btDelete_Click(object sender, EventArgs e) {//удалить выбранные
            DeleteCommand d = (DeleteCommand)commands["Delete"].clon();
            d.execute(storage);
            history.Push(d);
            this.Refresh();
        }

        private void btSelectAll_Click(object sender, EventArgs e) {
            for (int i = 0; i < storage.getCount(); i++) {
                if (storage.getObject(i) != null && storage.getObject(i).IsObjectSelected() == false) {
                    SelectCommand ch = new SelectCommand();
                    ch.execute(storage, i);
                    history.Push(ch);
                }
            }
            this.Refresh();
        }

        private void btDeleteAll_Click(object sender, EventArgs e) {
            btSelectAll_Click(sender, e);
            btDelete_Click(sender, e);
            this.Refresh();
        }

        private void btShowTree_Click(object sender, EventArgs e) {
            if (this.Controls.Contains(treeView1) == false)
            {
                this.Controls.Add(treeView1);
                treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
                MAXx = 679;
            }
            else {
                this.Controls.Remove(treeView1);
                MAXx = this.ClientSize.Width;
            }
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if(e.Action == TreeViewAction.ByMouse)
                tree.notify();
            this.Refresh();
        }

        private void btUnselectAll_Click(object sender, EventArgs e) {
            for (int i = 0; i < storage.getCount(); i++) {
                if (storage.getObject(i) != null && storage.getObject(i).IsObjectSelected() == true) {
                    SelectCommand ch = new SelectCommand();
                    ch.execute(storage, i);
                    history.Push(ch);
                }
            }
            this.Refresh();
        }

        private void btStickyObj_Click(object sender, EventArgs e) {
            for(int i = 0; i < storage.getCount(); i++) {
                if(storage.getObject(i).IsObjectSelected() == true && storage.getObject(i).IsA("CStickyObject") == false) {
                    StickyObjCommand s = new StickyObjCommand();
                    s.execute(storage, i);
                    history.Push(s); 
                    //storage.getObject(i).
                }
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            if (choosen == "Cursor") {
                MoveByMouseCommand m = (MoveByMouseCommand)commands["MoveByMouse"].clon();
                for (int i = 0; i < storage.getCount(); i++) {
                    if (storage.getObject(i).IsMouseInObject(e) == true) { 
                        m.addPoint(storage.getObject(i), e);
                    }
                }
                history.Push(m);
            }   
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if(history.Count != 0 && history.Peek().IsA("MoveByMouseCommand") == true) {
                try {
                    MoveByMouseCommand m = (MoveByMouseCommand)history.Peek();
                    m.execute(e);
                    this.Refresh();
                }
                catch { }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            if (history.Count != 0) {
                Console.WriteLine("*");
                 history.Peek();
                 this.Refresh();
            }
        }
    }

    class MyStorage: CObject{
        private CPoint[] arr;//массив с объектами
        private int Count;
        private int numberSelected;

        public MyStorage(){
            arr = new CPoint[2];
            Count = 0;
            numberSelected = 0;
        }

        public MyStorage(int i) {
            arr = new CPoint[i];
            Count = 0;
            numberSelected = 0;
        }

        public MyStorage(MyStorage x) { 
            arr = x.arr;
            Count = x.Count;
        }

        public int getCount() {
            return Count;
        }

        public int getNumSelected() {
            numberSelected = 0;
            for (int i = 0; i < Count; i++) {
                if (arr[i].IsObjectSelected() == true)
                    numberSelected++;
            }
            return numberSelected;
        }

        public int setObject(CPoint x) {
            if (Count == arr.Length) {
                Array.Resize(ref arr, Count + 1);
            }
            arr[Count] = x;
            Count++;
            notifyEveryone();
            return Count - 1;
        }

        public void deleteObject(int k) {
            for (int i = k; i < arr.Length - 1; i++) {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = null;
            Count--;
            notifyEveryone();
        }
        
        public CPoint getObject(int i)  {
            if (i < arr.Length)  {
                return arr[i];
            }
            return null;
        }

        public bool selectObjects(MouseEventArgs e) {
            bool flag = false;
            for (int i = 0; i < Count; i++) {
                if (arr[i] != null && arr[i].IsMouseInObject(e) == true) {
                    flag = true;
                    arr[i].select();                   
                }
            }
            if(flag == true)
                return true;
            else
                return false;
        }

        public void ChangeChoosenObjects(Command doCommand, int MAXx, int MAXy, Stack<Command> history) {
           for(int i = 0; i < Count; i++) {
                if (arr[i].IsObjectSelected() == true) {
                    if (arr[i].IsA("CStickyObject") == true) {
                        CStickyObject s = (CStickyObject)arr[i];
                        for (int j = 0; j < Count; j++){
                            if (j != i)     
                                s.roll(arr[j]);
                        }
                    }
                    Command newCommand = doCommand.clon();
                    newCommand.execute(arr[i], MAXx, MAXy);
                    history.Push(newCommand);
                    
                }                
           }
            notifyEveryone();
        }
        public void saveToFile(string file){
            StreamWriter writer = new StreamWriter(file, false, System.Text.Encoding.Default);
            writer.WriteLine($"Объектов в хранилище: {Count}");
            for (int i = 0; i < Count; i++)
                arr[i].save(writer);
            writer.Close();           
        } 

        public void loadFromFile(string file) {
            StreamReader reader = new StreamReader(file, System.Text.Encoding.Default);
            string line;
            line = reader.ReadLine();
            string[] split = line.Split(new Char[] { ' ', ',', '(', ')', '\n' });
            Count = Convert.ToInt32(split[3]);
            arr = new CPoint[Count];
            CMyPointFactory factory = new CMyPointFactory();
            for(int i = 0; i < Count; i++) {
                line = reader.ReadLine();
                arr[i] = factory.createPoint(line);
                arr[i].load(reader, factory);
            }
            reader.Close();
            notifyEveryone();
        }

        public int groupChoosen() {
            int size = getNumSelected();
            CGroup g = new CGroup(size);
            for (int i = Count - 1; i >= 0; i--) {
                if (arr[i].IsObjectSelected() == true) {
                    if (g.addToGroup(arr[i]) ==true)
                        deleteObject(i);
                }
            }            
            return setObject(g);
        }

        public void ungroupChoosen() {
            for (int i = 0; i < Count; i++) {
                if (arr[i].IsObjectSelected() == true && arr[i].IsA("Group") == true) {
                        CGroup g = (CGroup)arr[i];
                        g.ungroup(this, i);
                }
            }
        }

        public void unSelextAll() {
            for (int i = 0; i < Count; i++) {
                if (arr[i].IsObjectSelected() == true){
                    arr[i].select();
                }
            }
        }

        public  void onSubjectChanged(CTree _tree) {
            TreeNode tree = _tree.getTree().SelectedNode;
            unSelextAll();
            selectNode(tree);
           
        }

        public void selectNode(TreeNode tree) {
            if (tree.Name == "CGroup" || tree.Name == "CCircle" || tree.Name == "CSegment" || tree.Name == "CRectangle"
                || tree.Name == "CTriangle" || tree.Text == "group") {
                foreach (TreeNode tr in tree.Nodes){
                    selectNode(tr);
                }
            }
            else {
                try {
                    int k = Convert.ToInt32(tree.Name);
                    if (tree.Parent.Parent.Text == "group"){
                        CGroup g = (CGroup)arr[Convert.ToInt32(tree.Parent.Parent.Name)];
                        g.getObj(k).select();
                    }
                    else
                        arr[k].select();
                }
                catch { }
            }
        }
    }        
}
