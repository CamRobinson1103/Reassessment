using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        public float _enemyDmg;
        public float _enemyHlth;
        private float _enemyMana;


        public Enemy()
        {
            _enemyHlth = 5;
            _enemyDmg = 3;
            _enemyMana = 0;
        }

        public bool GetIsAlive()
        {
            return _enemyHlth > 0;
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: Devil Kid");
            Console.WriteLine("Health: " + _enemyHlth);
            Console.WriteLine("Damage: " + _enemyDmg);
        }

     

    }
}
