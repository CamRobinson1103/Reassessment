using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _money;
        private Item[] _kitchenInventory;

        public Shop(Item[] kitchenInventory)
        {
            this._kitchenInventory = _kitchenInventory;
        }

        public bool Sell(Character player, int itemIndex, int playerIndex)
        {
            Item itemToBuy = _kitchenInventory[itemIndex];
            if(player.Buy(itemToBuy, playerIndex))
            {
                _money += itemToBuy.price;
                return true;
            }
            return false;
        }
    }
}
