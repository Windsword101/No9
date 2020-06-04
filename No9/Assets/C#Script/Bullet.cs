using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("角色物件")]
    private Transform spriteRenderer;
    [Header("子彈速度")]
    public float speed;
    [Header("子彈消滅時間")]
    public float deletetime;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<Transform>();
        Destroy(gameObject, deletetime);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > spriteRenderer.position.x)
        {
            transform.Translate(new Vector2(1, 0) * speed);
        }
        else if (gameObject.transform.position.x < spriteRenderer.position.x)
        {
            transform.Translate(new Vector2(-1, 0) * speed);
        }
        else if (gameObject.transform.position.y  > spriteRenderer.position.y )
        {
            transform.Translate(new Vector2(0, 1) * speed);
        }
    }
}
