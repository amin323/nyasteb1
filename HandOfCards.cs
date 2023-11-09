using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1 //klar
{
    class HandOfCards : DeckOfCards, IHandOfCards

    {
        private List<PlayingCard> kortihanden = new List<PlayingCard>();

        public override string ToString()
        {
            return string.Join(" ", kortihanden.Select(card => card.ToString()));
        }
        public void Add(PlayingCard card)
        {
            kortihanden.Add(card);
        }
        public void Clear()
        {
            kortihanden.Clear();     //CLEARS CARDS IN HAND
        }
        public int Count => kortihanden.Count;

        public PlayingCard Highest => kortihanden.Max();

        public PlayingCard Lowest => kortihanden.Min();
    }
}
