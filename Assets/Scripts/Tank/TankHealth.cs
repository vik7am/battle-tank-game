using UnityEngine;
namespace BattleTank
{
    public class TankHealth
    {
        float maxHealth;
        float currentHealth;

        public TankHealth(float health){
            currentHealth = maxHealth = health;
        }

        public void ReduceHealth(float damage){
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        }

        public bool IsDead(){
            return currentHealth == 0;
        }
    }
}
