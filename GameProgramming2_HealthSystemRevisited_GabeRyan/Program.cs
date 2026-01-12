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
            
        }

        class Health
        {

            public int CurrentHealth { get;  private set; }
            public int MaxHealth { get; private set; }


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

            public void HealthConstructor(int maxHealth)
            {
                MaxHealth = maxHealth;
                CurrentHealth = maxHealth;
            }
        }


        class Player
        {
            
            public string Name { get; set; }

            public static Health Health { get; private set; }

            public static Health Shield { get; private set;}

            int _shield = Shield.CurrentHealth;
            int _health = Health.CurrentHealth;
            

            public void TakeDamage(int dmg)
            {


                if (dmg > _shield)
                {
                    dmg -= _shield;
                    _health -= dmg;
                    _shield = 0;

                    return;
                   
                }

                if(dmg < 0)
                {
                    Console.Write("You cant take negative damage");
                    Console.ReadKey();
                    return;
                }

                _shield -= dmg;

                GetStatusString();

            }

            public string GetStatusString()
            {
                if (_health == 0)
                {
                    
                }
                else
                {
                    return;
                }
            }

            public Player(string name, int maxHealth, int maxShield);
        }
    }
}
