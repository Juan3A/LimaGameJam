using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Player Attributes")]
    public CharacterController controller;
    public float jumpHeight;
    public float heavy;

    [Header("Attack Attributes")]
    public Transform attackOrigin;
    [Range(0f, 5f)]
    public float rangeAttack;
    public LayerMask enemieLayer;

    [Header("Ground Attributes")]
    public Transform groundCheck;
    [Range(0f, 1f)]
    public float radiusGroundCheck;
    public float gravity;
    public LayerMask groundLayer;

    // Helpers
    float currentTime;
    bool isGrounded, dashActive;
    Vector3 velocity;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        #region Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, radiusGroundCheck, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        base.Update();
        Jump();


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        #endregion

        Attack();

        Dash(40.0f, 0.13f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (attackOrigin)
            Gizmos.DrawWireSphere(attackOrigin.position, rangeAttack);

        Gizmos.color = Color.green;
        if (groundCheck)
            Gizmos.DrawWireSphere(groundCheck.position, radiusGroundCheck);
    }

    // Listo
    public override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float angle = 0;

        if (horizontal != 0 || vertical != 0)
        {
            angle = Mathf.Atan2(vertical, -horizontal) * Mathf.Rad2Deg - 90.0f;

            transform.eulerAngles = Vector3.up * angle;
        }

        controller.Move(new Vector3(horizontal, 0, vertical) * HeavyBody(heavy, speed) * Time.deltaTime);
    }

    // Listo
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // V = Sqrt(h * -2 * g)
            velocity.y = Mathf.Sqrt(HeavyBody(heavy, jumpHeight) * -2f * gravity);
        }
    }

    // Listo
    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E) && coolDownTimer == 0)
        {
            Collider[] hitInfo = Physics.OverlapSphere(attackOrigin.position, rangeAttack, enemieLayer);

            foreach (Collider col in hitInfo)
            {
                col.GetComponent<Enemy>().ReciveDamage(damage);
            }

            coolDownTimer = coolDown;
        }
    }

    // Listo
    public void Dash(float _force, float _duration)
    {
        if (Input.GetKeyDown(KeyCode.Q) && coolDownTimer == 0)
        {
            dashActive = true;
            coolDownTimer = coolDown;
        }

        if (dashActive)
        {
            currentTime += Time.deltaTime;

            velocity = transform.forward * HeavyBody(heavy, _force);
        }

        if (currentTime > _duration)
        {
            velocity = Vector3.zero;

            dashActive = false;

            currentTime = 0;
        }
    }

    // Listo
    float HeavyBody(float _heavy, float _value)
    {
        if (_heavy >= _value)
        {
            return 1.0f;
        }

        return _value - _heavy;
    }
}