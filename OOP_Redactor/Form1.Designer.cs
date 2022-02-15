using System.Drawing;

namespace OOP_Redactor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDel = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCircle = new System.Windows.Forms.RadioButton();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.rbSquare = new System.Windows.Forms.RadioButton();
            this.rbChange = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.rbSelector = new System.Windows.Forms.RadioButton();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.labelU = new System.Windows.Forms.Label();
            this.labelR = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuItemHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(-1, 24);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Clear";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(80, 27);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(23, 13);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "e.X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(121, 27);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(23, 13);
            this.labelY.TabIndex = 3;
            this.labelY.Text = "e.Y";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCircle);
            this.groupBox1.Controls.Add(this.cbColor);
            this.groupBox1.Controls.Add(this.rbSquare);
            this.groupBox1.Controls.Add(this.rbChange);
            this.groupBox1.Controls.Add(this.rbLine);
            this.groupBox1.Controls.Add(this.rbSelector);
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // rbCircle
            // 
            this.rbCircle.AutoSize = true;
            this.rbCircle.Location = new System.Drawing.Point(12, 19);
            this.rbCircle.Name = "rbCircle";
            this.rbCircle.Size = new System.Drawing.Size(51, 17);
            this.rbCircle.TabIndex = 0;
            this.rbCircle.Text = "Circle";
            this.rbCircle.UseVisualStyleBackColor = true;
            this.rbCircle.Click += new System.EventHandler(this.rbCircle_Click);
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Black",
            "Violet"});
            this.cbColor.Location = new System.Drawing.Point(6, 93);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(121, 21);
            this.cbColor.TabIndex = 8;
            this.cbColor.Text = "Red";
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // rbSquare
            // 
            this.rbSquare.AutoSize = true;
            this.rbSquare.Location = new System.Drawing.Point(12, 42);
            this.rbSquare.Name = "rbSquare";
            this.rbSquare.Size = new System.Drawing.Size(59, 17);
            this.rbSquare.TabIndex = 1;
            this.rbSquare.Text = "Square";
            this.rbSquare.UseVisualStyleBackColor = true;
            this.rbSquare.Click += new System.EventHandler(this.rbRect_Click);
            // 
            // rbChange
            // 
            this.rbChange.AutoSize = true;
            this.rbChange.Location = new System.Drawing.Point(104, 19);
            this.rbChange.Name = "rbChange";
            this.rbChange.Size = new System.Drawing.Size(89, 17);
            this.rbChange.TabIndex = 10;
            this.rbChange.Text = "Change Color";
            this.rbChange.UseVisualStyleBackColor = true;
            this.rbChange.Click += new System.EventHandler(this.rbChange_Click);
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Enabled = false;
            this.rbLine.Location = new System.Drawing.Point(12, 65);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(45, 17);
            this.rbLine.TabIndex = 11;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.Click += new System.EventHandler(this.rbLine_Click);
            // 
            // rbSelector
            // 
            this.rbSelector.AutoSize = true;
            this.rbSelector.Location = new System.Drawing.Point(104, 42);
            this.rbSelector.Name = "rbSelector";
            this.rbSelector.Size = new System.Drawing.Size(69, 17);
            this.rbSelector.TabIndex = 12;
            this.rbSelector.Text = "Selection";
            this.rbSelector.UseVisualStyleBackColor = true;
            this.rbSelector.CheckedChanged += new System.EventHandler(this.rbSelector_CheckedChanged);
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(162, 24);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(37, 20);
            this.tbCount.TabIndex = 8;
            this.tbCount.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // labelU
            // 
            this.labelU.AutoSize = true;
            this.labelU.Location = new System.Drawing.Point(205, 27);
            this.labelU.Name = "labelU";
            this.labelU.Size = new System.Drawing.Size(13, 13);
            this.labelU.TabIndex = 12;
            this.labelU.Text = "0";
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(206, 50);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(13, 13);
            this.labelR.TabIndex = 13;
            this.labelR.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1145, 597);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.cmenuItemHistory});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1141, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "File";
            this.menuItemFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemFile_DropDownItemClicked);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // cmenuItemHistory
            // 
            this.cmenuItemHistory.Name = "cmenuItemHistory";
            this.cmenuItemHistory.Size = new System.Drawing.Size(87, 20);
            this.cmenuItemHistory.Text = "Clear History";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 620);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelR);
            this.Controls.Add(this.labelU);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OOP_Redactor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.RadioButton rbSquare;
        private System.Windows.Forms.RadioButton rbCircle;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.RadioButton rbChange;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RadioButton rbSelector;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        public System.Windows.Forms.Label labelU;
        public System.Windows.Forms.Label labelR;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemHistory;
    }
}

