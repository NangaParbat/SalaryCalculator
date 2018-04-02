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
    
    public struct people // Создание структуры сотрудников
    {
        public string name; // Элемент "имя"
        public string position; // Элемент "должность"
        public string experience; // Элемент "Стаж"
    }
    public partial class Form1 : Form
    {
        List<people> l = new List<people>(); // Создание списка сотрудников

        public Form1()
        {
            InitializeComponent();
        }
        
        public static double base_empPerc = 0.03; // Базовый процент Employee
        public static double base_manPerc = 0.05; // Базовый процент Manager
        public static double base_salPerc = 0.01; // Базовый процент Salesman
        public static double max_empPerc = 0.30; // Максимальный процент Employee
        public static double max_manPerc = 0.40; // Максимальный процент Manager
        public static double max_salPerc = 0.35; // Максимальный процент Salesman
        public static double base_salary = 20000; // Условная базовая ставка
        public static double end_empPerc = base_empPerc * exp; // Формула вычисления итогового процента Emloyee
        public static double end_manPerc = base_manPerc * exp; // Формула вычисления итогового процента Manager
        public static double end_salPerc = base_salPerc * exp; // Формула вычисления итогового процента Salesman
        public static double exp = 0; // Переменная опыта, условно равна нулю.
        public static double emp_salary(double base_empPerc, double base_salary, double end_empPerc, double exp) // Метод - итоговая зарплата Employee
        {
            end_empPerc = base_empPerc * exp; // Формула вычисления итогового процента Emloyee
            if (end_empPerc > max_empPerc) // Условие при котором конечный процент не может быть больше максимального
            {
                end_empPerc = max_empPerc;
            }
            return base_salary + base_salary * end_empPerc; // Возвращение значения зарплаты Employee
            

        }

        public static double man_salary(double base_manPerc, double base_salary, double end_manPerc, double exp) // Метод - итоговая зарплата Manager
        {
            end_manPerc = base_manPerc * exp; // Формула вычисления итогового процента Manager
            if (end_manPerc > max_manPerc) // Условие при котором конечный процент не может быть больше максимального
            {
                end_manPerc = max_manPerc;
            }
            return base_salary + base_salary * end_manPerc; // Возвращение значения зарплаты Manager


        }

        public static double sal_salary(double base_salPerc, double base_salary, double end_salPerc, double exp) // Метод - итоговая зарплата Salesman
        {
            end_salPerc = base_salPerc * exp; // Формула вычисления итогового процента Salesman
            if (end_salPerc > max_salPerc) // Условие при котором конечный процент не может быть больше максимального
            {
                end_salPerc = max_salPerc;
            }
            return base_salary + base_salary * end_salPerc; // Возвращение значения зарплаты Salesman

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) // Если выбран Employee
            {
                exp = Convert.ToDouble(textBox4.Text); // Присвоение значения введенного в textbox значению стажа
                textBox5.Text = Convert.ToString(emp_salary(base_empPerc, base_salary, end_empPerc, exp)); // Конвертация в тип string из типа double и вывод полученного значения в textbox "Зарплата:"
            }
            if (radioButton2.Checked) // Если выбран Manager
            {
                exp = Convert.ToDouble(textBox4.Text); // Присвоение значения введенного в textbox значению стажа
                textBox5.Text = Convert.ToString(man_salary(base_manPerc, base_salary, end_manPerc, exp)); // Конвертация в тип string из типа double и вывод полученного значения в textbox "Зарплата:"
            }
            if (radioButton3.Checked) // Если выбран Salesman
            {
                exp = Convert.ToDouble(textBox4.Text); // Присвоение значения введенного в textbox значению стажа
                textBox5.Text = Convert.ToString(sal_salary(base_salPerc, base_salary, end_salPerc, exp)); // Конвертация в тип string из типа double и вывод полученного значения в textbox "Зарплата:"
            }
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) // Если не выбран ни один из вариантов  - 
            {
                MessageBox.Show("Пожалуйста, выберите тип работника: Employee, Manager или Salesman"); // Выводится MessageBox
                return;
            }

            
        }

      

       private void Form1_Load(object sender, EventArgs e) // Подгружает базу данных при старте программы
        {
            
            StreamReader sr = new StreamReader("D:\\data.txt"); 
            string m; 
            while ((m = sr.ReadLine()) != null) 
            {
                people A; 
                A.name = m; 
                A.position = sr.ReadLine();
                A.experience = sr.ReadLine();
                l.Add(A); 
            }
            sr.Close(); 
        }

        private void button2_Click(object sender, EventArgs e) // Кнопка: "Очистить все элементы"
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8) //Если символ, введенный с клавиатуры - не цифра или Backspace,
            {
                e.Handled = true;// то событие не обрабатывается. 
            }
        }

        private void button3_Click(object sender, EventArgs e) // Кнопка Закрыть
        {
            this.Close(); 
        }

        int find(string s) // Задание переменной find
        {
            for (int i = 0; i < l.Count; i++) // Цикл для поиска совпадений
                if (l[i].name.Equals(s))
                    return i;

            return -1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text; // Переменная получает введенное значение
            int x = find(s); // Идет поиск совпадений
            if (x != -1)
                textBox2.Text = l[x].position; //Если нашлось - показывает должность
            if (x != -1)
                textBox4.Text = l[x].experience;
            else
                MessageBox.Show("Запись не найдена"); // Если нет - выводит сообщение что не нашлось

            if (textBox2.Text == "Employee") // Если после поиска нашлось и у найденного сотрудника соответствующая должность - устанавливает radioButton на ту должность
            {
                radioButton1.Checked = true; 
            }
            if (textBox2.Text == "Manager") // Если после поиска нашлось и у найденного сотрудника соответствующая должность - устанавливает radioButton на ту должность
            {
                radioButton2.Checked = true;
            }
            if (textBox2.Text == "Salesman") // Если после поиска нашлось и у найденного сотрудника соответствующая должность - устанавливает radioButton на ту должность
            {
                radioButton3.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2(); // Открытие формы с добавлением нового сотрудника
            s.Show();
        }

        private void button5_Click(object sender, EventArgs e) // Подгружает базу данных еще раз, для получения недавно введенных данных (за текущую сессию)
        {
            StreamReader sr = new StreamReader("D:\\data.txt");
            string m;
            while ((m = sr.ReadLine()) != null)
            {
                people A;
                A.name = m;
                A.position = sr.ReadLine();
                A.experience = sr.ReadLine();
                l.Add(A);
            }
            sr.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void обновитьИнтерфейсToolStripMenuItem_Click(object sender, EventArgs e) // То же что и кнопка очистки формы
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void новыйРаботникToolStripMenuItem_Click(object sender, EventArgs e) // То же что и кнопка "Новый работник"
        {
            Form2 s = new Form2();
            s.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // Закрытие программы
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) // Вывод описания программы
        {
            MessageBox.Show("Тестовое задание для расчета заработной платы. Системные Технологии. 2018","Зарплатник - О Программе",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e) // То же что и "О Программме"
        {
            MessageBox.Show("Тестовое задание для расчета заработной платы. Системные Технологии. 2018", "Зарплатник - О Программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для корректной работы программы требуется \nсоздание файла базы данных в корне диска D. \nПо этой причине программа при первом запуске выдает ошибку.\n В последствии, после первого запуска \nпрограмма создает этот файл и ошибки больше нет. \nПосле создания нового сотрудника, если к \nнему требуется доступ, необходимо нажать на кнопку \nОбновить базу данных, иначе сотрудника будет \nневозможно найти.", "F.A.Q.", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
