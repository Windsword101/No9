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

    private void Awake()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy1>().hittimes++;
            if (collision.gameObject.GetComponent<Enemy1>().hittimes >= 2)
            {
                Destroy(collision.gameObject);
                GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
                Destroy(exp, EffectTime);
            }
        }
        if (collision.gameObject.tag == "EnemyJumper")
        {
            Destroy(collision.gameObject);
            GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            Destroy(exp, EffectTime);
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "BossTeleport")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            BossTeleport.teleport = true;
            GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            Destroy(exp, EffectTime);
        }
        if (collision.gameObject.name == "Hero")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<SwordBoss>().Hurt();
        }
        if (collision.gameObject.name == "smallHero")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<smallSwordBoss>().Hurt();
        }
        if (collision.gameObject.name == "BossOctopus")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<BossOctopus>().Hurt();
            if (collision.gameObject.GetComponent<BossOctopus>().scripthp <= 25)
            {
                GameObject exp = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
                Destroy(exp, EffectTime);
            }
        }
        if (collision.gameObject.name == "gate")
        {
            gate.gatedestroy = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
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
