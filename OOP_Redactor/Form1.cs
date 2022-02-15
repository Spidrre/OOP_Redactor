using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace OOP_Redactor
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            k = new My_tree();
            contr = new Controller(commands, newStorage, this);
            pictureBox1.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(200, menuStrip1.Height);
            pictureBox1.Size = new Size(945, 597);
            pictureBox1.KeyDown += new KeyEventHandler(pictureBox1_KeyDown);
            
            ToolStripMenuItem groupMenuItem = new ToolStripMenuItem("Group");
            ToolStripMenuItem ungroupMenuItem = new ToolStripMenuItem("Ungroup");
            ToolStripMenuItem ungroupAllMenuItem = new ToolStripMenuItem("UngroupAll");
            contextMenuStrip1.Items.AddRange(new[] { groupMenuItem, ungroupMenuItem, ungroupAllMenuItem });
            pictureBox1.ContextMenuStrip = contextMenuStrip1;

            
            
            newStorage.addObs(k);
            k.Location = new Point(0, 179);
            k.Width = 200;
            k.Height = pictureBox1.Height - 150;
            k.CheckBoxes = true;
            k.AfterCheck += k_AfterCheck;
            k.Click += k_Click;
            Controls.Add(k);

            pictureBox1.Select();
        }

        Storage newStorage = new Storage();
        public My_tree k;
        Dictionary<string, Command> commands = new Dictionary<string, Command>();
        Controller contr;
        public int colorDef=2;

        private void btnDel_Click(object sender, EventArgs e)
        {
            contr.nvoke(btnDel.Text);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            labelX.Text = e.X.ToString();
            labelY.Text = e.Y.ToString();
        }

        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                contr.Undo();
            }
            if (e.KeyCode == Keys.Y)
            {
                contr.Redo();
            }
            contr.nvoke(e.KeyCode.ToString());  
        }

        public void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl.GetType() == rbChange.GetType())
                    {
                        RadioButton rb = (RadioButton)ctrl;
                        if (rb.Checked)
                        {
                            contr.nvoke(rb.Name);
                            break;
                        }
                    }
                }
            }
            this.Refresh();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contr.nvoke(e.ClickedItem.ToString());
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Clear History")
            {
                contr.clear_hist();
            }
        }

        private void menuItemFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            menuItemFile.DropDown.Close();
            contr.nvoke(e.ClickedItem.Text.ToString());
        }

        private void clearHistItem_Click(object sender, EventArgs e)
        {
            contr.clear_hist();
        }

        private void k_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                contr.nvoke("treeNode");
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Painter pain = new Painter(e.Graphics);
            for (newStorage.first(); newStorage.eol() != true; newStorage.next())
                newStorage.get_curr().accept(pain);  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDef = cbColor.SelectedIndex + 2;
            pictureBox1.Select();
        }
        private void rbCircle_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

        private void rbRect_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

        private void rbChange_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

        private void rbLine_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }
        private void rbSelector_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = ClientRectangle.Width- pictureBox1.Location.X;
            pictureBox1.Height = ClientRectangle.Height- pictureBox1.Location.Y;
            k.Height = pictureBox1.Height - 125;
        }

        private void k_Click(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }
    }
}


//bool flag = true;
//for (int i = 0; i < newStorage.length(); i++)
//{
//    flag = flag & newStorage.get_element(i).Selected();
//    if (flag == false)
//        break;
//}
//k.Nodes[0].Checked = flag;