using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider; // Esta Variable es para evitar que el arma colisione con nuestro propio collider
    private int damage;
    private float knockBack;
    private List<Collider> alreadyCollidedWith = new List<Collider>();
    private void OnEnable()
    {
        alreadyCollidedWith.Clear(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; } // Aqui indicmos que si el collider que toco el arma es el nuestro pues no hacer nada

        if (alreadyCollidedWith.Contains(other)) { return; } // Esto es para evitar colisionar con el mismo objeto mas de 2 veces con un swing del arma.

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent<Health>(out Health health)) // Aqui busca si lo que toco tiene el Script de Health
        {
            health.DealDamage(damage);
        }
        if(other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * knockBack);
        }
    }

    public void SetAttack(int damage, float knockBack)
    {
        this.damage = damage;
        this.knockBack = knockBack;
    }
}

