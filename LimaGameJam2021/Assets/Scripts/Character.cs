using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]
    public float hp;
    public float speed;
    public float damage;
    public float cooldown;
    protected new string name;

    [Header("Cooldown")]
    public float coolDown;
    public float coolDownTimer;


    public virtual void Start()
    {
        Debug.Log("Start");
    }

    public virtual void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        Death();

        Movement();
    }

    public void ReciveDamage(float _damage)
    {
        hp -= _damage;
    }

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }

    public virtual void Movement()
    {
        Debug.Log("Movement");
    }

    public void Death()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}