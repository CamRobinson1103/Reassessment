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
        private Enemy _demon;
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
            _twinNerfPistols.name = "Twin Nerf Pistols";
            _sword.name = "Sword";
            _twinPistols.name = "Twin Pistols";
            _soccerBall.name = "Soccer Ball";
            _spikeBall.name = "Spike Ball";

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

        public Character CharacterName()
        {
            Console.WriteLine("You just woke up from a good night's sleep. You head to the kitchen from some breakfast. When you get to the kitchen you feel" +
                "like something's off. You don't hear your usually loud roommates. You say a loud 'hello'... but no response. You walk oout on your balcony to get some fresh air" +
                "when you are then met with an orange/brown looking sky. You check your surroundong to see other's reaction,but you see nobody. You start to panic for a bit" +
                "until you caught your breath and calmed down a bit. You start off with the basis. What is your name first of all?");
            string name = Console.ReadLine();
            Character player = new Character(10, 0, 0);
            return player;
        }

        public void PrintInventory(Item[] inventory)
        {
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].price);
            }
        }

        public void KitchenShop()
        {
            ClearScreen();
            Console.WriteLine("You want to check out outside, but you are still hungry. You look throughout the kitchen for something to eat.");
            PrintInventory(_kitchenInventory);

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

        public void EnemyBattle()
        {
            ClearScreen();
            char input;
            GetInput(out input, "Plastic baseball bat", "Twin Nerf pistols", "Soccor ball",
            "You walked outside to check on everything, when suddenly you see short demons with axes charging at you! You see a plastic baseball bat " +
                "and a set of twin Nerf pistols to hopefully defend you. Whuch do you choose?");
            if (input == '1')
            {
                Console.WriteLine("You picked up the plastic baseball bat for defense.");
                _player.AddItemToInventory(_plasticBaseballBat,0);
            }
            else if (input == '2')
            {
                Console.WriteLine("You picked up the Nerf guns for defense.");
                _player.AddItemToInventory(_twinNerfPistols,0);
            }
            else if (input == '3')
            {
                Console.WriteLine("You picked up the soccer ball for defence");
                _player.AddItemToInventory(_soccerBall, 0);


                while (_player.GetIsAlive() && _demon.GetIsAlive())
                {

                }
            }
        }

        //Performed once when the game begins
        public void Start()
        {
            CharacterName();
            InitializeItem();
            KitchenShop();
        }



        //Repeated until the game ends
        public void Update()
        {
            
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
