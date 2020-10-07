using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        public float _health;
        public float _damage;
        private float _magic;
        private int _money;
        private Item[] _inventory;
        private Item _currentWeapon;

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

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public void PrintStats()
        {
            Console.WriteLine("Health " + _health);
            Console.WriteLine("Damage " + _damage);
        }

        public virtual float Attack(Character enemy)
        {
            float damageTaken = enemy.TakeDamage(_damage);
            return damageTaken;
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        internal float Attack(Enemy demonkid)
        {
            throw new NotImplementedException();
        }
        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }
    }
}
