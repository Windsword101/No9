using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("角色物件")]
    public SpriteRenderer spriteRenderer;
    [Header("角色血量")]
    public GameObject[] Health;
    [Header("移動速度")]
    public float speed;
    [Header("跳躍高度")]
    public float height;
    [Header("子彈物件")]
    public GameObject bullet;
    [Header("子彈生成點")]
    public Transform createobjectright;
    public Transform createobjectup;
    public Transform duck;
    public Transform cancelduck;
    [Header("子彈音效")]
    public AudioSource shootingsound;
    [Header("連續射擊間隔")]
    public float fireRate;
    public Teleport tele;


    private int HeartNum = 3;
    private int jumpTimes = 0;
    private Rigidbody2D rig;
    private Animator ani;
    private bool isGround = true;
    private bool _isGround = true;
    private bool shootup = false;
    private bool jump = false;
    private bool duckshot = false;
    private float timer = 0;
    private float nextFire = 0;






    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        rig.AddForce(Vector3.right * h * speed);
        ani.SetBool("Run", Input.GetButton("Horizontal") && isGround == true);
        ani.SetBool("Stand", h == 0 && Input.GetKeyDown(KeyCode.C));
        ani.SetBool("RunShot", (h > 0 || h < 0) && Input.GetKeyDown(KeyCode.C));

    }
    /// <summary>
    /// 是否碰到地面、扣血
    /// </summary>
    /// <param name="selfbody"></param>
    private void OnCollisionEnter2D(Collision2D selfbody)
    {

        if (selfbody.gameObject.tag == "ground")
        {
            isGround = true;
            jumpTimes = 0;
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        if (selfbody.gameObject.tag == "Enemy")
        {
            HeartNum--;
            ani.SetTrigger("Hurt");
            if (HeartNum == 2)
            {
                Health[0].SetActive(false);
            }
            else if (HeartNum == 1)
            {
                Health[1].SetActive(false);
            }
            else if (HeartNum == 0)
            {
                Health[2].SetActive(false);
            }
        }
    }
    /// <summary>
    /// 是否離開地面
    /// </summary>
    /// <param name="selfbodyexit"></param>
    private void OnCollisionExit2D(Collision2D selfbodyexit)
    {
        if (selfbodyexit.gameObject.tag == "ground")
        {
            isGround = false;

        }

    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if ((isGround || jump) && Input.GetKeyDown(KeyCode.X))
        {
            isGround = false;
            timer = 0;
            rig.AddForce(new Vector2(0, height));
            if (BossJump.doublejump == true)
            {
                jumpTimes++;
                jump = true;
            }

            ani.SetTrigger("Jump");
        }
        if (!isGround)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                timer = 0;
                rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }


    }
    /// <summary>
    /// 射擊
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKey(KeyCode.C) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ani.SetTrigger("Stand");
            if (Input.GetKey(KeyCode.UpArrow))
            {
                shootup = true;

                Instantiate(bullet, createobjectup.position, createobjectup.rotation);
            }
            if (shootup == false)
            {

                Instantiate(bullet, createobjectright.position, createobjectright.rotation);
            }
            else
            {
                shootup = false;
            }
            shootingsound.Play();
        }

        if (Input.GetKey(KeyCode.DownArrow)) duckshot = true;
        if (Input.GetKeyUp(KeyCode.DownArrow)) duckshot = false;
        if (duckshot == true)
        {
            createobjectright.position = duck.position;
        }
        if (duckshot == false)
        {
            createobjectright.position = cancelduck.position;
        }

        print("duck" + duckshot);
        ani.SetBool("ShotUp", Input.GetKey(KeyCode.UpArrow));
        ani.SetBool("Duck", Input.GetKey(KeyCode.DownArrow));
    }

    private void Awake()
    {
        Health = GameObject.FindGameObjectsWithTag("Health");
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        if (BossTeleport.teleport == true)
        {
            tele.enabled = true;
        }
        if (jump == true)
        {
            if (jumpTimes > 1 || timer > 1.9f)
            {
                jump = false;
                jumpTimes = 0;
            }
        }
        Jump();
        Shoot();


    }
}
