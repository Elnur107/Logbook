using Logbook.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logbook
{
    public partial class StudentUserControl : UserControl
    {

        int diamond2click = 0;
        int diamond1click = 0;
        int diamond3click = 0;

        public RadioButton GreenBtn
        {
            get { return greenbtn; }
            set { greenbtn.Checked = true; }
        }
        public string Name
        {
            get { return StudentNameLbl.Text; }
            set { StudentNameLbl.Text = value; }
        }
        public string Surname
        {
            get { return StudentSurnameLbl.Text; }
            set { StudentSurnameLbl.Text = value; }
        }
        public string Fathername
        {
            get { return StudentFatherNameLbl.Text; }
            set { StudentFatherNameLbl.Text = value; }
        }
        public EventHandler<EventArgs> DiamondClick { get; set; }

        public StudentUserControl()
        {
            InitializeComponent();
            AddInspectionComboBox();
            StudentDateLbl.Text = DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year;
            AddClassworkComboBox();
        }
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public void AddClassworkComboBox()
        {
            ClassworkComboBox.DataSource = numbers;
            ClassworkComboBox.SelectedIndex = -1;
        }
        public void AddInspectionComboBox()
        {
            InspectionComboBox.DataSource = numbers1;
            InspectionComboBox.SelectedIndex = -1;
            InspectionComboBox.SelectedItem = "-";
        }
        private void ClassworkComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassworkComboBox.BackColor = Color.DarkOrchid;
        }
        private void Diamond1Btn_Click(object sender, EventArgs e)
        {
            if (diamond2click == 0 && diamond1click == 0)
            {
                DiamondClick.Invoke(sender, e);
                Diamond1Btn.BackgroundImage = Resources.diamond20;
            }
            else if (diamond2click == 1 && diamond1click == 0)
            {
                Diamond2Btn.BackgroundImage = Resources.icons8_diamond_25;
            }
            else if (diamond1click == 1)
            {
                Diamond1Btn.BackgroundImage = Resources.icons8_diamond_25;
            }
            diamond1click += 1;
        }
        private void Diamond2Btn_Click(object sender, EventArgs e)
        {
            if (diamond2click == 0 && diamond1click == 1)
            {
                DiamondClick.Invoke(sender, e);
                diamond2click += 1;
                Diamond2Btn.BackgroundImage = Resources.diamond20;
            }
            else if (diamond2click == 0 && diamond1click == 0)
            {
                DiamondClick.Invoke(sender, e);
                DiamondClick.Invoke(sender, e);
                Diamond2Btn.BackgroundImage = Resources.diamond20;
                Diamond1Btn.BackgroundImage = Resources.diamond20;
            }
            else if (diamond3click == 1)
            {
                Diamond3Btn.BackgroundImage = Resources.icons8_diamond_25;
                Diamond2Btn.BackgroundImage = Resources.diamond20;
                Diamond1Btn.BackgroundImage = Resources.diamond20;
            }
            diamond2click += 1;
        }
        private void Diamond3Btn_Click(object sender, EventArgs e)
        {
            if (diamond2click == 1)
            {
                DiamondClick.Invoke(sender, e);
                Diamond3Btn.BackgroundImage = Resources.diamond20;
            }
            else if (diamond2click == 0 && diamond1click == 1)
            {
                DiamondClick.Invoke(sender, e);
                DiamondClick.Invoke(sender, e);
                Diamond3Btn.BackgroundImage = Resources.diamond20;
                Diamond2Btn.BackgroundImage = Resources.diamond20;
            }
            else if (diamond2click == 0 && diamond1click == 0)
            {
                Diamond1Btn.BackgroundImage = Resources.diamond20;
                Diamond3Btn.BackgroundImage = Resources.diamond20;
                Diamond2Btn.BackgroundImage = Resources.diamond20;
                DiamondClick.Invoke(sender, e);
                DiamondClick.Invoke(sender, e);
                DiamondClick.Invoke(sender, e);
            }
            diamond3click += 1;
        }
        private void Yellowbtn_CheckedChanged(object sender, EventArgs e)
        {
            ClassworkComboBox.Enabled = true;
            InspectionComboBox.Enabled = true;
            Diamond1Btn.Enabled = true;
            Diamond2Btn.Enabled = true;
            Diamond3Btn.Enabled = true;
            DeleteDiamondBtn.Enabled = true;
            MessageBtn.Enabled = true;
        }
        private void greenbtn_CheckedChanged(object sender, EventArgs e)
        {
            ClassworkComboBox.Enabled = true;
            InspectionComboBox.Enabled = true;
            Diamond1Btn.Enabled = true;
            Diamond2Btn.Enabled = true;
            Diamond3Btn.Enabled = true;
            DeleteDiamondBtn.Enabled = true;
            MessageBtn.Enabled = true;
        }
        private void redbtn_CheckedChanged(object sender, EventArgs e)
        {
            ClassworkComboBox.Enabled = false;
            InspectionComboBox.Enabled = false;
            Diamond1Btn.Enabled = false;
            Diamond2Btn.Enabled = false;
            Diamond3Btn.Enabled = false;
            DeleteDiamondBtn.Enabled = false;
            MessageBtn.Enabled = false;
        }
        private void MessageBtn_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Enabled = true;
        }
        private void AddCommentBtn_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Enabled = false;
            guna2TextBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            RejectCommentBtn.FillColor = Color.White;
            AddCommentBtn.FillColor = Color.White;
        }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            AddCommentBtn.FillColor = Color.DodgerBlue;
            RejectCommentBtn.FillColor = Color.DodgerBlue;
        }

        private void RejectCommentBtn_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Text = String.Empty;
            guna2TextBox3.Enabled = false;
            RejectCommentBtn.FillColor = Color.White;
            AddCommentBtn.FillColor = Color.White;
        }

        private void DeleteDiamondBtn_Click(object sender, EventArgs e)
        {
            Diamond1Btn.BackgroundImage = Resources.icons8_diamond_25;
            Diamond2Btn.BackgroundImage = Resources.icons8_diamond_25;
            Diamond3Btn.BackgroundImage = Resources.icons8_diamond_25;
        }
    }
}