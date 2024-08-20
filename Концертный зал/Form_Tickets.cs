using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Ticket_Office
{
	public partial class Form_Tickets : Form
	{
		SoundPlayer Mozart, Chaikovsky, Chopin;
		public Form_Tickets form4_copy;
		string[] events;
		string[] dates;
		string[] times;
		int[] rows;
		int[] seats;
		int[] prices;
		bool[] used;
		int count_tickets = 0;
		int this_ticket = 0;
		bool need_close = false;
		public Form_Tickets()
		{
			InitializeComponent();
			Mozart = new SoundPlayer(Environment.CurrentDirectory + "\\Моцарт.wav");
			Chaikovsky = new SoundPlayer(Environment.CurrentDirectory + "\\Чайковский.wav");
			Chopin = new SoundPlayer(Environment.CurrentDirectory + "\\Шопен.wav");
			count_tickets = Ticket_Office.MyTickets.Count;
			if (count_tickets != 0)
			{
				events = new string[count_tickets];
				dates = new string[count_tickets];
				times = new string[count_tickets];
				rows = new int[count_tickets];
				seats = new int[count_tickets];
				prices = new int[count_tickets];
				used = new bool[count_tickets];

				for (int i = 0; i < count_tickets; i++)
				{
					events[i] = Ticket_Office.MyTickets[i].Event;
					dates[i] = Ticket_Office.MyTickets[i].Date;
					times[i] = Ticket_Office.MyTickets[i].Time;
					rows[i] = Ticket_Office.MyTickets[i].Row;
					seats[i] = Ticket_Office.MyTickets[i].Seat;
					prices[i] = Ticket_Office.MyTickets[i].Price;
					used[i] = Ticket_Office.MyTickets[i].Used;
				}
				label2.Text = events[0];
				label4.Text = dates[0];
				label5.Text = times[0];
				label7.Text = rows[0].ToString();
				label9.Text = seats[0].ToString();
				label11.Text = prices[0].ToString() + " р.";
				if (count_tickets > 1)
					button3.Enabled = true;
				if (used[0] == true)
				{
					button1.Enabled = false;
					button2.Enabled = false;
					button1.Text = "Использован";
				}
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this_ticket++;
			if (used[this_ticket] == true)
			{
				button1.Enabled = false;
				button2.Enabled = false;
				button1.Text = "Использован";
			}
			else
			{
				button1.Enabled = true;
				button2.Enabled = true;
				button1.Text = "Использовать";
			}
			label2.Text = events[this_ticket];
			label4.Text = dates[this_ticket];
			label5.Text = times[this_ticket];
			label7.Text = rows[this_ticket].ToString();
			label9.Text = seats[this_ticket].ToString();
			label11.Text = prices[this_ticket].ToString() + " р.";
			if (count_tickets > this_ticket + 1)
				button3.Enabled = true;
			else
				button3.Enabled = false;
			button4.Enabled = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this_ticket--;
			if (used[this_ticket] == true)
			{
				button1.Enabled = false;
				button2.Enabled = false;
				button1.Text = "Использован";
			}
			else
			{
				button1.Enabled = true;
				button2.Enabled = true;
				button1.Text = "Использовать";
			}
			label2.Text = events[this_ticket];
			label4.Text = dates[this_ticket];
			label5.Text = times[this_ticket];
			label7.Text = rows[this_ticket].ToString();
			label9.Text = seats[this_ticket].ToString();
			label11.Text = prices[this_ticket].ToString() + " р.";
			if (this_ticket > 0)
				button4.Enabled = true;
			else
				button4.Enabled = false;
			button3.Enabled = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (events[this_ticket] == "Музыка В. А. Моцарта")
			{
				Mozart.Play();
				if (MessageBox.Show("Сейчас заиграет музыка. Нажмите кнопку «ОК», чтобы остановить воспроизведение. Приятного прослушивания!", "Музыка В. А. Моцарта", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
				{
					Mozart.Stop();
					need_close = Ticket_Office.Use_Ticket(events[this_ticket], dates[this_ticket], times[this_ticket], rows[this_ticket], seats[this_ticket]);
					if (!need_close)
					{
						form4_copy = new Form_Tickets();
						form4_copy.Show();
					}
					Close();
				}
			}
			if (events[this_ticket] == "Музыка П. И. Чайковского")
			{
				Chaikovsky.Play();
				if (MessageBox.Show("Сейчас заиграет музыка. Нажмите кнопку «ОК», чтобы остановить воспроизведение. Приятного прослушивания!", "Музыка П. И. Чайковского", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
				{
					Chaikovsky.Stop();
					need_close = Ticket_Office.Use_Ticket(events[this_ticket], dates[this_ticket], times[this_ticket], rows[this_ticket], seats[this_ticket]);
					if (!need_close)
					{
						form4_copy = new Form_Tickets();
						form4_copy.Show();
					}
					Close();
				}
			}
			if (events[this_ticket] == "Музыка Ф. Шопена")
			{
				Chopin.Play();
				if (MessageBox.Show("Сейчас заиграет музыка. Нажмите кнопку «ОК», чтобы остановить воспроизведение. Приятного прослушивания!", "Музыка Ф. Шопена", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
				{
					Chopin.Stop();
					need_close = Ticket_Office.Use_Ticket(events[this_ticket], dates[this_ticket], times[this_ticket], rows[this_ticket], seats[this_ticket]);
					if (!need_close)
					{
						form4_copy = new Form_Tickets();
						form4_copy.Show();
					}
					Close();
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверены, что хотите вернуть билет в кассу? Стоимость покупки будет полностью возвращена.", "Возврат билета", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				if(Ticket_Office.Return_Ticket(events[this_ticket], dates[this_ticket], times[this_ticket], rows[this_ticket], seats[this_ticket]) == true)
				{
					MessageBox.Show("Билет успешно возвращён в кассу! На вашем счёте теперь " + Ticket_Office.MyCash + "р.");
					count_tickets--;
					if (count_tickets == 0)
						Close();
					else
					{
						form4_copy = new Form_Tickets();
						form4_copy.Show();
						Close();
					}
				}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void Watch_One_Ticket (Ticket choosed_ticket)
		{
			Text = "Купленный билет";
			label2.Text = choosed_ticket.Event;
			label4.Text = choosed_ticket.Date;
			label5.Text = choosed_ticket.Time;
			label7.Text = choosed_ticket.Row.ToString();
			label9.Text = choosed_ticket.Seat.ToString();
			label11.Text = choosed_ticket.Price.ToString() + " р.";
			button2.Visible = false;
			button1.Visible = false;
			button3.Enabled = false;
			button4.Enabled = false;
			button5.Visible = false;
			button6.Visible = true;
			Show(); // Отобразить форму
		}

		public void Write_One_Feedback(string visited_event)
		{
			Close();
		}
	}
}
