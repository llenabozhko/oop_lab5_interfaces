﻿using System;

namespace oop_lab5_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));


            MyFrac[] fractions = { new MyFrac(1, 3), new MyFrac(50, 60), new MyFrac(1, 2), new MyFrac(1, 4), new MyFrac(1, 8) };
            Console.WriteLine("\nUnsorted fractions:");
            foreach (var frac in fractions)
            {
                Console.WriteLine(frac);
            }

            Array.Sort(fractions, (frac1, frac2) => frac1.CompareTo(frac2));

            Console.WriteLine("\nSorted fractions:");
            foreach (var frac in fractions)
            {
                Console.WriteLine(frac);
            }
        }

        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab

            // I'm not sure how to create constant factor "2" in more elegant way,
            // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

    }
}