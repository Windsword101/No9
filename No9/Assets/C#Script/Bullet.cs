using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.U2D;
using UnityEditorInternal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("角色物件")]
    private Transform spriteRenderer;
    [Header("子彈速度")]
    public float speed;
    [Header("子彈消滅時間")]
    public float deletetime;
    [Header("爆炸特效")]
    public GameObject Effect;
    [Header("爆炸特效消失時間")]
    public float EffectTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            Destroy(exp, EffectTime);
        }
        if (collision.gameObject.name == "BossTeleport")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            BossTeleport.teleport = true;
            GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            Destroy(exp, EffectTime);
        }
        if (collision.gameObject.name == "BossJump")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            BossJump.doublejump = true;
            GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            Destroy(exp, EffectTime);
        }
    }
    void Start()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<Transform>();
        Destroy(gameObject, deletetime);
    }

    void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed);

    }
}
