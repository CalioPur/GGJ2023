using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTree : MonoBehaviour
{
    public int life = 1000;
    public HealthBar healthBar;

    public void Start()
    {
        healthBar.SetMaxHealth(life);
    }

    public void getHurt(int damage)
    {
        life -= damage;
        healthBar.setHealth(life);
    }
}
