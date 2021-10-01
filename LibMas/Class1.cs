using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace LibMas
{
    public class Class1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="mas"></param>
       
        
        //Заполнение массива
        public static void Заполнить( int count, out int[] mas)
        {
            //задаем массиву размерность
            mas = new int[count];

            //Заполняем массив случайными числами
            Random rnd = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(-150, 150);
            }
        }


        //Очищение массива
        public static void ОчиститьМассив(int[] mas)
        {
            //Заполняем массив нулями
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }

        }


        //Сохранение массива
        public static void Savemas(int[] mas)
        {
            //Создаем и настраиваем элемент SaveFileDialog
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            //Открываем диалоговое окно и при успехе работаем с файлом
            if (save.ShowDialog() == true)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamWriter file = new StreamWriter(save.FileName);

                //Записываем размер массива в файл
                file.WriteLine(Convert.ToString(mas.Length));

                //Записываем элементы массива в файл
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
                file.Close();
            }
        }


        //Открытие массива
        public static void Openmas(out int[] mas)
        {
            mas = new int[1];
            //Создаем и настраиваем элемент OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открыть таблицы";

            //Открываем диалоговое окно и при успехе работаем с файлом
            if (open.ShowDialog() == true)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamReader file = new StreamReader(open.FileName);

                //Читаем размер массива
                int x = Convert.ToInt32(file.ReadLine());

                //Создаем массив
                mas = new Int32[x];

                //Считываем массив из файла
                for (int i = 0; i < mas.Length; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
                file.Close();


            }

        }
    }
}

