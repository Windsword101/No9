using System.ComponentModel;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float ChaseDistance;
    protected Transform target;
    private SpriteRenderer sprite;
    public float timer;
    private float rad;
    private void Start()
    {
        rad = Random.Range(0f, 6f);
        timer = rad;
        target = GameObject.Find("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Move();
        Chase();
        
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, target.position) > ChaseDistance)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                transform.Rotate(0f, 180f, 0f);
                timer = 0;
            }
        }
    }
    protected virtual void Chase()
    {
        if (Vector2.Distance(transform.position, target.position) < ChaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position.x > target.transform.position.x)
            {
                transform.eulerAngles = new Vector2(0, 180);
                //sprite.flipX = false;
            }
            if (transform.position.x < target.transform.position.x)
            {
                transform.eulerAngles = new Vector2(0, 0);
                //sprite.flipX = true;
            }
        }
    }
}
    
        
    


