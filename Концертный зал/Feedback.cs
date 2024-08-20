using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Office
{
	public class Feedback
	{
		public int number { get; }
		public string title_event { get; }
		public int mark { get; }
		public string text { get; }
		public Feedback(int number, string title_event, int mark, string text)
		{
			this.number = number;
			this.title_event = title_event;
			this.mark = mark;
			this.text = text;
		}
	}
}
