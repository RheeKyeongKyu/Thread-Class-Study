using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Thread_Class_Caesar_Cipher
{
    class Program
    {
        static string text = "He was a boy. She was a girl. Can I make it any more obvious?";
        const int MAX = 10000000;
        const int SHIFT = 3;

        static void Main(string[] args)
        {
            // Setting up test data to be encrypted
            var textList = new List<string>(MAX);
            for (int i = 0; i < MAX; i++)
            {
                textList.Add(text);
            }

            SequentialEncrypt(textList: textList);
            ParallelEncrypt(textList: textList);
        }

        static List<string> SequentialEncrypt(List<string> textList)
        {
            // Copy List<string> to new List<string>
            List<string> textListCopy = textList.ConvertAll(s => s);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Sequential Processing
            for (int i = 0; i < textListCopy.Count; i++)
            {
                // Run Caesar Cipher and replace the string with encrypted one
                textListCopy[i] = CaesarCipher(textListCopy[i].ToCharArray());
            }

            watch.Stop();
            Console.WriteLine($"Sequential Process: {watch.Elapsed}");

            return textListCopy;
        }
        
        static List<string> ParallelEncrypt(List<string> textList)
        {
            // Copy List<string> to new List<string>
            List<string> textListCopy = textList.ConvertAll(s => s);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Parallel Processing
            Parallel.For(fromInclusive: 0, toExclusive: textListCopy.Count, body: i =>
            {
                // Run Caesar Cipher and replace the string with encrypted one
                textListCopy[i] = CaesarCipher(textListCopy[i].ToCharArray());
            });

            watch.Stop();
            Console.WriteLine($"Parallel Process: {watch.Elapsed}");

            return textListCopy;
        }

        static string CaesarCipher(char[] chArr)
        {
            // Apply Caesar Cipher to all characters
            for (int x = 0; x < chArr.Length; x++)
            {
                // if character is in range a-z
                if (chArr[x] >= 'a' && chArr[x] <= 'z')
                {
                    chArr[x] = (char)('a' + ((chArr[x] - 'a' + SHIFT) % 26));
                }
                else if (chArr[x] >= 'A' && chArr[x] <= 'Z') // if character is in range A-Z
                {
                    chArr[x] = (char)('A' + ((chArr[x] - 'A' + SHIFT) % 26));
                }
            }

            return new string(chArr);   
        }
    }
}
