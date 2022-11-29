using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] public float PlayerVomitRange { get; private set; }
    [field: SerializeField] public float SummonRange { get; private set; }
    [field: SerializeField] public float ThrowingRange { get; private set; }
    [field: SerializeField] public GameObject Vomit { get; private set; } = null;
    [field: SerializeField] public GameObject ProjectileOBJ { get; private set; } = null;
    [field: SerializeField] public GameObject ProjectileINS { get; private set; } = null;
    [field: SerializeField] public Rigidbody projectileRB { get; private set; }
    [field: SerializeField] public Transform Hands { get; private set; } = null;
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float ThrowRange { get; private set; }
    [field: SerializeField] public GameObject ZombiesSpawner { get; private set; }
    [field: SerializeField] public int  AttackDamage { get; private set; }
    [field: SerializeField] public int AttackKnockBack { get; private set; }
    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }
    [field: SerializeField] public GameObject vomitOBJ { get; private set; }
    [field: SerializeField] public Transform spawnPoint { get; private set; }
    [field: SerializeField] public float VomitForce { get; private set; }
    public Health Player { get; private set; }
    public float ThrowSpeed;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        Agent.updatePosition = false;
        Agent.updateRotation = false;
        SwitchState(new EnemyIdleState(this));
    }
    public void InstantiateVomit()
    {
        Vomit = Instantiate(vomitOBJ, spawnPoint.transform.position, Quaternion.identity);
        Rigidbody vomitRB = Vomit.GetComponent<Rigidbody>();
        Vector3 direction = Player.transform.position - transform.position;
        vomitRB.velocity = (direction * VomitForce);
        Vomit.GetComponent<Collider>().isTrigger = true;
        Destroy(Vomit, 10f);
    }
    public void InstantiateProjectile()
    {
        projectileRB.useGravity = false;
        projectileRB.isKinematic = true;
        ProjectileINS = Instantiate(ProjectileOBJ, Hands);
    }
    public void ReleaseOBJ()
    {
        Vector3 PlayerDistance = (Player.transform.position - ProjectileINS.transform.position);
        ProjectileINS.transform.parent = null;
        ProjectileINS.GetComponent<Rigidbody>().useGravity = true;
        ProjectileINS.GetComponent<Rigidbody>().isKinematic = false;
        ProjectileINS.GetComponent<Rigidbody>().mass = 2;
        ProjectileINS.GetComponent<Rigidbody>().velocity = PlayerDistance.normalized * ThrowSpeed * Time.deltaTime;
        ProjectileINS.GetComponent<Collider>().isTrigger = true;
        //ProjectileINS.GetComponent<Rigidbody>().AddForce(transform.forward * 3500);
        ProjectileINS.GetComponent<Rigidbody>().AddForce(transform.up * 750);
        Destroy(ProjectileINS, 2);
    }
    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }
    private void HandleTakeDamage()
    {
        SwitchState(new EnemyImpactState(this));
    }
    private void HandleDie()
    {
        SwitchState(new EnemyDeadState(this));
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, PlayerVomitRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SummonRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ThrowingRange);
    }
}

