using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordBoss : Enemy1
{
    public int hp;
    public int damage;
    public Image sliderHp;
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
        sliderHp = GameObject.Find("Sliderhp").GetComponent<Image>();
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
        sliderHp.fillAmount = scripthp / hp;
    }

    private void Dead()
    {
        if (scripthp <= 0)
        {
            ani.SetTrigger("Dead");
            transform.Translate(new Vector2(0, 0));
            Destroy(gameObject, 3f);
        }
    }





}
