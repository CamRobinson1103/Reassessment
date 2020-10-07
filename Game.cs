using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Item
    {
        public string name;
        public int dmgBoost;
        public int price;
    }
    class Game
    {
        private bool _gameOver = false;
        private Character _player;
        private Character _ally;
        private Enemy _codzilla;
        private Enemy _demonkid;
        private Shop _shop;
        private Item _phillyCheesesteak;
        private Item _popTart;
        private Item _cupNoodles;
        private Item _plasticBaseballBat;
        private Item _twinNerfPistols;
        private Item _sword;
        private Item _twinPistols;
        private Item _soccerBall;
        private Item _spikeBall;
        private Item[] _kitchenInventory;

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        public void InitializeItem()
        {
            _phillyCheesesteak.name = "Philly Cheesesteak";
            _phillyCheesesteak.price = 3;
            _popTart.name = "Pop Tart";
            _popTart.price = 1;
            _cupNoodles.name = "Cup Noodles";
            _cupNoodles.price = 3;


            _plasticBaseballBat.name = "Plastic Baseball Bat";
            _plasticBaseballBat.dmgBoost = 0;
            _twinNerfPistols.name = "Twin Nerf Pistols";
            _twinNerfPistols.dmgBoost = 0;
            _sword.name = "Sword";
            _sword.dmgBoost = 10;
            _twinPistols.name = "Twin Pistols";
            _twinPistols.dmgBoost = 10;
            _soccerBall.name = "Soccer Ball";
            _soccerBall.dmgBoost = 0;
            _spikeBall.name = "Spike Ball";
            _spikeBall.dmgBoost = 10;


        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Prints description to console
            Console.WriteLine(query);
            //Prints options
            Console.WriteLine("[1]" + option1);
            Console.WriteLine("[2]" + option2);
            Console.WriteLine("[3]" + option2);
            Console.WriteLine("> ");

            input = ' ';
            //Loops untin the correct input is given
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("invalid Input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Prints description to console
            Console.WriteLine(query);
            //Prints options
            Console.WriteLine("[1]" + option1);
            Console.WriteLine("[2]" + option2);
            Console.WriteLine("> ");

            input = ' ';
            //Loops untin the correct input is given
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("invalid Input");
                }
            }
        }


        public Character CharacterName()
        {
            Console.WriteLine("You just woke up from a good night's sleep. You head to the kitchen from some breakfast. When you get to the kitchen you feel like something's off.");
            ClearScreen();
            Console.WriteLine("You don't hear your usually loud roommates. You say a loud 'hello'... but no response.");
            ClearScreen();
            Console.WriteLine("You walk oout on your balcony to get some fresh air" + "when you are then met with an orange/brown looking sky. You check your surroundong to see other's reaction,but you see nobody.");
            ClearScreen();
            Console.WriteLine("You start to panic for a bit until you caught your breath and calmed down a bit. You start off with the basis. What is your name first of all?");
            Console.WriteLine("Type youe name.");
            Console.WriteLine("> ");
            string name = Console.ReadLine();
            Character player = new Character(10, 0, 0);
            return player;
        }

        public void PrintInventory(Item[] _inventory)
        {
            for(int q = 0; q < _inventory.Length; q++)
            {
                Console.WriteLine((q + 1) + ". " + _inventory[q].name + _inventory[q].price);
            }
        }

        public void KitchenShop()
        {
            ClearScreen();
            Console.WriteLine("You want to check out outside, but you are still hungry. You look throughout the kitchen for something to eat.");
            PrintInventory(_kitchenInvetory);

            char input = Console.ReadKey().KeyChar;

            int itemIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }

                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }

                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }

                default:
                    {
                        return;
                    }
            }

            Console.WriteLine("Place it in a slot in your bag.");
            PrintInventory(_player.GetInventory());

            int playerIndex = -1;
            switch (input)
            {
                case '1':
                    playerIndex = 0;
                    break;

                case '2':
                    playerIndex = 1;
                    break;

                case '3':
                    playerIndex = 2;
                    break;

                default:
                    {
                        return;
                    }
            }
            _shop.Sell(_player, itemIndex, playerIndex);
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void SelectingWeapon()
        {
            ClearScreen();
            char input;
            GetInput(out input, "Plastic baseball bat", "Twin Nerf pistols", "Soccor ball",
            "You walked outside to check on everything, when suddenly you see short demons with axes charging at you! You see a plastic baseball bat " +
                "and a set of twin Nerf pistols to hopefully defend you. Whuch do you choose?");
            if (input == '1')
            {
                Console.WriteLine("You picked up the plastic baseball bat for defense.");
                _player.AddItemToInventory(_plasticBaseballBat,3);
                _player.AddItemToInventory(_sword, 5);
            }
            else if (input == '2')
            {
                Console.WriteLine("You picked up the Nerf guns for defense.");
                _player.AddItemToInventory(_twinNerfPistols,4);
                _player.AddItemToInventory(_twinPistols, 6);
            }
            else if (input == '3')
            {
                Console.WriteLine("You picked up the soccer ball for defence");
                _player.AddItemToInventory(_soccerBall, 8);
                _player.AddItemToInventory(_spikeBall, 9);
               
            }
        }

        public void EnemyBattle()
        {
            ClearScreen();
            while (_player.GetIsAlive() && _demonkid.GetIsAlive())
            {
                _player.PrintStats();
                _demonkid.PrintStats();

                char input;
                GetInput(out input, "Attack", "Defend", "Magic", "What will you do");

                if (input == '1')
                {
                    float damageTaken = _player.Attack(_demonkid);
                    Console.WriteLine("You attack the Demon Kid! You dealt " + (_player._damage - _demonkid._enemyHlth) +" damage!");
                }

                else if (input == '2')
                {
                    Console.WriteLine("You use your weapon to try to defend the upcoming attack!");
                }
                else if (input == '3')
                {
                    Console.WriteLine("You try to use a magic spell... But you don't know any magic!");
                }
                else
                {
                    Console.WriteLine("The Demon Kids attacks! It dealt " + (_demonkid._enemyDmg - _player._health));

                }

            }

           

        }

        public void ChangeWeapon(Character player)
        {
            ClearScreen();
            if (_demonkid.GetIsAlive())
            {
                Console.WriteLine("You cannot beat the demon kid with your weapon! He goes in for the final attack! When suddenly...your weapon transforms!");
                Item[] inventory = player.GetInventory();
                char input = ' ';
                for (int p = 0; p < inventory.Length; p++)
                {
                    Console.WriteLine((p + 1) + ". " + inventory[p].name + "\n damage: " + inventory[p].dmgBoost);
                }
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        {
                            _player.EquipItem(3);
                            Console.WriteLine("You obtained the " + inventory[5].name);
                            Console.WriteLine("Base damaged increaded by " + inventory[5].dmgBoost);
                            break;
                        }

                    case '2':
                        {
                            _player.EquipItem(4);
                            Console.WriteLine("You obtained the " + inventory[6].name);
                            Console.WriteLine("Base damage incresed by " + inventory[6].dmgBoost);
                            break;
                        }

                    case '3':
                        {
                            _player.EquipItem(8);
                            Console.WriteLine("Base damage incresed by " + inventory[9].dmgBoost);
                            break;

                        }
                }
            }
        }

        public void ContinueBattle()
        {
            ClearScreen();
            while (_player.GetIsAlive() && _demonkid.GetIsAlive())
            {
                _player.PrintStats();
                _demonkid.PrintStats();

                char input;
                GetInput(out input, "Attack", "Defend", "Magic", "What will you do");

                if (input == '1')
                {
                    float damageTaken = _player.Attack(_demonkid);
                    Console.WriteLine("You attack the Demon Kid! You dealt " + (_player._damage - _demonkid._enemyHlth) + " damage!");
                }

                else if (input == '2')
                {
                    Console.WriteLine("You use your weapon to try to defend the upcoming attack!");
                }
                else if (input == '3')
                {
                    Console.WriteLine("You try to use a magic spell... But you don't know any magic!");
                }
                else
                {
                    Console.WriteLine("The Demon Kids attacks! It dealt " + (_demonkid._enemyDmg - _player._health));

                }
            }

            if(_player.GetIsAlive())
            {
                Console.WriteLine("You defeated the demon kid! You cotinue on to find answers at to what is happening.");
            }
            else if (_demonkid.GetIsAlive())
            {
                Console.WriteLine("You lost to the demon kid!!");
                _gameOver = true;

            }
        }


        public void GettingAnAlly()
        {
            ClearScreen();
            Console.WriteLine("Along you way for answers, you find another demon kid. You go in for the attack but this one seems different. He's retaliating.");
            ClearScreen();
            Console.WriteLine("He talks!");
            ClearScreen();
            Console.WriteLine("Please don attack me mista, I ain't won of them mean monstas! In fakt, I wonna join ya, mao!");
            char input;
            GetInput(out input, "Yes", "No", "Do you accept his offer ? ");

            if(input == '1')
            {
                Console.WriteLine("We'll make a great team, aku!");
                Console.WriteLine("Demon Kid MaoMao joins your party!");
            }
            else if (input == '2')
            {
                Console.WriteLine("Okie pokie, I understand, mao!");
                Console.WriteLine("The demon kid ran away...");
                _gameOver = true;
            }
        }


        public void BossBattle()
        {
            ClearScreen();
            Console.WriteLine("You and MaoMao are walking to the tall buiding in the horizon. Suddenly they are jumped by a huge monster!");
            while(_player.GetIsAlive() && _codzilla.GetIsAlive() && _ally.GetIsAlive())
            {
                _player.PrintStats();
                _ally.PrintStats();
                _codzilla.PrintStats();

                char input = ' ';
                GetInput(out input, "Attack", "Defend", "Magic", "What will you do");
                if (input == '1')
                {
                    float damageTaken = _player.Attack(_codzilla);
                    Console.WriteLine("You attack Codzilla! You dealt " + (_player._damage - _codzilla._enemyHlth) + " damage!");
                    damageTaken = _ally.Attack(_codzilla);
                    Console.WriteLine("MaoMao attacks Codzilla! He dealt "  + (_ally._damage - _codzilla._enemyHlth) + " damage!");
                }
                else if (input == '2')
                {
                    Console.WriteLine("You use your weapon to defend the upcomig attack!");
                    Console.WriteLine("MaoMao uses his weapon to defend the upcoming attack!");
                }
                else if (input == '3')
                {
                    float damageTaken = _ally.Attack(_codzilla);
                    Console.WriteLine("You can't use magic.. ButMaoMao can! He casts a low level fire spell!");
                    Console.WriteLine("MaoMao: FAR!! He dealt " + (_ally._magic - _codzilla._enemyHlth) + " damage!");  
                }
            }
            Console.WriteLine("The Codzilla attacks! It dealt " + (_codzilla._enemyDmg - _player._health) + " damage!");


        }


        //Performed once when the game begins
        public void Start()
        {
            CharacterName();
            InitializeItem();
        }



        //Repeated until the game ends
        public void Update()
        {
            KitchenShop();
            SelectingWeapon();
            EnemyBattle();
            ContinueBattle();
            GettingAnAlly();

        }

        //Performed once when the game ends
        public void End()
        {
            BossBattle();
        }
    }
}
