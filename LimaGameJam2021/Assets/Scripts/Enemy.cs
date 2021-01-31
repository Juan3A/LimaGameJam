using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy")]
    public Transform target;
    public float maxDistance;

    bool detection;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();
    }

    public override void Movement()
    {
        if (target)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= maxDistance)
            {
                Vector3 direction = Vector3.Normalize(target.position - transform.position);

                float angle = 0;

                if (direction.x != 0 || direction.z != 0)
                {
                    angle = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg - 90.0f;

                    transform.eulerAngles = Vector3.up * angle;
                }

                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                target = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }
}