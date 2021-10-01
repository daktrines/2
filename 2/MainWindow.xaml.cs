using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_1;
using LibMas;
using Масивы;

namespace _2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Вывод информации о программе
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Калион Екатерина. Пр2" +
                " Ввести n целых чисел. Найти сумму чисел > 5. Результат вывести на экран");
        }

        //Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int[] mas;
        
        //Редактирование ячеек
        private void МассивDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Очищаем textbox с результатом 
            rez1.Clear();

            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;

            //Заносим  отредоктированое значение в соответствующую ячейку массива
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out mas[columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }

        //Заполнение массива
        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            
            //Проверка поля на корректность введенных данных
            if (Int32.TryParse(kolKolonka.Text, out int count) && count > 0)
            {
                Class1.Заполнить(count, out mas);
                
                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

                //очищаем результат
                rez1.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        //Расчет задания для массива
        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            rez1.Clear();
            
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Вы не создали массив, укажите количество колонок, диапазон чисел и нажмите кнопку Заполнить", "Ошибка");
            }
            else
            {
                int sum = Class2.Рассчитать(mas);
                rez1.Text = Convert.ToString(sum);
            }
        }
        //Очищение массива
        private void ОчиститьМассив_Click(object sender, RoutedEventArgs e)
        {
            Class1.ОчиститьМассив(mas);

            //Очищаем результат массива
            rez1.Clear();
           
            //Выводим массив на форму
            masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }
        //Сохранение массива
        private void Savemas_Click(object sender, RoutedEventArgs e)
        {
            Class1.Savemas(mas);
        }

        //Открытие массива
        private void Openmas_Click(object sender, RoutedEventArgs e)
        {
            
            Class1.Openmas( out mas);
            for (int i = 0; i < mas.Length; i++)
            {
                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

    }
}
