﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        protected float _enemyDmg;
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



    }
}
