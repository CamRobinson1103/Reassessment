using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Ally : Character
    {
        public float _magic;
        private string _name;
        public Ally() : base()
        {
            _magic = 100;
            _name = "MaoMao";
        }

        public Ally(float healthVal, float magicVal, float damageVal, int inventorySize) : base(healthVal, magicVal, damageVal,inventorySize)
        {
            _magic = magicVal;
        }

        public override float Attack(Character enemy)
        {
            float damageTaken = 0.0f;
            if(_magic >= 4)
            {
                float totalDamage = _damage + _magic * .25f;
                _magic = _magic - (_magic * .25f);
                damageTaken = enemy.TakeDamage(totalDamage);
                return damageTaken;
            }
            damageTaken = base.Attack(enemy);
            return damageTaken;
        }
    }
}
