using System.ComponentModel;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 0.5f;
    public float ChaseDistance = 3;
    public float timer;
    public Rigidbody2D rb;
    public Transform groundDetection;
    private SpriteRenderer sprite;
    private float rad;
    protected Transform target;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (Vector2.Distance(transform.position, target.position) > ChaseDistance)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            timer += Time.deltaTime;
            if (timer > 3f || groundInfo.collider == false)
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
            }
            if (transform.position.x < target.transform.position.x)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
    }
}





