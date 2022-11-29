using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int maxHealth = 100;
    public int health;
    private bool isInvulnerable;
    public event Action OnTakeDamage;
    public event Action OnDie;
    public Slider healthBar;

    public bool isDead => health == 0;
    private void Start()
    {
        health = maxHealth;
        healthBar.value = -health;
    }
    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }
    public void DealDamage(int damage)
    {
        if (health == 0) { return; }
        if (isInvulnerable) { return; }

        health = Mathf.Max(health - damage, 0);
        healthBar.value += damage;
        // Las siguientes 2 Lineas es otra forma de hacer lo de la linea anterior a este comentario
        OnTakeDamage?.Invoke();
        //health -= damage;
        //if(health < 0) { health = 0; }
        
        if(health == 0)
        {
            OnDie?.Invoke(); // Cuendo el Personaje Muere
        }
        Debug.Log(health);
    }
}