using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticket_Office;

namespace Концертный_зал
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string[] dates = new string[] { "01.04.2022", "02.04.2022", "03.04.2022" };
			string[] times1 = new string[] { "12:30", "16:30", "19:00" }; // В порядке возрастания, влияет на цену
			string[] times2 = new string[] { "11:45", "17:00", "19:00" };
			string[] times3 = new string[] { "13:15", "17:15", "20:00" };

			Ticket_Office.Ticket_Office.Print_Tickets("Музыка В. А. Моцарта", dates[0], times1, 950); // Напечатать билеты
			Ticket_Office.Ticket_Office.Print_Tickets("Музыка П. И. Чайковского", dates[1], times2, 1000);
			Ticket_Office.Ticket_Office.Print_Tickets("Музыка Ф. Шопена", dates[2], times3, 890);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form_Playbill());
		}
	}
}
