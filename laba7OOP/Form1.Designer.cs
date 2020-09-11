namespace laba7OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SaveToFile = new System.Windows.Forms.SaveFileDialog();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btCursor = new System.Windows.Forms.ToolStripButton();
            this.btGroup = new System.Windows.Forms.ToolStripButton();
            this.btUngroup = new System.Windows.Forms.ToolStripButton();
            this.btColor = new System.Windows.Forms.ToolStripButton();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.btLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btCircle = new System.Windows.Forms.ToolStripButton();
            this.btTriangle = new System.Windows.Forms.ToolStripButton();
            this.btSegment = new System.Windows.Forms.ToolStripButton();
            this.bt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btUnexecute = new System.Windows.Forms.ToolStripButton();
            this.btExecute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btDelete = new System.Windows.Forms.ToolStripButton();
            this.btSelectAll = new System.Windows.Forms.ToolStripButton();
            this.btUnselectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btStickyObj = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btShowTree = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveToFile
            // 
            this.SaveToFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            this.OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(40, 24);
            this.toolStripLabel1.Text = "Круг";
            // 
            // btCursor
            // 
            this.btCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCursor.Image = ((System.Drawing.Image)(resources.GetObject("btCursor.Image")));
            this.btCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCursor.Name = "btCursor";
            this.btCursor.Size = new System.Drawing.Size(24, 24);
            this.btCursor.Text = "Cursor";
            this.btCursor.Click += new System.EventHandler(this.btCursor_Click);
            // 
            // btGroup
            // 
            this.btGroup.BackColor = System.Drawing.Color.SlateGray;
            this.btGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btGroup.Image = ((System.Drawing.Image)(resources.GetObject("btGroup.Image")));
            this.btGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btGroup.Name = "btGroup";
            this.btGroup.Size = new System.Drawing.Size(54, 24);
            this.btGroup.Text = "Group";
            this.btGroup.Click += new System.EventHandler(this.btGroup_Click);
            // 
            // btUngroup
            // 
            this.btUngroup.BackColor = System.Drawing.Color.SlateGray;
            this.btUngroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btUngroup.Image = ((System.Drawing.Image)(resources.GetObject("btUngroup.Image")));
            this.btUngroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUngroup.Name = "btUngroup";
            this.btUngroup.Size = new System.Drawing.Size(71, 24);
            this.btUngroup.Text = "Ungroup";
            this.btUngroup.Click += new System.EventHandler(this.btUngroup_Click);
            // 
            // btColor
            // 
            this.btColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btColor.Image = ((System.Drawing.Image)(resources.GetObject("btColor.Image")));
            this.btColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(24, 24);
            this.btColor.Text = "Color";
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // btSave
            // 
            this.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(24, 24);
            this.btSave.Text = "Save to file";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btLoad
            // 
            this.btLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLoad.Image = ((System.Drawing.Image)(resources.GetObject("btLoad.Image")));
            this.btLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(24, 24);
            this.btLoad.Text = "Load from file";
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCircle,
            this.btTriangle,
            this.btSegment,
            this.bt,
            this.btCursor,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripSeparator9,
            this.toolStripSeparator3,
            this.btColor,
            this.toolStripSeparator2,
            this.toolStripSeparator4,
            this.btGroup,
            this.toolStripSeparator8,
            this.btUngroup,
            this.toolStripSeparator5,
            this.btUnexecute,
            this.btExecute,
            this.toolStripSeparator6,
            this.btSave,
            this.toolStripSeparator7,
            this.btLoad,
            this.toolStripSeparator10,
            this.btDelete,
            this.btSelectAll,
            this.btUnselectAll,
            this.toolStripSeparator12,
            this.btStickyObj,
            this.toolStripSeparator11,
            this.btShowTree,
            this.toolStripSeparator13,
            this.btDeleteAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1033, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // btCircle
            // 
            this.btCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCircle.Image = ((System.Drawing.Image)(resources.GetObject("btCircle.Image")));
            this.btCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCircle.Name = "btCircle";
            this.btCircle.Size = new System.Drawing.Size(24, 24);
            this.btCircle.Text = "Circle";
            this.btCircle.Click += new System.EventHandler(this.btCircle_Click);
            // 
            // btTriangle
            // 
            this.btTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btTriangle.Image")));
            this.btTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTriangle.Name = "btTriangle";
            this.btTriangle.Size = new System.Drawing.Size(24, 24);
            this.btTriangle.Text = "Triangle";
            this.btTriangle.Click += new System.EventHandler(this.btTriangle_Click);
            // 
            // btSegment
            // 
            this.btSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSegment.Image = ((System.Drawing.Image)(resources.GetObject("btSegment.Image")));
            this.btSegment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSegment.Name = "btSegment";
            this.btSegment.Size = new System.Drawing.Size(24, 24);
            this.btSegment.Text = "Segment";
            this.btSegment.Click += new System.EventHandler(this.btSegment_Click);
            // 
            // bt
            // 
            this.bt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bt.Image = ((System.Drawing.Image)(resources.GetObject("bt.Image")));
            this.bt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(24, 24);
            this.bt.Text = "Rectangle";
            this.bt.Click += new System.EventHandler(this.btRectangle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btUnexecute
            // 
            this.btUnexecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUnexecute.Enabled = false;
            this.btUnexecute.Image = ((System.Drawing.Image)(resources.GetObject("btUnexecute.Image")));
            this.btUnexecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUnexecute.Name = "btUnexecute";
            this.btUnexecute.Size = new System.Drawing.Size(24, 24);
            this.btUnexecute.Text = "Отменить";
            this.btUnexecute.Click += new System.EventHandler(this.btUnexecute_Click);
            // 
            // btExecute
            // 
            this.btExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btExecute.Enabled = false;
            this.btExecute.Image = ((System.Drawing.Image)(resources.GetObject("btExecute.Image")));
            this.btExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(24, 24);
            this.btExecute.Text = "Вернуть";
            this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // btDelete
            // 
            this.btDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btDelete.BackgroundImage")));
            this.btDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(23, 24);
            this.btDelete.Text = "Delete";
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSelectAll
            // 
            this.btSelectAll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btSelectAll.Image")));
            this.btSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(73, 24);
            this.btSelectAll.Text = "Select all";
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btUnselectAll
            // 
            this.btUnselectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btUnselectAll.Image")));
            this.btUnselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUnselectAll.Name = "btUnselectAll";
            this.btUnselectAll.Size = new System.Drawing.Size(89, 24);
            this.btUnselectAll.Text = "Unselect all";
            this.btUnselectAll.Click += new System.EventHandler(this.btUnselectAll_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 27);
            // 
            // btStickyObj
            // 
            this.btStickyObj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btStickyObj.Image = ((System.Drawing.Image)(resources.GetObject("btStickyObj.Image")));
            this.btStickyObj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btStickyObj.Name = "btStickyObj";
            this.btStickyObj.Size = new System.Drawing.Size(97, 24);
            this.btStickyObj.Text = "Sticky object";
            this.btStickyObj.Click += new System.EventHandler(this.btStickyObj_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 27);
            // 
            // btShowTree
            // 
            this.btShowTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btShowTree.Image = ((System.Drawing.Image)(resources.GetObject("btShowTree.Image")));
            this.btShowTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btShowTree.Name = "btShowTree";
            this.btShowTree.Size = new System.Drawing.Size(134, 24);
            this.btShowTree.Text = "Дерево объектов";
            this.btShowTree.Click += new System.EventHandler(this.btShowTree_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 27);
            // 
            // btDeleteAll
            // 
            this.btDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteAll.Image")));
            this.btDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(77, 24);
            this.btDeleteAll.Text = "Delete all";
            this.btDeleteAll.Click += new System.EventHandler(this.btDeleteAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1033, 554);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog SaveToFile;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btCursor;
        private System.Windows.Forms.ToolStripButton btGroup;
        private System.Windows.Forms.ToolStripButton btUngroup;
        private System.Windows.Forms.ToolStripButton btColor;
        private System.Windows.Forms.ToolStripButton btSave;
        private System.Windows.Forms.ToolStripButton btLoad;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btCircle;
        private System.Windows.Forms.ToolStripButton btTriangle;
        private System.Windows.Forms.ToolStripButton btSegment;
        private System.Windows.Forms.ToolStripButton bt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btUnexecute;
        private System.Windows.Forms.ToolStripButton btExecute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btDelete;
        private System.Windows.Forms.ToolStripButton btSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton btDeleteAll;
        private System.Windows.Forms.ToolStripButton btShowTree;
        private System.Windows.Forms.ToolStripButton btUnselectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripButton btStickyObj;
    }
}

