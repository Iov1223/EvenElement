using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EvenElement
{
    class Array
    {
        private int[] _arr;
        private List<int> _evenArr;
        StreamWriter _writer;

        public Array(string[] arr)
        {
            _arr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                _arr[i] = Convert.ToInt32(arr[i]);
            }
            
        }
        public void ShowArr()
        {
            Console.Write("[ ");
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write($"{_arr[i]}, ");
            }
            Console.WriteLine("\b\b]");
        }
        public void CheckEvenElements()
        {
            _evenArr = new List<int>();
            _writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\numbers.txt", true);
            for (int i = 0; i < _arr.Length; i++)
            {
                if (i % 2 != 0 && _arr[i] > 10)
                {
                    _evenArr.Add(_arr[i]);
                }
            }
            _writer.Write("[ ");
            for (int i = 0; i < _evenArr.Count; i++)
            {
                _writer.Write($"{_evenArr[i]}, ");
            }
            _writer.WriteLine("\b\b]");
            _writer.Close();
        }
        public void Summ()
        {
            _writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\summ.txt", true);
            int sum = 0;
            for (int i = 0; i < _evenArr.Count; i++)
            {
                sum += _evenArr[i];
            }
            _writer.WriteLine(sum);
            _writer.Close();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Array myArr = new Array(args);
                myArr.ShowArr();
                myArr.CheckEvenElements();
                myArr.Summ();
            }
            else
            {
                Console.WriteLine("Программа требует ввода аргументов командной строки.");
            }
        }
    }
}
