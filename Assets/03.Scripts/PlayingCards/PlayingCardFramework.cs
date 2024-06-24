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
        ///<remarks>덱을 이루는 카드에 사용할 controller의 Prefab </remarks>
        public AbsCardControllerStrategy CardPrefab { get; set; }

        ///<remarks>덱을 이루게 되는 실제 카드 오브젝트</remarks>
        public AbsCardControllerStrategy[] Cards { get; }
        public string BackSpritePath { get; set; }

        public int Remains { get; }

        public void Initialize(bool doShuffle);
        public AbsCardControllerStrategy Draw();
    }

    public abstract class AbsDeck : MonoBehaviour, IDeck
    {
        public abstract AbsCardControllerStrategy CardPrefab { get; set; }
        public abstract AbsCardControllerStrategy[] Cards { get; }
        public abstract string BackSpritePath { get; set; }
        public abstract int Remains { get; }

        public abstract AbsCardControllerStrategy Draw();
        public abstract void Initialize(bool doShuffle);
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
        public AbsCardControllerStrategy Controller{ get; set; }

        public Sprite FrontSprite { get; }
        public Sprite BackSprite { get; set; }

        public void FlipCallback(bool value);
    }

    public abstract class AbsCardSpriteStrategy : MonoBehaviour, ICardSpriteStrategy
    {
        public abstract AbsCardControllerStrategy Controller { get; set; }
        public abstract Sprite FrontSprite { get; }
        public abstract Sprite BackSprite { get; set; }

        public abstract void FlipCallback(bool value);
    }

    public interface ICardPlayStrategy
    {
        public CardController Controller{ get; set; }

    }

    public abstract class abscardPlayStrategy : MonoBehaviour, ICardPlayStrategy
    {
        public abstract CardController Controller { get; set; }
    }

}