using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
	public class Ticket
	{
		private int id; // Уникальный номер билета
		private string event_; // Название мероприятия
		private string date; // Дата проведения
		private string time; // Время проведения
		private int row; // Ряд
		private int seat; // Место
		private int price; // Цена билета
		private bool bought; // Флажок: приобретён или нет
		private bool used; // Флажок: использован или нет

		public Ticket(string event_, string date, string time, int row, int seat, int price)
		{
			this.id = Ticket_Office.All_Count;
			this.event_ = event_;
			this.date = date;
			this.time = time;
			this.row = row;
			this.seat = seat;
			this.price = price;
			bought = false; // Новый билет не приобретён и не использован
			used = false;
		}
		/* Новый билет печатается только один раз, данные на нём не могут измениться.
		   Поэтому нет свойств для их изменения. */
		public int ID
		{
			get
			{
				return id;
			}
		}
		public string Event
		{
			get
            {
                return event_;
            }
		}

		public string Date
		{
            get
            {
                return date;
            }
        }

		public string Time
		{
            get
            {
                return time;
            }
        }

		public int Row
		{
            get
            {
                return row;
            }
        }

		public int Seat
		{
            get
            {
                return seat;
            }
        }

		public int Price
		{
            get
            {
                return price;
            }
        }

		public bool Bought
		{
            get
            {
                return bought;
            }
            set
            {
                bought = value;  // Билет можно вернуть
            }
		}

		public bool Used
		{
            get
            {
                return used;
            }
            set
            {
                used = true;  // Использовать билет можно только один раз
            }
		}
	}
}
