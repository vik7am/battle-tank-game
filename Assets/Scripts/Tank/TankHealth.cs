using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankHealth
    {
        float currentHealth;
        bool alive;

        public TankHealth(float health){
            alive = true;
            currentHealth = health;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
            if(currentHealth <= 0)
                alive = false;
        }

        public bool IsAlive(){
            return alive;
        }
    }
}
