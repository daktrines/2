using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public class Class2
    {
        /// <summary>
        /// //Расчет задания для массива
        /// </summary>
        /// <param name="mas"> мвссив </param> 


        public static int Рассчитать(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 5)
                {
                    sum += mas[i]; //вычисляем сумму чисел
                }
            }
            return sum;
        }
    }
}
