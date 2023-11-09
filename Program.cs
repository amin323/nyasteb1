
using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);
            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);
            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);
            Console.WriteLine("Lets play a game of highest card with two players.");
            int numCardsToGet = Askforcards();
            int numRoundsToPlay = AskForRounds();
            int round = 0;
            while (round < numRoundsToPlay)
            {
                HandOfCards player1 = new HandOfCards();
                HandOfCards player2 = new HandOfCards();
                round++; 
                Console.WriteLine($"Round Nr: {round}");
                Deal(myDeck, numCardsToGet, player1, player2);
                DetermineWinner(player1, player2);
            }
        }
        static int Askforcards()
        {
            int antalkort;
            while (true)
            {
                Console.WriteLine("How many cards do you want (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out antalkort) && antalkort >= 1 && antalkort <= 5)
                {
                    return antalkort;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }
        static int AskForRounds()
        {
            int antalrundor;
            while (true)
            {
                Console.WriteLine("How many rounds do you want to play (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out antalrundor) && antalrundor >= 1 && antalrundor <= 5)
                {
                    return antalrundor;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }
        /// <param name="antalkort">Number of cards given by user</param>
        private static bool TryReadNrOfCards(out int antalkort)
        {
            antalkort = 0;
            return false;
        }
        int numCardsToGet = Askforcards();
        /// <param name="antalrundor">Number of rounds given by user</param>
        private static bool TryRead(out int antalrundor)
        {
            antalrundor = 0;
            return false;
        }

        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
  
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                PlayingCard cardToGive = myDeck.RemoveTopCard();
                if (cardToGive != null)
                {
                    player1.Add(cardToGive);
                    Console.WriteLine($"Gave 1 card to Player 1: {cardToGive}");
                }
            }
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                PlayingCard cardToGive2 = myDeck.RemoveTopCard();
                if (cardToGive2 != null)
                {
                    player2.Add(cardToGive2);
                    Console.WriteLine($"Gave 1 card to Player 2: {cardToGive2}");
                }
            }
            Console.WriteLine($"The deck now has {myDeck.Count} cards.");
            Console.WriteLine($"Player 1 hand with {player1.Count} cards: ");
            Console.WriteLine($"Player 2 hand with {player2.Count} cards: ");
            Console.WriteLine(player1);
            Console.WriteLine(player2);
        }
        /// <param name=player1">Player 1</param>
        /// <param name=player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            Console.WriteLine($"Highest card in hand player1 is {player1.Highest}");
            Console.WriteLine($"Lowest card in hand player1 is {player1.Lowest}");
            Console.WriteLine($"Highest card in hand player2 is {player2.Highest}");
            Console.WriteLine($"Lowest card in hand player2 is {player2.Lowest}");
            if (player1.Highest.CompareTo(player2.Highest) > 0)
                Console.WriteLine("Player1 win!");
            if (player1.Highest.CompareTo(player2.Highest) < 0)
                Console.WriteLine("Player2 win!");
            if (player1.Highest.CompareTo(player2.Highest) == 0)
                Console.WriteLine("Tie!");
        }
    }
}