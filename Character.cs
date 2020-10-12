using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Character
    {
        public float _health;
        public float _damage;
        public float _magic;
        private int _money;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item[] _kitchenInventory;


        public Character() : base()
        {
            _health = 10;
            _damage = 1;
            _magic = 0;
            _inventory = new Item[11];
            
        }

        public Character(float healthVal, float magicVal, float damageVal, int inventorySize)
        {
            _health = healthVal;
            _magic = magicVal;
            _damage = damageVal;
            _inventory = new Item[inventorySize];
        }

        public bool Buy(Item item, int inventoryIndex)
        {
            if(_money >= item.price)
            {
                _money -= item.price;
                _kitchenInventory[inventoryIndex] = item;
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

        
        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
        }

        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory?.Length)
            {
                return true;
            }
            return false;
        }

        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_magic);
        }

        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            _damage = damage;
            _health = health;
            return true;
      
        }



        
    }
}
