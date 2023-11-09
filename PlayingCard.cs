using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1 //klar
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

        public string ShortDescription => GetShortDescription();

        #region IComparable Implementation
        //Need only to compare value in the project
        public int CompareTo(PlayingCard kort)
        {
            return Value.CompareTo(kort.Value);
        }
		#endregion

        #region ToString() related
		private string GetShortDescription()
        {
			char[] tecken = new char[] { '\u2663', '\u2666', '\u2665', '\u2660' };
            return tecken[(int)Color] + Value.ToString();

        }

		public override string ToString() => ShortDescription;
        #endregion
    }
}
