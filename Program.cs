using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades

    }

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Program
    {
        static IEnumerable<Suit> Suits() => Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>;

        static IEnumerable<Rank> Ranks() => Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>;


        static void Main(string[] args)
        {
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                                from r in Ranks().LogQuery("Rank Generation")
                                select new PlayingCard(s, r))
                                .LogQuery("Starting Deck")
                                .ToArray();


            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine();
            var times = 0;
            var shuffle = startingDeck;

            do
            {
                shuffle = shuffle.Skip(26).LogQuery("Bottom Half")
                    .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                    .LogQuery("Shuffle")
                    .ToArray();

                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }
    }
}
