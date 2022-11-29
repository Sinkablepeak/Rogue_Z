using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider; // Esta Variable es para evitar que el arma colisione con nuestro propio collider
    private int damage = 1;
    private void OnTriggerStay(Collider other)
    {
        if (other == myCollider) { return; } // Aqui indicmos que si el collider que toco el vomito es el nuestro pues no hacer nada
        
            if (other.TryGetComponent<Health>(out Health health)) // Aqui busca si lo que toco tiene el Script de Health
            {
                health.DealDamage(damage);
            }
    }
    public void SetAttack(int damage, float knockBack)
    {
        this.damage = damage;
    }
}

