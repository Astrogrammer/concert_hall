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
    public partial class Form_Hall : Form
    {
        string Event, Date, Time;
        public static List<Button> Seat_buttons = new List<Button>(24);
        public Form_Hall(string Event, string Date, string Time)
        {
            InitializeComponent();

            this.Event = Event;
            this.Date = Date;
            this.Time = Time;

            Seat_buttons.Add(button1);
            Seat_buttons.Add(button2);
            Seat_buttons.Add(button3);
            Seat_buttons.Add(button4);
            Seat_buttons.Add(button5);
            Seat_buttons.Add(button6);
            Seat_buttons.Add(button7);
            Seat_buttons.Add(button8);
            Seat_buttons.Add(button9);
            Seat_buttons.Add(button10);
            Seat_buttons.Add(button11);
            Seat_buttons.Add(button12);
            Seat_buttons.Add(button13);
            Seat_buttons.Add(button14);
            Seat_buttons.Add(button15);
            Seat_buttons.Add(button16);
            Seat_buttons.Add(button17);
            Seat_buttons.Add(button18);
            Seat_buttons.Add(button19);
            Seat_buttons.Add(button20);
            Seat_buttons.Add(button21);
            Seat_buttons.Add(button22);
            Seat_buttons.Add(button23);
            Seat_buttons.Add(button24);
        }

        public string Label1
            {
			    get
			    {
                    return label1.Text;
			    }
			    set
			    {
                    label1.Text = value;
			    }
            }
        public string Label3
        {
            get
            {
                return label3.Text;
            }
            set
            {
                label3.Text = value;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        public void Lock_Seats(Point[] disabled)
		{
            foreach (Point seat in disabled)
			{
                if (seat.X == 3)
				{
                    foreach (var button in Seat_buttons)
					{
                        if (button.TabIndex == seat.Y - 1)
                        {
                            button.Enabled = false;
                            button.BackColor = Color.Gray;
                            button.ForeColor = Color.White;
                        }
					}
                }
                if (seat.X == 2)
				{
                    foreach (var button in Seat_buttons)
                    {
                        if (button.TabIndex == seat.Y + 9)
                        {
                            button.Enabled = false;
                            button.BackColor = Color.Gray;
                        }
                    }
                }
                if (seat.X == 1)
				{
                    foreach (var button in Seat_buttons)
                    {
                        if (button.TabIndex == seat.Y + 17)
                        {
                            button.Enabled = false;
                            button.BackColor = Color.Gray;
                        }
                    }
                }
                
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 2 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 2) == true)
                { 
                    button1.Enabled = false;
                    button1.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button2_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 3 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 3) == true)
                {
                    button2.Enabled = false;
                    button2.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button3_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 4 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 4) == true)
                {
                    button3.Enabled = false;
                    button3.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button4_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 5 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 5) == true)
                {
                    button4.Enabled = false;
                    button4.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button5_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 6 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 6) == true)
                {
                    button5.Enabled = false;
                    button5.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button6_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 7 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 7) == true)
                {
                    button6.Enabled = false;
                    button6.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button7_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 8 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 8) == true)
                {
                    button7.Enabled = false;
                    button7.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button8_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 9 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 9) == true)
                {
                    button8.Enabled = false;
                    button8.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button9_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 10 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 10) == true)
                {
                    button9.Enabled = false;
                    button9.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button18_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 1 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 1) == true)
                {
                    button18.Enabled = false;
                    button18.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button17_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 2 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 2) == true)
                {
                    button17.Enabled = false;
                    button17.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button16_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 3 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 3) == true)
                {
                    button16.Enabled = false;
                    button16.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button15_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 4 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 4) == true)
                {
                    button15.Enabled = false;
                    button15.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button14_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 5 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 5) == true)
                {
                    button14.Enabled = false;
                    button14.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button13_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 6 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 6) == true)
                {
                    button13.Enabled = false;
                    button13.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button12_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 7 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 7) == true)
                {
                    button12.Enabled = false;
                    button12.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button11_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 8 место во 2 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 2, 8) == true)
                {
                    button11.Enabled = false;
                    button11.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button24_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 1 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 1) == true)
                {
                    button24.Enabled = false;
                    button24.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button23_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 2 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 2) == true)
                {
                    button23.Enabled = false;
                    button23.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button22_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 3 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 3) == true)
                {
                    button22.Enabled = false;
                    button22.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button21_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 4 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 4) == true)
                {
                    button21.Enabled = false;
                    button21.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button20_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 5 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 5) == true)
                {
                    button20.Enabled = false;
                    button20.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

		private void button19_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 6 место в 1 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 1, 6) == true)
                {
                    button19.Enabled = false;
                    button19.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
		{

		}

        private void button31_Click(object sender, EventArgs e)
		{
            Close();
		}

        private void button26_Click(object sender, EventArgs e)
        {

        }

        public void Set_Prices(int[] prices) // Отобразить цены на мероприятие
		{
            button27.Text = prices[0].ToString() + " р.";
            button26.Text = prices[1].ToString() + " р.";
            button25.Text = prices[2].ToString() + " р.";
        }

		private void button10_Click(object sender, EventArgs e)
		{
            if (MessageBox.Show("Вы уверены, что хотите купить билет на 1 место в 3 ряду?", "Подтверждение покупки", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
			{
                if (Ticket_Office.Buy_Ticket(Event, Date, Time, 3, 1) == true)
                {
                    button10.Enabled = false;
                    button10.BackColor = Color.Gray;
                    label3.Text = Ticket_Office.MyCash.ToString() + " р.";
                }
			}
        }
	}
}
