using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI.MainForm.CreateQuestion.QuestionPage
{
    public partial class Guna2CheckBoxListControl : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;
        private List<Guna2CheckBox> checkBoxes;
        private string selectedItem;
        private string checkedItemsString;

        public string SelectedItem { get => selectedItem; set => selectedItem = value; }
        public string CheckedItemsString { get => checkedItemsString; set => checkedItemsString = value; }

        public Guna2CheckBoxListControl()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            flowLayoutPanel = new FlowLayoutPanel();
            checkBoxes = new List<Guna2CheckBox>();

            // Set FlowLayoutPanel properties
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.AutoScroll = true;
            //flowLayoutPanel.AutoSize = true;

            flowLayoutPanel.Size = new Size(500, 36);
            //flowLayoutPanel.BackColor = Color.White;

            // Add FlowLayoutPanel to the UserControl
            Controls.Add(flowLayoutPanel);
            //flowLayoutPanel.BringToFront();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<string> checkedItems = new List<string>();

            foreach (Guna2CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked)
                {
                    checkedItems.Add(checkBox.Text);
                }
            }

            // Concatenate the checked items
            CheckedItemsString = string.Join(",", checkedItems);
            SelectedItem = $"SelectedItem: {checkedItems.Count}";
        }

        public void AddItem(string text)
        {
            Guna2CheckBox checkBox = new Guna2CheckBox();
            checkBox.Text = text;
            checkBox.AutoSize = true;
            checkBox.AutoEllipsis = false;
            //checkBox.CheckedChanged += CheckBox_CheckedChanged;

            // Add the new CheckBox to the list
            checkBoxes.Add(checkBox);

            // Add the CheckBox to the FlowLayoutPanel
            flowLayoutPanel.Controls.Add(checkBox);
        }

        public List<string> GetCheckedItems()
        {
            List<string> checkedItems = new List<string>();

            foreach (Guna2CheckBox checkBox in checkBoxes)
            {
                if (checkBox.Checked)
                {
                    checkedItems.Add(checkBox.Text);
                }
            }

            return checkedItems;
        }
    }
}
