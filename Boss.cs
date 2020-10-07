using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Boss : Enemy
    {
        private string _name;

        public Boss() : base()
        {
            _enemyHlth = 30;
            _enemyDmg = 6;
            _enemyMana = 20;
            _name = "Codzilla";
        }
    }
}
