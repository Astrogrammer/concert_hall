using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
	public static class Feedback_Base
	{
		static List<Feedback> feedbacks = new List<Feedback>();
		static List<Feedback> feedbacks_Visible = new List<Feedback>(); // Для сортировки отзывов
		static private int counter = 0;

		public static List<Feedback> Feedbacks { get { return feedbacks; } set { feedbacks = value; } }
		public static List<Feedback> Feedbacks_Visible { get { return feedbacks_Visible; } set { feedbacks_Visible = value; } }

		public static void Create_Feedback(string title_event, int mark, string text)
		{
			counter++;
			Feedbacks.Add(new Feedback(counter, title_event, mark, text));
		}

		public static void Remove_Feedback(int number)
		{
			IEnumerable<Feedback> removable_feedback = Feedbacks.Where(feedback => feedback.number == number);
			foreach (var feedback in removable_feedback)
			{
				Feedbacks.Remove(feedback);
				break;
			}
		}
	}
}
