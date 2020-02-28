using System;
using System.Threading;

namespace Algorithms.LeetCode
{
    /* 1195. Fizz Buzz Multithreaded
     * 
     * Write a program that outputs the string representation of numbers from 1 to n, however:
     * 
     *     If the number is divisible by 3, output "fizz".
     *     If the number is divisible by 5, output "buzz".
     *     If the number is divisible by both 3 and 5, output "fizzbuzz".
     * 
     * For example, for n = 15, we output: 1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizzbuzz.
     * 
     * Implement a multithreaded version of FizzBuzz with four threads. The same instance of FizzBuzz will be passed
     * to four different threads:
     * 
     *     Thread A will call fizz() to check for divisibility of 3 and outputs fizz.
     *     Thread B will call buzz() to check for divisibility of 5 and outputs buzz.
     *     Thread C will call fizzbuzz() to check for divisibility of 3 and 5 and outputs fizzbuzz.
     *     Thread D will call number() which should only output the numbers.
     */
    public class FizzBuzz
    {
        private readonly int n;
        int num = 1;
        private readonly SemaphoreSlim _sem = new SemaphoreSlim(3); // Or SpinWait for better performance.

        public FizzBuzz(int n)
        {
            this.n = n;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (num <= n)
            {
                _sem.Wait();
                if (num <= n && num % 3 == 0 && num % 5 != 0)
                {
                    printFizz();
                    num++;
                }
                _sem.Release();
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (num <= n)
            {
                _sem.Wait();
                if (num <= n && num % 5 == 0 && num % 3 != 0)
                {
                    printBuzz();
                    num++;
                }
                _sem.Release();
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (num <= n)
            {
                _sem.Wait();
                if (num <= n && num % 3 == 0 && num % 5 == 0)
                {
                    printFizzBuzz();
                    num++;
                }
                _sem.Release();
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            while (num <= n)
            {
                _sem.Wait();
                if (num <= n && num % 3 != 0 && num % 5 != 0)
                {
                    printNumber(num);
                    num++;
                }
                _sem.Release();
            }
        }
    }
}
