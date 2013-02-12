using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerEngine.Tests
{
    public class AlwaysRaises : IManagePlayersStack
    {
        public int Stack
        {
            get { throw new NotImplementedException(); }
        }

        public void DeductChips(int chipAmount)
        {
        }

        public string Name
        {
            get { return "AlwaysRaises"; }
        }

        public void ReceiveCard(string card)
        {

        }

        public void PostBlind()
        {

        }

        public void SendStartingChips(int chips)
        {

        }

        public string GetAction()
        {
            return "BET";
        }

        public void OpponentsAction(string action)
        {

        }

        public void ReceiveChips(int amount)
        {

        }
    }
}
