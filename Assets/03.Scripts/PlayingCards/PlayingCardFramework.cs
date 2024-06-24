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
    //Deck
    public interface IDeck
    {
        public ICardControllerStrategy CardController { get; set; }
        public string BackSpritePath { get; set; }

        public int Remains { get; }

        public void Initialize(bool doShuffle);
        public ICardControllerStrategy Draw();
    }

    //Cards
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

    public abstract class AbsCardControllerStrategy : MonoBehaviour, ICardControllerStrategy
    {
        public abstract cardStatus Status { get; }
        public abstract cardPattern Pattern { get; }
        public abstract cardColor Color { get; }
        public abstract int Number { get; }
        public abstract bool IsOpened { get; }
        public abstract Deck Deck { get; set; }

        public abstract void SetCard(cardPattern pattern, int number);
        public abstract void SetCard(cardPattern pattern, int number, bool isOpened);
        public abstract void SetOpened(bool isOpened);
    }

    public interface ICardSpriteStrategy
    {
        public ICardControllerStrategy Controller{ get; set; }

        public Sprite FrontSprite { get; }
        public Sprite BackSprite { get; set; }

        public void FlipCallback(bool value);
    }

    public abstract class AbsCardSpriteStrategy : MonoBehaviour, ICardSpriteStrategy
    {
        public abstract ICardControllerStrategy Controller { get; set; }
        public abstract Sprite FrontSprite { get; }
        public abstract Sprite BackSprite { get; set; }

        public abstract void FlipCallback(bool value);
    }

    public interface ICardPlayStrategy
    {
        public CardController Controller{ get; set; }

    }
}