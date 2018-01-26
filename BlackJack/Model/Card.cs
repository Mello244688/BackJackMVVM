using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BlackJack.Model
{
    public class Card
    {
        public EnumSuit Suit { get; set; }
        public int Value { get; set; }
        public string CardName { get; set; }
        public CardImages CardImage { get; set; }

        public Card()
        {

        }

        public Card(EnumSuit _suit, int _value, string _name)
        {
            this.Suit = _suit;
            this.Value = _value;
            this.CardName = _name;
        }
    }

    public enum EnumSuit
    {
        none,
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum EnumCard
    {
        none,
        Ace,
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
    }

    public enum CardImages
    {
        none = 0,
        ace_of_clubs = 1,
        ace_of_diamonds = 2,
        ace_of_hearts = 3,
        ace_of_spades = 4,
        two_of_clubs = 5,
        two_of_diamonds = 6,
        two_of_hearts = 7,
        two_of_spades = 8,
        three_of_clubs = 9,
        three_of_diamonds = 10,
        three_of_hearts = 11,
        three_of_spades = 12,
        four_of_clubs = 13,
        four_of_diamonds = 14,
        four_of_hearts = 15,
        four_of_spades = 16,
        five_of_clubs = 17,
        five_of_diamonds = 18,
        five_of_hearts = 19,
        five_of_spades = 20,
        six_of_clubs = 21,
        six_of_diamonds = 22,
        six_of_hearts = 23,
        six_of_spades = 24,
        seven_of_clubs = 25,
        seven_of_diamonds = 26,
        seven_of_hearts = 27,
        seven_of_spades = 28,
        eight_of_clubs = 29,
        eight_of_diamonds = 30,
        eight_of_hearts = 31,
        eight_of_spades = 32,
        nine_of_clubs = 33,
        nine_of_diamonds = 34,
        nine_of_hearts = 35,
        nine_of_spades = 36,
        ten_of_clubs = 37,
        ten_of_diamonds = 38,
        ten_of_hearts = 39,
        ten_of_spades = 40,
        jack_of_clubs = 41,
        jack_of_diamonds = 42,
        jack_of_hearts = 43,
        jack_of_spades = 44,
        queen_of_clubs = 45,
        queen_of_diamonds = 46,
        queen_of_hearts = 47,
        queen_of_spades = 48,
        king_of_clubs = 49,
        king_of_diamonds = 50,
        king_of_hearts = 51,
        king_of_spades = 52,
    }
}
