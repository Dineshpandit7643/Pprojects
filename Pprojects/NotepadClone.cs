using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pprojects
{
    public partial class NotepadClone : Form
    {
        public NotepadClone()
        {
            InitializeComponent();
        }

       

        //For File
        private int untitledCount = 1;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rtbEditor.Clear();
            rtbEditor.Clear();  // Clear the text editor
            this.Text = "Untitled - NotepadClone"; // Update the window title
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.Text = File.ReadAllText(openFile.FileName);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*"
            };
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, rtbEditor.Text);
            }

        }
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog { Filter = "Text Files|*.txt|All Files|*.*" };
            if (saveFile.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFile.FileName, rtbEditor.Text);
        }
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Printing not implemented yet!");
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //For Edit

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanUndo)
                rtbEditor.Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbEditor.CanRedo)
                rtbEditor.Redo();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectedText = "";
        }
        private void defineWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textToFind = ShowInputDialog("Enter text to find:", "Find");
            int index = rtbEditor.Text.IndexOf(textToFind, StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                rtbEditor.Select(index, textToFind.Length);
                rtbEditor.Focus();
            }
            else
            {
                MessageBox.Show("Text not found!");
            }
        }
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textToFind = ShowInputDialog("Enter text to find:", "Find");
            string replacementText = ShowInputDialog("Enter replacement text:", "Replace");
            rtbEditor.Text = rtbEditor.Text.Replace(textToFind, replacementText);
        }
        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lineNumber;
            if (int.TryParse(ShowInputDialog("Enter line number:", "Go To"), out lineNumber))
            {
                int charIndex = rtbEditor.GetFirstCharIndexFromLine(lineNumber - 1);
                rtbEditor.Select(charIndex, 0);
                rtbEditor.Focus();
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectAll();
        }
        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.AppendText(Environment.NewLine + DateTime.Now.ToString());
        }
        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.Font = fd.Font;
            }
        }


        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }


        //For View


        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                rtbEditor.ForeColor = cd.Color;
            }

        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbEditor.WordWrap = !rtbEditor.WordWrap;
        }
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void rtbEditor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbEditor.Text))
            {
                lblWordCount.Text = "Words: 0";
            }
            else
            {
                int wordCount = rtbEditor.Text
                    .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Length;
                lblWordCount.Text = $"Words: {wordCount}";
            }
        }

       

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblWordCount_Click(object sender, EventArgs e)
        {

        }


        private string ShowInputDialog(string prompt, string title)
        {
            using (Form form = new Form())
            {
                form.Text = title;
                Label label = new Label() { Text = prompt, Left = 10, Top = 10, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 200 };
                Button buttonOK = new Button() { Text = "OK", Left = 10, Top = 60, DialogResult = DialogResult.OK };
                Button buttonCancel = new Button() { Text = "Cancel", Left = 120, Top = 60, DialogResult = DialogResult.Cancel };

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(buttonOK);
                form.Controls.Add(buttonCancel);
                form.AcceptButton = buttonOK;
                form.CancelButton = buttonCancel;
                form.StartPosition = FormStartPosition.CenterParent;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
            }
        }

    }
}



