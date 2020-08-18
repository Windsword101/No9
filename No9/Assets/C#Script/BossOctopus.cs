using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOctopus : Enemy1
{
    public int hp;
    public int damage;
    public int scripthp;
    public static bool octopus=false;

    private void Start()
    {
        scripthp = hp;
        rb = GetComponent<Rigidbody2D>();
        rad = Random.Range(0f, 6f);
        timer = rad;
        target = GameObject.Find("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }
    protected override void Update()
    {
        base.Update();

    }
    public void Hurt()
    {
        scripthp -= damage;
        if (scripthp <= 0)
        {
            Destroy(gameObject);
            octopus = true;
        }
    }
}
