using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticket_Office
{
	public partial class Form_Sorting : Form
	{
		Form_Feedbacks form5;
		public int about_marks_low { get; set; }
		public int about_marks_high { get; set; }
		public string about_events1 { get; set; }
		public string about_events2 { get; set; }
		public string about_events3 { get; set; }
		public int about_text_low { get; set; }
		public int about_text_high { get; set; }
		public Form_Sorting()
		{
			InitializeComponent();
			about_marks_low = 0;
			about_marks_high = 0;
			about_events1 = "";
			about_events2 = "";
			about_events3 = "";
			about_text_low = 0;
			about_text_high = 0;
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 0)
			{
				about_marks_low = 3;
				about_marks_high = 6;
			}
				
			if (comboBox1.SelectedIndex == 1)
			{
				about_marks_low = 0;
				about_marks_high = 4;
			}
				
			if (comboBox1.SelectedIndex == 2)
			{
				about_marks_low = 0;
				about_marks_high = 6;
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox2.SelectedIndex == 0)
				about_events1 = "Музыка В. А. Моцарта";
			else if (comboBox2.SelectedIndex == 1)
                about_events1 = "Музыка П. И. Чайковского"; 

            else if (comboBox2.SelectedIndex == 2)
				about_events1 = "Музыка Ф. Шопена";
			else if (comboBox2.SelectedIndex == 3)
			{
				about_events1 = "Музыка В. А. Моцарта";
				about_events2 = "Музыка П. И. Чайковского";
				about_events3 = "Музыка Ф. Шопена";
			}
				
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox3.SelectedIndex == 0)
			{
				about_text_low = 0;
				about_text_high = 51;
			}
			if (comboBox3.SelectedIndex == 1)
			{
				about_text_low = 50;
				about_text_high = 10000;
			}
			if (comboBox3.SelectedIndex == 2)
			{
				about_text_low = 0;
				about_text_high = 10000;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (about_events1 != "" && about_marks_high != 0 && about_text_high != 0)
			{
				form5 = new Form_Feedbacks(about_marks_low, about_marks_high, about_events1, about_events2, about_events3, about_text_low, about_text_high);
				if (form5.flag == true)
				form5.Show();
				Close();
			}
			else
				MessageBox.Show("Сначала заполните все поля!", "Сортировка", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
