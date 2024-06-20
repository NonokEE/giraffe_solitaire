using System;
using UnityEngine;

namespace PlayingCards
{
    //~~ Enums ~~//
    public enum cardPattern
    {
        NONE, SPADE, DIA, HEART, CLUB
    }

    public enum cardColor
    {
        BLACK, RED
    }

    public enum cardStatus
    {
        IDLE, HOLDING, STICK
    }

    //~~ Interfaces ~~//
    public interface ICardControllerStrategy
    {
        public cardStatus Status { get; }
        public cardPattern Pattern { get; }
        public cardColor Color { get; }
        public int Number { get; }
        public bool IsOpened { get; }
        public Deck Deck { get; set; }

        public void SetCard(cardPattern pattern, int number);
        public void SetCard(cardPattern pattern, int number, bool isOpened);
        public void SetOpened(bool isOpened);
    }

    public interface ICardSpriteStrategy
    {
        public CardController Controller{ get; set; }

        public Sprite FrontSprite { get; }
        public Sprite BackSprite { get; set; }

        public void FlipCallback(bool value);
    }

    public interface ICardPlayStrategy
    {
        public CardController Controller{ get; set; }

    }
}