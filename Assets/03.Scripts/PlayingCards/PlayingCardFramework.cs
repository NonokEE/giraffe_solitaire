using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayingCards
{
    //~~ Enums ~~//
    public enum CardPattern
    {
        NONE, SPADE, DIA, HEART, CLUB
    }

    public enum CardColor
    {
        BLACK, RED
    }

    public enum CardStatus
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
        public List<AbsCardControllerStrategy> Cards { get; }
        public string BackSpritePath { get; set; }

        public int Remains { get; }

        public void Initialize();
        public void Initialize(int randomSeed);
        public AbsCardControllerStrategy Draw();
    }

    public abstract class AbsDeck : MonoBehaviour, IDeck
    {
        public abstract AbsCardControllerStrategy CardPrefab { get; set; }
        public abstract List<AbsCardControllerStrategy> Cards { get; }
        public abstract string BackSpritePath { get; set; }
        public abstract int Remains { get; }

        public abstract void Initialize();
        public abstract void Initialize(int randomSeed);
        public abstract AbsCardControllerStrategy Draw();
    }

    //Cards
    public interface ICardControllerStrategy
    {
        public CardStatus Status { get; }
        public CardPattern Pattern { get; }
        public CardColor Color { get; }
        public int Number { get; }
        public bool IsOpened { get; }
        public IDeck Deck { get; set; }

        public void Initiate();
        public void SetCard(CardPattern pattern, int number);
        public void SetCard(CardPattern pattern, int number, bool isOpened);
        public void SetOpened(bool isOpened);
    }

    public abstract class AbsCardControllerStrategy : MonoBehaviour, ICardControllerStrategy
    {
        public abstract CardStatus Status { get; }
        public abstract CardPattern Pattern { get; }
        public abstract CardColor Color { get; }
        public abstract int Number { get; }
        public abstract bool IsOpened { get; }
        public abstract IDeck Deck { get; set; }

        public abstract void Initiate();
        public abstract void SetCard(CardPattern pattern, int number);
        public abstract void SetCard(CardPattern pattern, int number, bool isOpened);
        public abstract void SetOpened(bool isOpened);
    }

    public interface ICardSpriteStrategy
    {
        public AbsCardControllerStrategy Controller{ get; set; }

        public Sprite FrontSprite { get; }
        public Sprite BackSprite { get; set; }

        public void Initiate();
        public void FlipCallback(bool value);
    }

    public abstract class AbsCardSpriteStrategy : MonoBehaviour, ICardSpriteStrategy
    {
        public abstract AbsCardControllerStrategy Controller { get; set; }
        public abstract Sprite FrontSprite { get; }
        public abstract Sprite BackSprite { get; set; }

        public abstract void Initiate();
        public abstract void FlipCallback(bool value);
    }

    public interface ICardPlayStrategy
    {
        public CardController Controller{ get; set; }

    }

    public abstract class AbscardPlayStrategy : MonoBehaviour, ICardPlayStrategy
    {
        public abstract CardController Controller { get; set; }
    }

}