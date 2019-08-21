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
        int playerMaxHealth = 100;
        int playerDamage = 10;
        int playerHealing = 50;
        public void Start()
        {
            //call functions
            Welcome();

            int monstersRemaining = 5;

                //make sure player isn't dead
            bool alive = true;

            //encounter loop
            while (alive && monstersRemaining > 0)
            {
                Console.Write("There are " + monstersRemaining + " much DOGE. ");
                alive = Encounter(20, 20);
                monstersRemaining--;
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
        bool Encounter(int monsterDamage, int monsterHealth)
        {

            //Monster encounter!
            Console.WriteLine("");
            Console.WriteLine("A wild DOGE appears!");

            //player input
            string action = "";
            bool survived = true;
            while (playerHealth > 0 && monsterHealth > 0)
            {
                Console.Write("What will you do? (Flee/Fight/Heal) ");
                action = Console.ReadLine();
                if (action == "fight" || action == "Fight")
                {
                    survived = Fight(ref monsterHealth, ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }
                }
                else if (action == "flee" || action == "Flee")
                {
                    //escape
                    survived = Flee();
                    if (survived)
                    {
                        return true;
                    }
                    
                }
                else if (action == "heal" || action == "Heal")
                {
                    
                    survived = Heal(ref monsterHealth, ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }

                }

            }
            return survived;
        }

        bool Fight(ref int monsterHealth, ref int monsterDamage)
        {
            //monster attack
            Console.WriteLine("The DOGE attacks! " + playerName + " takes " + monsterDamage + " damage! Very pain.");
            playerHealth = playerHealth - monsterDamage;
            Console.WriteLine(playerName + " has " + playerHealth + " health remaining. ");

            if (playerHealth <= 0)
            {
                //player defeated
                Console.WriteLine(playerName + " was defeated! ");
                return false;
            }

            //player attack
            Console.WriteLine(playerName + " attacks! The DOGE takes " + playerDamage + " damage");
            monsterHealth -= playerDamage;
            Console.WriteLine("The DOGE has " + monsterHealth + "  health remaining. Much hurt. ");
            if (monsterHealth <= 0)
            {
                //monster defeat
                Console.WriteLine("The DOGE has fainted! RIPeroni pupperoni...");
                return true;
            }
            return true;
        }

        bool Flee()
        {
            Console.WriteLine("Got away Safely... ");
            return true;
        }

        bool Heal(ref int monsterHealth, ref int monsterDamage)
        {

            //monster attack
            Console.WriteLine("The DOGE attacks! " + playerName + " takes " + monsterDamage + " damage! Very pain.");
            playerHealth = playerHealth - monsterDamage;
            Console.WriteLine(playerName + " has " + playerHealth + " health remaining. ");

            if (playerHealth <= 0)
            {
                //player defeated
                Console.WriteLine(playerName + " was defeated! ");
                return false;
            }

            //player heal
            Console.WriteLine(playerName + " Devours the souls of the innocen- I mean... heals " + playerHealing + " points");
            playerHealth += playerHealing;
            if (playerHealth > playerMaxHealth)
            {
                playerHealth = playerMaxHealth;
            }
            Console.WriteLine(playerName + " has " + playerHealth + " health remaining. ");
            return true;
        }
    }
}
