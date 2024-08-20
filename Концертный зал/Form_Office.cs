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
    public partial class Form_Office : Form
    {
        public string check_title { get; set; }
        public string check_time { get; set; }
        public bool max_price { get; set; }
        public int max_available_price { get; set; }
        public Form_Office()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            max_price = false;
            max_available_price = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            button1.Enabled = true;
            if (comboBox1.SelectedIndex == 0)
            {
                string[] times = new string[] { "1 апреля 12:30", "1 апреля 16:30", "1 апреля 19:00" };
                comboBox2.DataSource = times;
                check_title = "Музыка В. А. Моцарта";
                check_time = "12:30";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                string[] times = new string[] { "2 апреля 11:45", "2 апреля 17:00", "2 апреля 19:00" };
                comboBox2.DataSource = times;
                check_title = "Музыка П. И. Чайковского";
                check_time = "11:45";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                string[] times = new string[] { "3 апреля 13:15", "3 апреля 17:15", "3 апреля 20:00" };
                comboBox2.DataSource = times;
                check_title = "Музыка Ф. Шопена";
                check_time = "13:15";
            }
        }

		private void button1_Click(object sender, EventArgs e)
		{
            Form_Hall form3 = new Form_Hall(check_title, Set_Check_Date(check_title), check_time);
            if (max_price == true) max_available_price = int.Parse(textBox1.Text);
            Point[] disabled = Ticket_Office.Check_Seats(check_title, check_time, max_available_price);
            form3.Lock_Seats(disabled);
            int[] prices = Ticket_Office.Set_Prices(check_title, check_time);
            form3.Set_Prices(prices);
            form3.Label1 = check_title + ". " + Set_Check_Date(check_title) + ". " + check_time;
            form3.Label3 = Ticket_Office.MyCash.ToString() + " р.";
            form3.Show();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (check_title == "Музыка В. А. Моцарта")
			{
                if (comboBox2.SelectedIndex == 0)
                    check_time = "12:30";
                if (comboBox2.SelectedIndex == 1)
                    check_time = "16:30";
                if (comboBox2.SelectedIndex == 2)
                    check_time = "19:00";
            }
            if (check_title == "Музыка П. И. Чайковского")
			{
                if (comboBox2.SelectedIndex == 0)
                    check_time = "11:45";
                if (comboBox2.SelectedIndex == 1)
                    check_time = "17:00";
                if (comboBox2.SelectedIndex == 2)
                    check_time = "19:00";
            }
            if (check_title == "Музыка Ф. Шопена")
            {
                if (comboBox2.SelectedIndex == 0)
                    check_time = "13:15";
                if (comboBox2.SelectedIndex == 1)
                    check_time = "17:15";
                if (comboBox2.SelectedIndex == 2)
                    check_time = "20:00";
            }
        }
        public string Set_Check_Date(string check_title)
		{
            if (check_title == "Музыка В. А. Моцарта")
                return "01.04.2022";
            else if (check_title == "Музыка П. И. Чайковского")
                return "02.04.2022";
            else
                return "03.04.2022";
		}

		private void button2_Click(object sender, EventArgs e)
		{
            Close();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{

		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
            max_price = !(max_price);
            if (max_price == true)
			{
                textBox1.Enabled = true;
                textBox1.Text = "1500";
            }
            else
			{
                textBox1.Enabled = false;
                textBox1.Text = "";
                max_available_price = -1;
            }
		}
	}
}
