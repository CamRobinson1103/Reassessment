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
    }
}
