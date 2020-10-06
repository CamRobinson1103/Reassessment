using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _money;
        private Item[] _inventory;

        public Shop(Item[] items)
        {
            _money = 10;
            _inventory = items;
        }

        public bool Sell(Character player, int itemIndex, int playerIndex)
        {
            Item itemToBuy = _inventory[itemIndex];
            if(player.Buy(itemToBuy, playerIndex))
            {
                _money += itemToBuy.price;
                return true;
            }
            return false;
        }
    }
}
