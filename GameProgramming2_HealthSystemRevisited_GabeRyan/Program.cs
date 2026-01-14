using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProgramming2_HealthSystemRevisited_GabeRyan
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Name");
            
            
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

            public static Health Health { get; private set; }

            public static Health Shield { get; private set;}

            public void TakeDamage(int dmg)
            {
                if (dmg > Shield.CurrentHealth)
                {
                    int carryOver = dmg - Shield.CurrentHealth;

                    Shield.TakeDmg(dmg);
                    Health.TakeDmg(carryOver);

                    return;
                   
                }

                if(dmg < 0)
                {
                    Console.Write("You cant take negative damage");
                    Console.ReadKey();
                    return;
                }

                Shield.TakeDmg(dmg);



            }

            public string GetStatusString()
            {
                if (Health.CurrentHealth == 100)
                {
                    return "You are in perfect health";
                }
                else if (Health.CurrentHealth >= 50)
                {
                    return "you are ok";
                }
                else if(Health.CurrentHealth >= 1)
                {
                    return "you are about to die";
                }
                else
                {
                    return "you are dead";
                }
            }

            public Player(string name, int maxHealth, int maxShield)
            {
                Name = name;
                Health = new Health(maxHealth);
                Shield = new Health(maxShield);
            }
        }
    }
}
