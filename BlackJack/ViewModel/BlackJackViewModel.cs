using BlackJack.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.ViewModel
{
    public class BlackJackViewModel : ViewModelBase
    {
        List<Card> Deck;
        Player player;
        Player dealer;
        bool canDeal = false;

        #region Fields

        private bool isDealerTurn = false;
        private string playerCard1;
        private string playerCard2;
        private string playerCard3;
        private string playerCard4;
        private string playerCard5;
        private string playerCard6;
        private string playerCard7;
        private string playerCard8;
        private string playerCard9;
        private string playerCard10;
        private string playerCard11;

        private string dealerCard1;
        private string dealerCard2;
        private string dealerCard3;
        private string dealerCard4;
        private string dealerCard5;
        private string dealerCard6;
        private string dealerCard7;
        private string dealerCard8;
        private string dealerCard9;
        private string dealerCard10;
        private string dealerCard11;

        private int amountToWager;
        private int wallet;
        private int playerScore;
        private int dealerScore;
        private string winner;
        private int wagerAmount;

        #endregion

        #region Properties

        public int WagerAmount
        {
            get { return wagerAmount; }
            set
            {
                wagerAmount = value;
                RaisePropertyChanged("WagerAmount");
            }
        }

        public int PlayerScore
        {
            get { return playerScore; }
            set
            {
                playerScore = value;
                RaisePropertyChanged("PlayerScore");
            }
        }

        public int DealerScore
        {
            get { return dealerScore; }
            set
            {
                dealerScore = value;
                RaisePropertyChanged("DealerScore");
            }
        }

        public string Winner
        {
            get { return winner; }
            set
            {
                winner = value;
                RaisePropertyChanged("Winner");
            }
        }

        public int Wallet
        {
            get { return wallet; }
            set
            {
                wallet = value;
                RaisePropertyChanged("Wallet");
            }
        }

        public int AmountToWager
        {
            get { return amountToWager; }
            set
            {
                amountToWager = value;
            }
        }

        public bool IsDealerTurn
        {
            get { return isDealerTurn; }
            set
            {
                isDealerTurn = value;
                if (value == true)
                {
                    DealerTurn(dealer);
                }

            }
        }

        public string PlayerCard1
        {
            get { return playerCard1; }
            set
            {
                playerCard1 = value;
                RaisePropertyChanged("PlayerCard1");
            }
        }

        public string PlayerCard2
        {
            get { return playerCard2; }
            set
            {
                playerCard2 = value;
                RaisePropertyChanged("PlayerCard2");
            }
        }

        public string PlayerCard3
        {
            get { return playerCard3; }
            set
            {
                playerCard3 = value;
                RaisePropertyChanged("PlayerCard3");
            }
        }

        public string PlayerCard4
        {
            get { return playerCard4; }
            set
            {
                playerCard4 = value;
                RaisePropertyChanged("PlayerCard4");
            }
        }

        public string PlayerCard5
        {
            get { return playerCard5; }
            set
            {
                playerCard5 = value;
                RaisePropertyChanged("PlayerCard5");
            }
        }

        public string PlayerCard6
        {
            get { return playerCard6; }
            set
            {
                playerCard6 = value;
                RaisePropertyChanged("PlayerCard6");
            }
        }

        public string PlayerCard7
        {
            get { return playerCard7; }
            set
            {
                playerCard7 = value;
                RaisePropertyChanged("PlayerCard7");
            }
        }

        public string PlayerCard8
        {
            get { return playerCard8; }
            set
            {
                playerCard8 = value;
                RaisePropertyChanged("PlayerCard8");
            }
        }

        public string PlayerCard9
        {
            get { return playerCard9; }
            set
            {
                playerCard9 = value;
                RaisePropertyChanged("PlayerCard9");
            }
        }

        public string PlayerCard10
        {
            get { return playerCard10; }
            set
            {
                playerCard10 = value;
                RaisePropertyChanged("PlayerCard10");
            }
        }

        public string PlayerCard11
        {
            get { return playerCard11; }
            set
            {
                playerCard11 = value;
                RaisePropertyChanged("PlayerCard11");
            }
        }

        public string DealerCard1
        {
            get { return dealerCard1; }
            set
            {
                dealerCard1 = value;
                RaisePropertyChanged("DealerCard1");
            }
        }

        public string DealerCard2
        {
            get { return dealerCard2; }
            set
            {
                dealerCard2 = value;
                RaisePropertyChanged("DealerCard2");
            }
        }

        public string DealerCard3
        {
            get { return dealerCard3; }
            set
            {
                dealerCard3 = value;
                RaisePropertyChanged("DealerCard3");
            }
        }

        public string DealerCard4
        {
            get { return dealerCard4; }
            set
            {
                dealerCard4 = value;
                RaisePropertyChanged("DealerCard4");
            }
        }

        public string DealerCard5
        {
            get { return dealerCard5; }
            set
            {
                dealerCard5 = value;
                RaisePropertyChanged("DealerCard5");
            }
        }

        public string DealerCard6
        {
            get { return dealerCard6; }
            set
            {
                dealerCard6 = value;
                RaisePropertyChanged("DealerCard6");
            }
        }

        public string DealerCard7
        {
            get { return dealerCard7; }
            set
            {
                dealerCard7 = value;
                RaisePropertyChanged("DealerCard7");
            }
        }

        public string DealerCard8
        {
            get { return dealerCard8; }
            set
            {
                dealerCard8 = value;
                RaisePropertyChanged("DealerCard8");
            }
        }

        public string DealerCard9
        {
            get { return dealerCard9; }
            set
            {
                dealerCard9 = value;
                RaisePropertyChanged("DealerCard9");
            }
        }

        public string DealerCard10
        {
            get { return dealerCard10; }
            set
            {
                dealerCard10 = value;
                RaisePropertyChanged("DealerCard10");
            }
        }

        public string DealerCard11
        {
            get { return dealerCard11; }
            set
            {
                dealerCard11 = value;
                RaisePropertyChanged("DealerCard11");
            }
        }

        public RelayCommand DealCommand { get; private set; }
        public RelayCommand HitCommand { get; private set; }
        public RelayCommand StayCommand { get; private set; }
        public RelayCommand SplitCommand { get; private set; }
        public RelayCommand MakeWagerCommand { get; private set; }

        #endregion

        public BlackJackViewModel()
        {
            LoadCommands();
            player = new Player();
            dealer = new Player();
            dealer.PlayerNumber = 0;
            player.PlayerNumber = 1;
            Wallet = player.TotalMoney;
        }

        private void ShuffleDeck(List<Card> deck)
        {
            Random rand = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i+1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        private void CreateDeck()
        {
            Card card;
            string none = "none";

            Deck = new List<Card>();

            foreach (var suit in Enum.GetNames(typeof(EnumSuit)))
            {
                if (suit != none)
                {
                    for (int i = 1; i <= 13; i++ )
                    {
                        try
                        {
                            var suitToAdd = (EnumSuit)Enum.Parse(typeof(EnumSuit), suit);
                            int valueToAdd = i;
                            string cardNameToAdd = Enum.GetName(typeof(EnumCard), i);

                            //values for jack, queen, and king
                            if(i > 10)
                            {
                                valueToAdd = 10;
                            }
   
                            card = new Card(suitToAdd, valueToAdd, cardNameToAdd);
                            SetCardImage(card);
                            Deck.Add(card);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            ShuffleDeck(Deck);
        }

        private void SetCardImage(Card _card)
        {
            string fullCardNameToCompare = (_card.CardName + "_of_" + _card.Suit).ToLower();

            foreach (var cardImage in Enum.GetNames(typeof(CardImages)))
            {
                if(fullCardNameToCompare == cardImage)
                {
                    try
                    {
                        _card.CardImage = (CardImages)Enum.Parse(typeof(CardImages), cardImage);
                    }
                    catch (Exception)
                    {
                    }   
                }
            }
        }

        private void LoadCommands()
        {
            DealCommand = new RelayCommand(DealCards, CanDealCards);
            HitCommand = new RelayCommand(Hit, CanHit);
            StayCommand = new RelayCommand(Stay, CanStay);
            SplitCommand = new RelayCommand(SplitCards, CanSplitCards);
            MakeWagerCommand = new RelayCommand(MakeWager, CanMakeWager);
        }

        private void CommandsCanExecuteChange()
        {
            DealCommand.RaiseCanExecuteChanged();
            HitCommand.RaiseCanExecuteChanged();
            StayCommand.RaiseCanExecuteChanged();
            //SplitCommand.RaiseCanExecuteChanged();
            MakeWagerCommand.RaiseCanExecuteChanged();
        }

        private bool CanMakeWager()
        {
            return (player != null && player.Wager == 0 && player.TotalMoney > 0) ;
        }

        private void MakeWager()
        {
            ResetScoresResult();
            ResetCardImages();

            if (AmountToWager > player.TotalMoney)
            {
                player.Wager = player.TotalMoney;
                player.TotalMoney = 0;
            }
            else
            {
                if(AmountToWager == 0)
                {
                    AmountToWager = 5;
                }
                player.Wager = AmountToWager;
                player.TotalMoney -= player.Wager;
            }
            
            Wallet = player.TotalMoney;
            WagerAmount = player.Wager;
            canDeal = true;
            CommandsCanExecuteChange();
        }

        private bool CanSplitCards()
        {

            //There are 2 cards in the players hand and both of them are of the same type. jack for jack.
            //return (player != null && player.playersHand != null &&  player.playersHand.Count == 2 && player.playersHand.ElementAt(0).CardName == player.playersHand.ElementAt(1).CardName) ;
            return false;
        }

        private void SplitCards()
        {
            throw new NotImplementedException();
        }

        private bool CanStay()
        { 
            return (player != null && player.playersHand != null &&  player.playersHand.Count >= 2 && !didBust(player) && !IsDealerTurn) ;              
        }

        private void Stay()
        {
            if (player.PlayerNumber == 1)
            {
                if (player.Wager == 0)
                {
                    player.Wager = 5;
                    player.TotalMoney -= player.Wager;
                    AmountToWager = player.Wager;
                }
                CommandsCanExecuteChange();
                IsDealerTurn = true;
            }
        }

        private bool CanHit()
        {
            
            return (player != null && player.playersHand != null && player.playersHand.Count >= 2 && !didBust(player) && player.Score != 21 && !IsDealerTurn);
                        
        }

        private bool didBust(Player _player)
        {
            return _player.Score > 21;
        }

        private void Hit()
        {
            if (player.Wager == 0)
            {
                player.Wager = 5;
                player.TotalMoney -= player.Wager;
                Wallet = player.TotalMoney;
            }
            DealPlayerCard(player);
        }

        private bool CanDealCards()
        {
            return canDeal;
        }

        private void DealCards()
        {
            CreateDeck();
            IsDealerTurn = false;
            canDeal = false;

            player.playersHand = new List<Card>();
            dealer.playersHand = new List<Card>();

            DealPlayerCard(player);
            DealPlayerCard(dealer);
            DealPlayerCard(player);
            DealPlayerCard(dealer);

            CommandsCanExecuteChange();

        }

        private void ResetScoresResult()
        {
            player.Score = 0;
            dealer.Score = 0;
            PlayerScore = 0;
            DealerScore = 0;
            Winner = String.Empty;
        }

        private void ResetCardImages()
        {
            PlayerCard1 = null;
            PlayerCard2 = null;
            PlayerCard3 = null;
            PlayerCard4 = null;
            PlayerCard5 = null;
            PlayerCard6 = null;
            PlayerCard7 = null;
            PlayerCard8 = null;
            PlayerCard9 = null;
            PlayerCard10 = null;
            PlayerCard11 = null;

            DealerCard1 = null;
            DealerCard2 = null;
            DealerCard3 = null;
            DealerCard4 = null;
            DealerCard5 = null;
            DealerCard6 = null;
            DealerCard7 = null;
            DealerCard8 = null;
            DealerCard9 = null;
            DealerCard10 = null;
            DealerCard11 = null;
        }

        private void DealerTurn(Player dealer)
        {
            PlayerScore = player.Score;
            SetCardImageProperty(dealer);

            //dealer will be dealt unless player has blackjack
            if (!(player.Score == 21 && player.playersHand.Count == 2))
            {
                while (dealer.Score < 17 )
                {
                    DealPlayerCard(dealer);
                }
            }

            DealerScore = dealer.Score;
            SetWinner();
            CommandsCanExecuteChange();
        }

        private void SetWinner()
        {
            if (player.Score <= 21)
            {
                if (player.Score > dealer.Score || dealer.Score > 21)
                {
                    YouWin();
                }
                else if (player.Score == dealer.Score)
                {
                    if (player.playersHand.Count == 2 && dealer.playersHand.Count > 2 && player.Score == 21)
                    {
                        YouWin();
                    }
                    else if (player.playersHand.Count > 2 && dealer.playersHand.Count == 2 && dealer.Score == 21)
                    {
                        Winner = "You Lose!";
                    }
                    else
                    {
                        YouTied();
                    }
                    
                }
                else
                {
                    Winner = "You Lose!";
                }
            }
            else
            {
                Winner = "You Lose!";
            }
            Wallet = player.TotalMoney;
            player.Wager = 0;
            WagerAmount = 0;
        }

        private void YouTied()
        {
            Winner = "You Tied!";
            player.TotalMoney += player.Wager;
        }

        private void YouWin()
        {
            Winner = "You Win!";
            player.TotalMoney += player.Wager * 2;
        }

        private void DealPlayerCard(Player _player)
        {
            _player.playersHand.Add(Deck.First());
            Deck.Remove(Deck.First());
            SetPlayerScore(_player);

            if (_player.PlayerNumber == 1)
            {
                PlayerScore = _player.Score;
            }

            SetCardImageProperty(_player);
            if (didBust(_player) && _player.PlayerNumber == 1)
            {
                CommandsCanExecuteChange();
                IsDealerTurn = true;
            }
        }

        private void SetPlayerScore(Player _player)
        {
            int numberOfAces = 0;
            int totalValue = 0;
            int tempTotalValue = 0;

            foreach (var card in _player.playersHand)
            {
                if(card.Value == 1)
                {
                    numberOfAces++;
                }
                else
                {
                    totalValue += card.Value;
                }
            }
            if (numberOfAces != 0)
            {
                foreach (var value in GetAllAceValues(numberOfAces))
                {
                    if (totalValue + value <= 21)
                    {
                        tempTotalValue = totalValue + value;
                    }
                }

                if (tempTotalValue != 0)
                {
                    _player.Score = tempTotalValue;
                }
                else
                {
                    _player.Score = totalValue + numberOfAces;
                }
                
            }
            else
            {
                _player.Score = totalValue;
            }
        }

        private List<int> GetAllAceValues(int numberOfAces)
        {
            List<int> acesValue = new List<int>();

            for (int i = 0; i < (numberOfAces + 1) * 10; i += 10)
            {
                acesValue.Add(numberOfAces + i);
            }

            return acesValue;
        }

        private void SetCardImageProperty(Player _player)
        {
            int cardNumberToSet = _player.playersHand.Count;

            if (_player.PlayerNumber == 1)
            {
                switch (cardNumberToSet)
                {
                    case 1:
                        PlayerCard1 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 2:
                        PlayerCard2 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 3:
                        PlayerCard3 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 4:
                        PlayerCard4 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 5:
                        PlayerCard5 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 6:
                        PlayerCard6 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 7:
                        PlayerCard7 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (cardNumberToSet)
                {
                    case 1:
                        DealerCard1 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 2:
                        if (!IsDealerTurn)
                        {
                            DealerCard2 = "face_down.png";
                            break;
                        }
                        DealerCard2 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 3:
                        DealerCard3 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 4:
                        DealerCard4 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 5:
                        DealerCard5 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 6:
                        DealerCard6 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    case 7:
                        DealerCard7 = GetCardImageName(_player, cardNumberToSet);
                        break;
                    default:
                        break;
                }
            }

        }

        private static string GetCardImageName(Player _player, int cardNumberToSet)
        {
            return _player.playersHand[cardNumberToSet - 1].CardImage.ToString() + ".png";
        }
    }
}
