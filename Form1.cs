using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInput.Text))
            {
                listBox1.Items.Add(txtInput.Text);
                txtInput.Clear();
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                int index = listBox1.SelectedIndex;
                string currentTask = listBox1.Items[index].ToString();
                listBox1.Items[index] = currentTask + " (Completed)";
            }
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }
        private void MoveItem(int direction)
        {
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // no item selected
            int newIndex = listBox1.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range
            object selected = listBox1.SelectedItem;
            listBox1.Items.Remove(selected);
            listBox1.Items.Insert(newIndex, selected);
            listBox1.SetSelected(newIndex, true);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
