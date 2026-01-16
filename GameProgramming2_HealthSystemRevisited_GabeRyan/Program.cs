using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_HealthSystemRevisited_GabeRyan
{
    internal class Program
    {
        static bool _isPlaying = true;
        static Random random = new Random();
        static Player _player;
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Name");

            string playerName = Console.ReadLine();

            Player player = new Player(name: playerName, maxHealth: 100, maxShield: 100);
            _player = player;

            while (_isPlaying == true)
            {
                
                
                
                player.ShowHud();
                Console.WriteLine("Press D To Take Damage And H To Heal");
                Choice();
 
            }

            
            
            
        }
        
        static void Choice()
        {
            ConsoleKey Input = Console.ReadKey(true).Key;

            if(Input == ConsoleKey.D)
            {
                int randomDmg = random.Next(1, 21);
                _player.TakeDamage(randomDmg);
                Console.ReadKey();

                GameOver();

            }

            else if(Input == ConsoleKey.H)
            {
                int randomHeal = random.Next(1, 21);
                _player._health.Heal(randomHeal);
                Console.ReadKey();
            }
        }

        static void GameOver()
        {
            if (_player._health.CurrentHealth <= 0)
            {

                _player.GetStatusString();

                Console.WriteLine("You Died! Press Any Key");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }

        class Health
        {
            
            public int CurrentHealth { get; private set; }
            public int MaxHealth { get; private set; } 

            public Health(int MaximumHealth)
            {
            
                MaxHealth = MaximumHealth;
                CurrentHealth = MaxHealth;
            }

            public void TakeDmg(int dmg)
            {
                
                if (dmg < 0)
                {
                    
                    Console.Write("You cant take negative damage");
                    Console.ReadKey();
                    return;

                }

                CurrentHealth -= dmg;

                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                }
            }

            public void Restore()
            {

                CurrentHealth = MaxHealth;
         
            }

            public void Heal(int heal)
            {
                

                if(heal < 0)
                {
                    Console.Write("You cant heal negative health");
                    Console.ReadKey();
                    return;
                }

                CurrentHealth += heal;

                if (CurrentHealth > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }

            }


        }


        class Player
        {
            
            public string Name { get; set; }

            public Health _health { get; private set; }

            public Health _shield { get; private set;}

            public void TakeDamage(int dmg)
            {
                if (dmg > _shield.CurrentHealth)
                {
                    int carryOver = dmg - _shield.CurrentHealth;

                    _shield.TakeDmg(dmg);
                    _health.TakeDmg(carryOver);

                    return;
                   
                }

                if(dmg < 0)
                {
                    Console.Write("You cant take negative damage");
                    Console.ReadKey();
                    return;
                }

                _shield.TakeDmg(dmg);



            }

            public string GetStatusString()
            {
                if (_health.CurrentHealth == 100)
                {
                    return "You are in perfect health";
                }
                else if (_health.CurrentHealth >= 50)
                {
                    return "you are ok";
                }
                else if(_health.CurrentHealth >= 1)
                {
                    return "you are about to die";
                }
                else
                {
                    return "you are dead";
                }
            }

            public void ShowHud()
            {
                Console.WriteLine($"Name: {Name} Health: {_health.CurrentHealth} Shield: {_shield.CurrentHealth} Status: {GetStatusString()}");


            }

            public Player(string name, int maxHealth, int maxShield)
            {
                Name = name;
                _health = new Health(maxHealth);
                _shield = new Health(maxShield);
                
            }
        }


    }
}
