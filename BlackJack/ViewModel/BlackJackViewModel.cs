using BlackJack.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
        private List<string> playerHand;
        private List<string> dealerHand;
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

        public List<string> PlayerHand
        {
            get { return playerHand; }
            set
            {
                playerHand = value;
                RaisePropertyChanged(nameof(PlayerHand));
            }
        }
        public List<string> DealerHand
        {
            get { return dealerHand; }
            set
            {
                dealerHand = value;
                RaisePropertyChanged(nameof(DealerHand));
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
            player.playersCardImages = new List<string>();
            dealer.playersCardImages = new List<string>();

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
            PlayerHand = null;
            DealerHand = null;
        }

        private void DealerTurn(Player dealer)
        {
            PlayerScore = player.Score;
            DealerHand[1] = dealer.playersHand[1].CardImage.ToString() + ".png";
            RaisePropertyChanged(nameof(DealerHand));

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
            _player.playersCardImages.Add(Deck.First().CardImage.ToString() + ".png");
            Deck.Remove(Deck.First());
            SetPlayerScore(_player);

            if (_player.PlayerNumber == 1)
            {
                PlayerHand = _player.playersCardImages;
                PlayerScore = _player.Score;
            } else
            {
                
                if (_player.playersHand.Count == 2)
                {
                    DealerHand[1] = "face_down.png";
                } 
                DealerHand = _player.playersCardImages;
            }

            if (didBust(_player) && _player.PlayerNumber == 1)
            {
                IsDealerTurn = true;
            }
            CommandsCanExecuteChange();
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
    }
}
