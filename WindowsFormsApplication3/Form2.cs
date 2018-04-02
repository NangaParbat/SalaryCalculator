using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("D:\\data.txt", true); // Инициализация "Записывателя" в файл 
            if (textBox1.Text == "") // Проверка на пустоту формы
            {
                MessageBox.Show("Введите имя сотрудника"); // Если форма пустая - просит заполнить ее
            }
            else
            {
                writer.WriteLine(textBox1.Text); // Запись первой строки в файл, равной значению содержимого строки
            }
           
            if (radioButton1.Checked) // Если выбран первый вариант "Employee"
                writer.WriteLine("Employee"); // Запись второй строки в файл
            if (radioButton2.Checked) // Если выбран второй вариант "Manager"
                writer.WriteLine("Manager");// Запись второй строки в файл
            if (radioButton3.Checked) // Если выбран третий вариант "Salesman"
                writer.WriteLine("Salesman");// Запись второй строки в файл
            if (textBox2.Text == "") // Проверка на пустоту формы
            {
                MessageBox.Show("Введите стаж"); // Если форма пустая - просит заполнить ее
            }
            else
            {
                writer.WriteLine(textBox2.Text); // Запись первой строки в файл, равной значению содержимого строки
            }
            writer.Close(); // Завершение работы "Записывателя"

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked || textBox1.Text == "" || textBox2.Text == "") // Если ни один radioButton не выбран
            {
                MessageBox.Show("Вы не выбрали Должность или не указали Имя/Стаж."); // Выводит сообщение требующее указать параметры
            }
            else
            {

                textBox1.Text = ""; // Очищает текстбокс для новой записи
                textBox2.Text = ""; // Очищает текстбокс для новой записи
                MessageBox.Show("Готово!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information); // говорит что все сделано (пиздит)
            }
            }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
   
