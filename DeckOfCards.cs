using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1 //klar
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);
        public PlayingCard this[int enstring] => cards[enstring];
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            string nonstring = "";
            for (int i = 0; i < cards.Count; i++)
            {
                nonstring += cards[i].ToString() + '\t';
                if ((i + 1) % 13 == 0)
                    nonstring += '\n';
            }
            return nonstring;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            Random slump = new Random();
            int pc = cards.Count;

            for (int i = 0; i < pc; i++)
            {
                int randomIndex = slump.Next(i, pc);
                PlayingCard temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }
        }

        public void Sort()
        {
            List<PlayingCard> cardSort = new List<PlayingCard>();
            foreach (PlayingCardValue value in Enum.GetValues(typeof(PlayingCardValue)))
            {
                foreach (PlayingCardColor color in Enum.GetValues(typeof(PlayingCardColor)))
                {
                    var cardMatch = cards.Where(card => card.Value == value && card.Color == color);
                    cardSort.AddRange(cardMatch);
                }
            }
            cards = cardSort;
        }
        #endregion

        #region Clears the cards
        public void Clear()
        {
            cards.Clear();
        }

        public void CreateFreshDeck()
        {
            cards = new List<PlayingCard>(MaxNrOfCards);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    cards.Add(new PlayingCard
                    {
                        Color = (PlayingCardColor)i,
                        Value = (PlayingCardValue)j
                    });
                }
            }
        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            if (cards.Count > 0)
            {
                PlayingCard topCard = cards[0];
                cards.RemoveAt(0);
                return topCard;
            }
            else
            {
                return null;

            }

        }
        #endregion
    }
}