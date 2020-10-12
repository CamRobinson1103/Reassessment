using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        public float _enemyDmg;
        public float _enemyHlth;
        public float _enemyMana;
        private Item[] _demonInventory;


        public Enemy()
        {
            _enemyHlth = 5;
            _enemyDmg = 3;
            _enemyMana = 0;
            _demonInventory = new Item[3];
        }

        public Enemy(float healthVal, float damageVal,int inventorySize)
        {
            _enemyHlth = healthVal;
            _enemyDmg = damageVal;
            _demonInventory = new Item[inventorySize];
        }

        public Item[] GetItem()
        {
            return _demonInventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _demonInventory[index] = item;
        }

        public bool GetIsAlive()
        {
            return _enemyHlth > 0;
        }

        public virtual float TakeDamage(float damageVal)
        {
            _enemyHlth -= damageVal;
            if (_enemyHlth < 0)
            {
                _enemyHlth = 0;
            }
            return damageVal;
        }

        public virtual float Attack(Enemy _player)
        {
            float damageTaken = _player.TakeDamage(_enemyDmg);
            return damageTaken;
        }


        public void PrintStats()
        {
            Console.WriteLine("Name: Demon Kid");
            Console.WriteLine("Health: " + _enemyHlth);
            Console.WriteLine("Damage: " + _enemyDmg);
        }

       
    }
}
