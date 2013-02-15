namespace PokerEngine
{
    public class HandCreator : ICreateHands
    {
        public IHand CreateHand(IManagePlayersStack p1, IManagePlayersStack p2)
        {
            return new Hand(p1, p2, new Deck());
        }
    }
}