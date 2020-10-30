using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;
    CharacterStats opponentStats;
    [Delayed]
    public float attackSpeed = 1f;
    float attackCooldown = 0f;
    public float attackDelay = .6f;


    const float combatCooldown = 5f;
    float lastAttackTime;
    public bool InCombat { get; private set; }

    public event System.Action OnAttack;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            opponentStats = targetStats;
            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }


    public void AttackHit_AnimationEvent()
    {
        opponentStats.takeDamage(myStats.Damage.GetValue());
        if (opponentStats.currentHealth <= 0)
        {
            InCombat = false;
        }
    }

}
