using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace BlackJack.Model
{
    public class Player : ObservableObject
    {
        public List<Card> playersHand;
        public List<string> playersCardImages;

        public int Score { get; set; }
        public int PlayerNumber { get; set; }
        public int Wager { get; set; }

        private int totalMoney = 100;

        public int TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }
    }
}
