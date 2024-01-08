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

namespace GUI.MainForm.CreateQuestion.QuestionPage
{
    public partial class Guna2CheckBoxComboBox : UserControl
    {
        private Guna2ComboBox comboBox;
        private Guna2CheckBoxListControl checkBoxListControl;
        private Size size;
        private bool isDropDownVisible;
        private string selectedItem;
        private string checkedItemsString;
        private string defaultString;

        public string SelectedItem { get => selectedItem; set => selectedItem = value; }
        public string CheckedItemsString { get => checkedItemsString; set => checkedItemsString = value; }
        public string DefaultString { get => defaultString; set => defaultString = value; }
        public Size Size1 { get => size; set => size = value; }

        public Guna2CheckBoxComboBox()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Create the Guna2ComboBox
            comboBox = new Guna2ComboBox();
            //comboBox.Items.Add(defaultString);
            //comboBox.SelectedIndex = 0;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.MouseClick += ComboBox_MouseClick;
            //comboBox.Size = Size1;
            comboBox.BackColor = Color.Transparent;

            // Create the Guna2CheckBoxListControl
            checkBoxListControl = new Guna2CheckBoxListControl();
            checkBoxListControl.Visible = false;
            checkBoxListControl.BackColor = Color.Transparent;
            //checkBoxListControl.Size = Size1;
            //checkBoxListControl.ItemCheck += CheckBoxListControl_ItemCheck;

            // Add controls to the UserControl
            Controls.Add(comboBox);
            Controls.Add(checkBoxListControl);
        }

        private void ComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Toggle the visibility of the CheckBoxListControl
            checkBoxListControl.Location = new System.Drawing.Point(comboBox.Left, comboBox.Bottom);
            isDropDownVisible = !isDropDownVisible;
            List<string> checkedItems = checkBoxListControl.GetCheckedItems();
            if (checkedItems.Count == 0)
            {
                comboBox.Items.Clear();
                CheckedItemsString = "";
                SelectedItem = defaultString;
                comboBox.Items.Add(SelectedItem);
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.Items.Clear();
                CheckedItemsString = String.Join(",", checkedItems);
                SelectedItem = $"Đã tick: {checkedItems.Count}";
                comboBox.Items.Add(SelectedItem);
                comboBox.SelectedIndex = 0;
            }
            checkBoxListControl.Visible = isDropDownVisible;

            // Prevent default dropdown from appearing
            comboBox.DroppedDown = false;

            //checkBoxListControl.BringToFront();
            if(isDropDownVisible)
                Parent.Controls.SetChildIndex(this, 0);
            else
                Parent.Controls.SetChildIndex(this, 99);
        }

        private void CheckBoxListControl_Check(object sender, ItemCheckEventArgs e)
        {
            // Handle item check events as needed
            // You can access the checked state using e.NewValue
            // Update the ComboBox text based on the checked items
            UpdateComboBoxText();
        }

        private void UpdateComboBoxText()
        {
            // Concatenate the checked items and display in the ComboBox
            List<string> checkedItems = checkBoxListControl.GetCheckedItems();
            comboBox.Text = string.Join(", ", checkedItems);
        }

        public void AddItem(string text)
        {
            // Add items to the Guna2CheckBoxListControl
            checkBoxListControl.AddItem(text);
        }
    }
}
