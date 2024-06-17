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
    public interface ICardSpriteStrategy
    {
        public CardController Controller{ get; set;}
    }

    public interface ICardPlayStrategy
    {
        public CardController Controller{ get; set;}

    }
}