using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallSwordBoss : Enemy1
{
    public int hp;
    public int damage;
    private Animator ani;
    private float scripthp;
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        scripthp = hp;

    }
    private void Update()
    {
        speed = 6;
        Attack();
        if (scripthp > 0) Chase();
        Dead();
    }

    private void Attack()
    {
        if (Vector2.Distance(transform.position, target.position) < ChaseDistance)
        {
            timer += Time.deltaTime;
            ChaseDistance = 50f;
            ani.SetTrigger("Run");
            if (Vector2.Distance(transform.position, target.position) < 3 && timer > 2f)
            {
                ani.SetTrigger("Attack");
                timer = 0;
            }
        }
    }
    public void Hurt()
    {
        scripthp -= damage;

    }

    private void Dead()
    {
        if (scripthp <= 0)
        {
            ani.SetTrigger("Dead");
            transform.Translate(new Vector2(0, 0));
            Destroy(gameObject, 3f);
            BossSwim.swim =true;
            BossSwim.swimhint = true;
        }
    }





}