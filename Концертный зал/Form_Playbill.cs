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
	public partial class Form_Playbill : Form
	{
		public Form_Office form2;
		public Form_Tickets form4;
		public Form_Feedbacks form5;
		public Form_Playbill()
		{
			InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
		{
			form2 = new Form_Office();
			form2.Show();
        }

		private void button2_Click(object sender, EventArgs e)
		{
			if (Ticket_Office.MyTickets.Count == 0)
				MessageBox.Show("Вы ещё не купили ни одного билета!");
			else
			{
				form4 = new Form_Tickets();
				form4.Show();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			form5 = new Form_Feedbacks();
			form5.Show();
		}
	}
}
