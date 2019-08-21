using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_RPG
{
    class Game
    {
        String playerName = "";
        int playerHealth = 100;
        public void Start()
        {
            //call functions
            Welcome();

                //make sure player isn't dead
            bool alive = true;

            alive = Encounter(130);
            if (alive)
            {
                alive = Encounter(20);
            }

            //wait for input before closing
            Console.ReadKey();
        }

        void Welcome()
        {
            //Welcome the player
            Console.Write("What is your name? ");
            playerName = Console.ReadLine();
            Console.WriteLine("Welcome, " + playerName + ".");
            
        }
        bool Encounter(int monsterDamage)
        {

            //Monster encounter!
            Console.WriteLine("");
            Console.WriteLine("There is a monster in front of you!");

            //player input
            string action = "";
            Console.Write("What will you do? (Flee/Fight) ");
            action = Console.ReadLine();
            if (action == "fight" || action == "Fight")
            {
                //monster attack
                Console.WriteLine("The monsters attacks! " + playerName + " takes " + monsterDamage + " damage! ");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + " has " + playerHealth + " health remaining. ");

                if (playerHealth <= 0)
                {
                    //player defeated
                    Console.WriteLine(playerName + " was defeated! ");
                        return false;
                }

                //player attack
                Console.WriteLine(playerName + " attacks! The monster is defeated! ");

            }
            else if (action == "flee" || action == "Flee")
            {
                //escape
                Console.WriteLine("Got away Safely... ");
            }
            return true;
        }
    }
}
