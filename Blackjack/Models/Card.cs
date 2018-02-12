using System.Collections.Generic;
using System;
namespace Blackjack.Models
{
    public class Card
    {
        private string _suit; //Diamond, Heart, Spades, Clubs
        private int _type; //1-13 1(Ace) 11(Jack) 12(Queen) 13(King)
        private static List<Card> _deck = new List<Card>{};

        public Card(int suitIn, int typeIn)
        {
            if(suitIn == 1)
            {
                _suit = "diamonds";
            } else if(suitIn == 2)
            {
                _suit = "hearts";
            } else if(suitIn == 3)
            {
                _suit = "spades";
            } else if(suitIn == 4)
            {
                _suit = "clubs";
            } else
            {
                Console.WriteLine("Invalid suitIn");
            }
            _type = typeIn;
        }
        public static void CreateDecks(int numberOfDecks)
        {
            for(var k = 1; k <= numberOfDecks; k ++)
            {
                for(var i = 1; i <= 4; i ++)
                {
                    for(var j = 1; j <= 13; j ++){
                        Card newCard = new Card(i, j);
                        newCard.PushToList();
                    }
                }
            }
        }
        public static List<Card> GetDeck()
        {
            return _deck;
        }

        public static void ClearDeck()
        {
            _deck.Clear();

        }
        public void PushToList()
        {
            _deck.Add(this);
        }
        public string printCard()
        {
            return _type + " of " + _suit;
        }
        public static void shuffleDeck()
        {
            shuffleTypeOne();
            randomShuffle();
        }
        public static void shuffleTypeOne()
        {
            List<Card> halfDeckOne = new List<Card>{};
            List<Card> halfDeckTwo = new List<Card>{};
            int splitDeckLength = _deck.Count/2;
            for(var i = 0; i < splitDeckLength; i ++)
            {
                halfDeckOne.Add(_deck[i]);
                halfDeckTwo.Add(_deck[i]);
            }
            Card.ClearDeck();
            for(var i = 0; i < splitDeckLength; i ++)
            {
                _deck.Add(halfDeckOne[i]);
                _deck.Add(halfDeckTwo[i]);
            }
        }
        public static void randomShuffle()
        {
            Random r = new Random();
            Card currentIndexValue;
            for(var i = 0; i < _deck.Count; i ++)
            {
                int randomPosition = r.Next(0, _deck.Count);
                currentIndexValue = _deck[i];
                _deck[i] = _deck[randomPosition];
                _deck[randomPosition] = currentIndexValue;
            }
        }
    }
}
