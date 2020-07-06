using System.ComponentModel;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public float ChaseDistance;
    private Transform target;
    private SpriteRenderer sprite;
    private float timer = 0;

    private void Start()
    {

        target = GameObject.Find("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            transform.Rotate(0f, 180f, 0f);
            timer = 0;
        }
        if (Vector2.Distance(transform.position, target.position) < ChaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (transform.position.x > target.transform.position.x)
            {
                sprite.flipX = false;
            }
            if (transform.position.x < target.transform.position.x)
            {
                sprite.flipX = true;
            }
        }
    }
}
