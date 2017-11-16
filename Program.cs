using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    class Program
    {
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }


        static void Main(string[] args)
        {
            var startingDeck = from s in Suits()
                               from r in Ranks()
                               select new { Suit = s, Rank = r };


            /*
            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine();
            Console.WriteLine();
            var top = startingDeck.Take(26);
            var bottom = startingDeck.Skip(26);
            var shuffle = top.InterleaveSequenceWith(bottom);

            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }
            */

            var times = 0;
            var shuffle = startingDeck;

            do
            {
                shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));

                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                Console.WriteLine();
                times++;
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }
    }
}
