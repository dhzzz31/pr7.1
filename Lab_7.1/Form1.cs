using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // задаем фильтр для файлов только .jpg
            // до слеша как отображается фильтр в окне, а после сама маскa
            file1.Filter = "(*.jpg)|*.jpg";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // создаем переменную fname строкового типа
            string fname;
            // открываем Проводник
            file1.ShowDialog();
            // используем переменную для хранения имени выбранного файла
            fname = file1.FileName;
            // зпгружаем файл в PictureBox
            pct.Image = Image.FromFile(fname);
            // в textbox1 выводится полное имя открытого файла после нажатия ок
            if (file1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file1.SafeFileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, содержит ли элемент pct изображение
            if (pct.Image != null)
            {
                // Создаем объект диалогового окна для сохранения файла
                SaveFileDialog sfg = new SaveFileDialog();
                // Устанавливаем заголовок диалогового окна как текст элемента pct
                sfg.Title = pct.Text;
                // Устанавливаем заголовок диалогового окна как текст элемента pct
                sfg.OverwritePrompt = true;
                // Проверять существование пути к файлу
                sfg.CheckPathExists = true;
                // Задаем фильтр для выбора типа файла (только jpg)
                sfg.Filter = "(*.jpg)|*.jpg";
                // Показывает справку в диалоговом окне
                sfg.ShowHelp = true;
                // Проверяем, выбран ли файл в диалоговом окне
                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем изображение элемента pct в выбранный файл
                    pct.Image.Save(sfg.FileName);
                }
            }
        }
    }
}
