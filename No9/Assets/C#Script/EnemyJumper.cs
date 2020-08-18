using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyJumper : Enemy1
{
    public int height = 500;
    public bool isGround = false;
    private void Update()
    {
        if (isGround == false) JumpChase();
        Jump();
    }


    private void Jump()
    {
        if (isGround == true)
        {

            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                rb.AddForce(new Vector2(0, height));
                timer = 0;
            }
        }
    }
    private void JumpChase()
    {
        if (Vector2.Distance(transform.position, target.position) < ChaseDistance)
        {
            if (transform.position.x > target.transform.position.x)
            {
                rb.AddForce(Vector2.right * -speed * Time.deltaTime);        
            }
            if (transform.position.x < target.transform.position.x)
            {
                rb.AddForce(Vector2.right * speed * Time.deltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "OnlyforBoss")
        {
            isGround = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "OnlyforBoss")
        {
            isGround = false;

        }
    }
}
