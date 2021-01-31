using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : Enemy
{
    [Header("Attack Attributes")]
    public float minDistance;
    public float rangeExplotion;
    public LayerMask playerLayer;

    Vector3 refObject;
    Vector3 direction;
    float angle;
    bool isLook;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeExplotion);
    }

    public override void Movement()
    {
        if (target)
        {
            refObject = target.position;

            direction = Vector3.Normalize(refObject - transform.position);

            angle = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg - 90.0f;

            transform.eulerAngles = Vector3.up * angle;

            StartCoroutine(StopLook(5.0f));
        }

        if (isLook)
        {
            float distance = Vector3.Distance(refObject, transform.position);

            if (distance > minDistance)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                Attack();
                isLook = false;
                Destroy(gameObject);
            }

        }
    }

    IEnumerator StopLook(float _timer)
    {
        yield return new WaitForSeconds(_timer);
        target = null;
        isLook = true;
    }

    public override void Attack()
    {
        Collider[] touch = Physics.OverlapSphere(transform.position, rangeExplotion, playerLayer);

        foreach (Collider item in touch)
        {
            item.GetComponent<Player>().ReciveDamage(damage);
        }
    }
}