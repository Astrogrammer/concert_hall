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
	public partial class Form_Feedbacks : Form
	{
		private Form_Feedbacks form5_copy;
		private Form_Sorting form6;
		private int count = 1;
		private int real_number = 1;
		private int[] numbers = new int[0];
		private string[] marks = new string[0];
		private string[] texts = new string[0];
		private string[] events = new string[0];
		private int create_mark;
		private string create_event;
		private string create_text;
		private bool cleared = false;
		private bool choosed_event = false;
		public bool flag { get; set; }
		public Form_Feedbacks()
		{
			InitializeComponent();
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			count = Feedback_Base.Feedbacks.Count;
			if (count == 0)
			{
				Feedback_Base.Create_Feedback("Музыка П. И. Чайковского", 5, "Получил огромное удовольствие от прослушивания балета Чайковского \"Лебединое озеро\". В зале хорошая акустика, удобное расположение мест. Всем рекомендую!");
				count++;
			}
            Get_Feedbacks(count);
			Set_Feedback(real_number);
			if (count > 1)
				button3.Enabled = true;
		}
		public Form_Feedbacks(int about_marks_low, int about_marks_high, string about_events1, string about_events2, string about_events3, int about_text_low, int about_text_high)
		{
			InitializeComponent();
			flag = true;
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Fill_Feedback_Visible(about_marks_low, about_marks_high, about_events1, about_events2, about_events3, about_text_low, about_text_high);
			count = Feedback_Base.Feedbacks_Visible.Count;
			if (count == 0)
			{
				MessageBox.Show("К сожалению, не нашлось отзывов, удовлетворяющих Вашим фильтрам.");
				flag = false;
				Close();
			}
			Get_Feedbacks_Visible(count);
			if (count > 0 )Set_Feedback(real_number);
			if (count > 1)
				button3.Enabled = true;
		}

		private void Form5_Load(object sender, EventArgs e)
		{

		}

		public string Mark_To_Stars(int mark)
		{
			string stars_mark;
			switch (mark)
			{
				default:
					stars_mark = "*****";
					break;

				case 4:
					stars_mark = "****";
					break;

				case 3:
					stars_mark = "***";
					break;

				case 2:
					stars_mark = "**";
					break;

				case 1:
					stars_mark = "*";
					break;
			}
			return stars_mark;
		}

		public void Fill_Feedback_Visible(int about_marks_low, int about_marks_high, string about_events1, string about_events2, string about_events3, int about_text_low, int about_text_high)
		{
            Feedback_Base.Feedbacks_Visible.Clear();
            IEnumerable<Feedback> feedbacks = Feedback_Base.Feedbacks.Where(feedback => feedback.mark > about_marks_low && feedback.mark < about_marks_high && (feedback.title_event == about_events1 || feedback.title_event == about_events2 || feedback.title_event == about_events3) && feedback.text.Count() > about_text_low && feedback.text.Count() < about_text_high);
            foreach (var feedback in feedbacks)
			{
				Feedback_Base.Feedbacks_Visible.Add(feedback);
			}
		}
		public void Get_Feedbacks(int count)
		{
			Array.Resize(ref numbers, count);
			Array.Resize(ref marks, count);
			Array.Resize(ref texts, count);
			Array.Resize(ref events, count);

			for (int i = 0; i < count; i++)
			{
				numbers[i] = Feedback_Base.Feedbacks[i].number;
				marks[i] = Mark_To_Stars(Feedback_Base.Feedbacks[i].mark);
				texts[i] = Feedback_Base.Feedbacks[i].text;
				events[i] = Feedback_Base.Feedbacks[i].title_event;
			}
		}
		public void Get_Feedbacks_Visible(int count)
		{
			Array.Resize(ref numbers, count);
			Array.Resize(ref marks, count);
			Array.Resize(ref texts, count);
			Array.Resize(ref events, count);

			for (int i = 0; i < count; i++)
			{
				numbers[i] = Feedback_Base.Feedbacks_Visible[i].number;
				marks[i] = Mark_To_Stars(Feedback_Base.Feedbacks_Visible[i].mark);
				texts[i] = Feedback_Base.Feedbacks_Visible[i].text;
				events[i] = Feedback_Base.Feedbacks_Visible[i].title_event;
			}
		}
		public void Set_Feedback(int real_number)
		{
			label4.Text = Convert.ToString(numbers[real_number-1]);
			label6.Text = Convert.ToString(marks[real_number-1]);
			label5.Text = Convert.ToString(events[real_number-1]);
			richTextBox1.Text = Convert.ToString(texts[real_number-1]);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			real_number++;
			Set_Feedback(real_number);
			button4.Enabled = true;
			if (real_number == count)
				button3.Enabled = false;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			real_number--;
			Set_Feedback(real_number);
			button3.Enabled = true;
			if (real_number == 1)
				button4.Enabled = false;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно желаете удалить данный отзыв?", "Удалить отзыв", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (count != 1)
				{
					Feedback_Base.Remove_Feedback(int.Parse(label4.Text));
					MessageBox.Show("Отзыв успешно удалён!", "Удаление отзыва", MessageBoxButtons.OK, MessageBoxIcon.Information);
					form5_copy = new Form_Feedbacks();
					form5_copy.Show();
					Close();
				}
				else
					MessageBox.Show("Вы не можете удалить единственный отзыв!", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SetLabels(1);
		}

		private void SetLabels(int param)
		{
			label4.Text = Convert.ToString(numbers.Max() + 1);
			button3.Enabled = false;
			button4.Enabled = false;
			button2.Visible = false;
			button6.Visible = false;
			button7.Visible = true;
			button8.Visible = true;
			button9.Visible = true;
			button10.Visible = true;
			button11.Visible = true;
			if (param !=2)
				comboBox1.Visible = true;
			richTextBox1.Text = "Напишите свой отзыв...";
			richTextBox1.ReadOnly = false;
			button12.Visible = true;
		}
		private void button7_Click(object sender, EventArgs e)
		{
			label6.Text = "*";
			create_mark = 1;
			button7.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			label6.Text = "**";
			create_mark = 2;
			button7.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			label6.Text = "***";
			create_mark = 3;
			button7.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			label6.Text = "****";
			create_mark = 4;
			button7.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}

		private void button11_Click(object sender, EventArgs e)
		{
			label6.Text = "*****";
			create_mark = 5;
			button7.Visible = false;
			button8.Visible = false;
			button9.Visible = false;
			button10.Visible = false;
			button11.Visible = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 0)
			{
				label5.Text = "Музыка В. А. Моцарта";
				create_event = label5.Text;
				comboBox1.Visible = false;
			}
			if (comboBox1.SelectedIndex == 1)
			{
				label5.Text = "Музыка П. И. Чайковского";
				create_event = label5.Text;
				comboBox1.Visible = false;
			}
			if (comboBox1.SelectedIndex == 2)
			{
				label5.Text = "Музыка Ф. Шопена";
				create_event = label5.Text;
				comboBox1.Visible = false;
			}
		}

		private void richTextBox1_Click(object sender, EventArgs e)
		{
			if (richTextBox1.ReadOnly == false && cleared == false)
			{
				richTextBox1.Clear();
				cleared = true;
			}
				
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (button7.Visible == true)
				MessageBox.Show("Сначала выберите оценку!", "Сохранить отзыв", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else if (comboBox1.Visible == true)
				MessageBox.Show("Вам нужно указать мероприятие!", "Сохранить отзыв", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else if (cleared == false || richTextBox1.Text == "")
				MessageBox.Show("Вы не написали отзыв!", "Сохранить отзыв", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
			{
				create_text = richTextBox1.Text;
				Feedback_Base.Create_Feedback(create_event, create_mark, create_text);
				MessageBox.Show("Спасибо за отзыв!", "Отзыв сохранён", MessageBoxButtons.OK, MessageBoxIcon.Information);
				if (!choosed_event)
				{
					form5_copy = new Form_Feedbacks();
					form5_copy.Show();
				}
				Close();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form_Sorting form6 = new Form_Sorting();
			form6.Show();
			Close();
		}

		public void Write_One_Feedback(string visited_event)
		{
			choosed_event = true;
			label5.Text = visited_event;
			create_event = label5.Text;
			Show();
			SetLabels(2);
		}
	}
}
