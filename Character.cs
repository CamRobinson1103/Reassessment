using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        protected float _damage;
        private float _magic;
        private int _money;
        private Item[] _inventory;

        public Character()
        {
            _health = 10;
            _damage = 0;
            _magic = 0;
        }

        public Character(float healthVal, float magicVal, float damageVal)
        {
            _health = healthVal;
            _magic = magicVal;
            _damage = damageVal;
        }

        public bool Buy(Item item, int inventoryIndex)
        {
            if(_money >= item.price)
            {
                _money -= item.price;
                _inventory[inventoryIndex] = item;
                return true;
            }
            return false;
        }

        public int GetMoney()
        {
            return _money;
        }
    }
}
