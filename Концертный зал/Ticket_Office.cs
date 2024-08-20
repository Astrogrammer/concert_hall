using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ticket_Office
{
	public static class Ticket_Office
	{
		static List<Ticket> Office_Tickets = new List<Ticket>(216);
		static List<Ticket> My_Tickets = new List<Ticket>();
		static int cash; // Выручка
		static int mycash = 10000; // Мой кошелёк
        static int counter = 0; // Количество напечатанных билетов
		static int all_count = 1; // Счётчик уникальных идентификаторов билетов
        static int my_counter = 0; // Количество приобретённых билетов
		static int happy_number; // Номер счастливого билета

		delegate void WatchTicket(Ticket bought_ticket); // Просмотреть информацию о билете
		static event WatchTicket ticketBought; // Билет куплен

		delegate void WriteFeedback(string visited_event); // Написать отзыв о посещённом мероприятии
		static event WriteFeedback ticketUsed; // Билет использован

		delegate void ReturnMoney(int happy_price); // Вернуть деньги за счастливый билет
		static event ReturnMoney happyTicketBought; // Куплен счастливый билет

		
		public static List<Ticket> MyTickets
		{
			get
			{
				return My_Tickets;
			}
			set
			{
				My_Tickets = value;
			}
		}

		public static int All_Count
		{
			get
			{
				return all_count;
			}
			set
			{
				all_count = value;
			}
		}
		public static int MyCash
		{
			get
			{
				return mycash;
			}
		}
		public static void Print_Tickets(string title_event, string date, string[] times, int min_price)
		{
			for (int i = 1; i <= times.Length; i++)
				for (int j = 1; j <= 24; j++) // Число мест в зале ограничено
				{
					if (j < 11)
					{
						var Ticket = new Ticket(title_event, date, times[i-1], 3, j, i == 1 ? min_price : Convert.ToInt32(Math.Truncate(min_price * (i / 1.5))));
						Office_Tickets.Insert(counter, Ticket);
                        counter++;
						all_count++;
					}
					else if (j < 19)
					{
						var Ticket = new Ticket(title_event, date, times[i-1], 2, j - 10, i == 1 ? Convert.ToInt32(Math.Truncate(min_price * 1.4)) : Convert.ToInt32(Math.Truncate(min_price * 1.4 * (i / 1.5))));
						Office_Tickets.Insert(counter, Ticket);
                        counter++;
						all_count++;
					}
					else if (j < 25)
					{
						var Ticket = new Ticket(title_event, date, times[i-1], 1, j - 18, i == 1 ? Convert.ToInt32(Math.Truncate(min_price * 1.8)) : Convert.ToInt32(Math.Truncate(min_price * 1.8 * (i / 1.5))));
						Office_Tickets.Insert(counter, Ticket);
                        counter++;
						all_count++;
					}
				}
			//happy_number = Happy_Number(); // Установить счастливый билет
			happy_number = 1;
		}
		public static bool Buy_Ticket(string title_event, string date, string time, int row, int seat)
		{

			int ticket_index = Office_Tickets.FindIndex(ticket => ticket.Event == title_event && ticket.Date == date && ticket.Time == time && ticket.Row == row && ticket.Seat == seat);
			if (ticket_index == -1)
			{
				MessageBox.Show("Данные билета содержат ошибку. Проверьте правильность ввода.", "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return false;
			}
			else
			{
				if (mycash >= Office_Tickets[ticket_index].Price)
				{
					mycash -= Office_Tickets[ticket_index].Price;
					cash += Office_Tickets[ticket_index].Price;
					Office_Tickets[ticket_index].Bought = true;
					My_Tickets.Insert(my_counter, Office_Tickets[ticket_index]);
                    my_counter++;
                    counter--;
					Form_Tickets form4 = new Form_Tickets();
					ticketBought = form4.Watch_One_Ticket; // Подписка
					happyTicketBought = ReturnMoneyTicket;
					ticketBought?.Invoke(Office_Tickets[ticket_index]); // Генерация события
					if (Office_Tickets[ticket_index].ID == happy_number)
						happyTicketBought?.Invoke(Office_Tickets[ticket_index].Price);
					Office_Tickets.RemoveAt(ticket_index);
					return true;
				}
				else
				{
					MessageBox.Show("На вашем счёте недостаточно средств для совершения покупки.", "Ошибка оплаты", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return false;
				}
			}
			
		}

        public static bool Return_Ticket(string title_event, string date, string time, int row, int seat)
        {
            int ticket_index = My_Tickets.FindIndex(ticket => ticket.Event == title_event && ticket.Date == date && ticket.Time == time && ticket.Row == row && ticket.Seat == seat);
            if (ticket_index == -1)
            {
                MessageBox.Show("Данные билета содержат ошибку. Проверьте правильность ввода.", "Ошибка возврата", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }
            else
            {
                if (My_Tickets[ticket_index].Used == false)
                {
                    mycash += My_Tickets[ticket_index].Price;
                    cash -= My_Tickets[ticket_index].Price;
                    My_Tickets[ticket_index].Bought = false;
                    Office_Tickets.Insert(counter, My_Tickets[ticket_index]);
                    my_counter--;
                    counter++;
                    My_Tickets.RemoveAt(ticket_index);
                    return true;
                }
                else
                {
                    MessageBox.Show("Нельзя вернуть использованный билет.", "Ошибка возврата", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
        }
		public static bool Use_Ticket(string title_event, string date, string time, int row, int seat)
		{
			bool close_form4 = false;
			int ticket_index = My_Tickets.FindIndex(ticket => ticket.Event == title_event && ticket.Date == date && ticket.Time == time && ticket.Row == row && ticket.Seat == seat);
			Form_Feedbacks form5 = new Form_Feedbacks();
			ticketUsed = form5.Write_One_Feedback;
			if (MessageBox.Show("Благодарим за посещение нашего зала! Желаете оставить отзыв?", "Оставить отзыв", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				ticketUsed?.Invoke(My_Tickets[ticket_index].Event);
				close_form4 = true;
			}
			My_Tickets[ticket_index].Used = true;
			return close_form4;
		}

		public static Point[] Check_Seats(string check_title, string check_time, int max_price) // Вычислить занятые места
		{
			IEnumerable<Ticket> bought_disabled = MyTickets.Where(ticket => ticket.Event == check_title && ticket.Time == check_time);
			IEnumerable<Ticket> price_disabled = Office_Tickets.Where(ticket => ticket.Event == check_title && ticket.Time == check_time && ticket.Price > max_price);
			/* Можно было реализовать как последовательность .Where.Select
			 Разделено для наглядности */
			IEnumerable<Point> points_bought = bought_disabled.Select(ticket => new Point(ticket.Row, ticket.Seat));
			IEnumerable<Point> points_prices = price_disabled.Select(ticket => new Point(ticket.Row, ticket.Seat));

			Point[] disabled = new Point[0]; // Список занятых мест в формате (ряд, место)

			foreach (Point ticket in points_bought) // Отложенное выполнение запроса
			{
				Array.Resize(ref disabled, disabled.Length + 1);
				disabled[disabled.Length - 1] = ticket;
			}

			if (max_price != -1)
				foreach (Point ticket in points_prices)
				{
					Array.Resize(ref disabled, disabled.Length + 1);
					disabled[disabled.Length - 1] = ticket;
				}

			/*foreach (Ticket ticket in My_Tickets)
			{
				if (ticket.Event == check_title && ticket.Time == check_time)
				{
					Array.Resize(ref disabled, disabled.Length + 1);
					disabled[disabled.Length - 1] = new Point (ticket.Row, ticket.Seat);
				}
			}*/
			return disabled;
		}

		public static int[] Set_Prices(string check_title, string check_time)
		{
			int[] prices = new int[3];
			foreach (Ticket ticket in Office_Tickets)
			{
				if (ticket.Event == check_title && ticket.Time == check_time)
				{
					if (ticket.Row == 1)
						prices[0] = ticket.Price;
					if (ticket.Row == 2)
						prices[1] = ticket.Price;
					if (ticket.Row == 3)
						prices[2] = ticket.Price;
				}
			}
			return prices;
		}

		public static int Happy_Number()
		{
			Random rnd = new Random();
			return rnd.Next(1, 216);
		}

		public static void ReturnMoneyTicket(int price)
		{
			mycash += price;
			cash -= price;
			MessageBox.Show("Поздравляем! Вы купили счастливый билет! Его стоимость " + price + " р. была Вам полностью возвращена!", "Счастливый билет", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
