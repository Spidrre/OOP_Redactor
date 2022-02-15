using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    class Controller
    {
        private Dictionary<string, Command> commands;
        private Stack<Command> undo;
        private Stack<Command> redo;
        private Storage newStorage;
        private Form1 my_form;
        private int shag = 10;
        public Controller(Dictionary<string, Command> commands1, Storage _new, Form1 f)
        {
            undo = new Stack<Command>();
            redo = new Stack<Command>();
            commands = new Dictionary<string, Command>();
            newStorage = _new;
            my_form = f;
            commands.Add("W", new MoveCommand(0, -shag, newStorage, my_form));
            commands.Add("S", new MoveCommand(0, shag, newStorage, my_form));
            commands.Add("A", new MoveCommand(-shag, 0, newStorage, my_form));
            commands.Add("D", new MoveCommand(shag, 0, newStorage, my_form));
            commands.Add("Add", new DiamCommand(shag, newStorage));
            commands.Add("Subtract", new DiamCommand(-shag, newStorage));
            commands.Add("Oemplus", new DiamCommand(shag, newStorage));
            commands.Add("OemMinus", new DiamCommand(-shag, newStorage));
            commands.Add("Delete", new DeleteCommand(newStorage));
            commands.Add("Group", new GroupCommand(newStorage));
            commands.Add("Ungroup", new UngroupCommand(newStorage));
            commands.Add("rbChange", new ColorCommand(newStorage, my_form));
            commands.Add("rbCircle", new CreateCommand("Circle", newStorage, my_form));
            commands.Add("rbSquare", new CreateCommand("Square", newStorage, my_form));
            commands.Add("rbLine", new CreateCommand("Line", newStorage, my_form));
            commands.Add("rbSelector", new SelectionCommand(newStorage, my_form));
            commands.Add("Load", new LoadCommand(newStorage, my_form));
            commands.Add("Save", new SaveCommand(newStorage));
            commands.Add("UngroupAll", new UngroupAllCommand(newStorage));
            commands.Add("Clear", new DeleteAllCommand(newStorage));
            commands.Add("F", new StickyCommand(newStorage, my_form));
            commands.Add("G", new StickyCommand2(newStorage, my_form));
            commands.Add("treeNode", new My_TreeNodeCommand(newStorage, my_form));
        }


        public void nvoke(string s)
        {
            if (commands.ContainsKey(s))
            {
                Command com = commands[s];
                Command lastcommand = com.clone();
                lastcommand.execute();
                if (lastcommand.name() != "SaveCommand")
                    undo.Push(lastcommand);
                my_form.Refresh();
                my_form.labelU.Text = undo.Count.ToString();
                my_form.labelR.Text = redo.Count.ToString();
                my_form.tbCount.Text = newStorage.length().ToString();
                my_form.pictureBox1.Refresh();
                my_form.pictureBox1.Select();
            }
        }

        public void Undo()
        {
            if (undo.Count() != 0)
            {
                Command lastcommand = undo.Pop();
                if (lastcommand.isA("MoveCommand") || lastcommand.isA("DiamCommand") || lastcommand.isA("DeleteCommand"))
                {
                    while (lastcommand.name() == undo.Peek().name())
                    {
                        lastcommand.unexecute();
                        redo.Push(lastcommand);
                        lastcommand = undo.Pop();
                    }
                    lastcommand.unexecute();
                    redo.Push(lastcommand);
                }
                else
                {
                    lastcommand.unexecute();
                    redo.Push(lastcommand);
                }
            }
            my_form.pictureBox1.Refresh();
            my_form.pictureBox1.Select();
        }
        public void Redo()
        {
            if (redo.Count() != 0)
            {
                Command lastcommand = redo.Pop();
                if (lastcommand.isA("MoveCommand") || lastcommand.isA("DiamCommand") || lastcommand.isA("DeleteCommand"))
                {
                    if (redo.Count() != 0)
                    {
                        lastcommand.Rexecute();
                        undo.Push(lastcommand);
                        while (lastcommand.name() == redo.Peek().name())
                        {
                            lastcommand = redo.Pop();
                            lastcommand.Rexecute();
                            undo.Push(lastcommand);
                            if (redo.Count() == 0)
                                break;
                        }
                    }
                    else
                    {
                        lastcommand.Rexecute();
                        undo.Push(lastcommand);
                    }
                }
                else
                {
                    lastcommand.Rexecute();
                    undo.Push(lastcommand);
                }
            }
            my_form.pictureBox1.Refresh();
            my_form.pictureBox1.Select();
        }

        public void clear_hist()
        {
            undo.Clear();
            redo.Clear();
            my_form.labelU.Text = undo.Count.ToString();
            my_form.labelR.Text = redo.Count.ToString();
        }
    }
}
