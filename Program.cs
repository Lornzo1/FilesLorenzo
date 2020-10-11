using System;
using System.IO; // Add for file I/O operations
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;

namespace FilesExamplesSDC
{
    class Program
    {
        static void WriteSentences(string myFile = "sentences.txt", int[] n = null)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            myFile = Path.Combine(docPath, myFile);
            var fileStr = File.AppendText(myFile);
            int t = 0;
            while (true)
            {
                var nextLine = " ";
                try
                {
                    nextLine = Convert.ToString(n[t]);
                }
                catch
                {
                    Console.WriteLine("Enter next sentence: ");
                    nextLine = Console.ReadLine();
                }
                if (string.IsNullOrWhiteSpace(nextLine))
                    break;
                fileStr.WriteLine(nextLine);
                t += 1;
            }
            fileStr.Close();
        }
        public static void GetRandom(int n)
        {
            Random rnd = new Random();
            List<int> list = new List<int>();
            for (int i =0; list.Count<n; i++)
            {
                int randomNumber = rnd.Next(1, 26);

                if (!list.Contains(randomNumber))
                {
                    list.Add(randomNumber);
                }
            }
            WriteSentences("numbers",list.ToArray());
        }
        static public void mergemethod(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;
            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }
            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];
            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];
            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }

        }
        static public void sortmethod(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                sortmethod(numbers, left, mid);
                sortmethod(numbers, (mid + 1), right);
                mergemethod(numbers, left, (mid + 1), right);

            }
        }
        static void Main()
        {
            Console.WriteLine("File manipulation");
            int[] t = { 1, 5, 3, 9, 2, 5 };
            sortmethod(t,0,t.Length - 1);
            WriteSentences("sorted", t);
        }
    }
}
