using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("角色物件")]
    public SpriteRenderer spriteRenderer;
    [Header("角色血量")]
    public float HP = 99f;
    private float _scripthp;
    private Text HPText;
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
    [Header("子彈、受傷音效")]
    public AudioSource shootingsound, hurtsound;
    [Header("連續射擊間隔")]
    public float fireRate;
    public Teleport tele;
    public GameObject _Light;
    //按越久跳躍高
    public float jumpTime;
    public GameObject submarine, swimblock, submarineblock;
    public bool onsubmarine = false;



    //二段跳
    private int jumpTimes = 0;
    private Rigidbody2D rig;
    private Animator ani;
    private bool isGround = true;
    private bool _isGround = true;
    private bool isJumping = false;
    private bool shootup = false;
    private bool jump = false;
    private bool duckshot = false;
    private bool _light = false;
    private float timer = 0;
    private float nextFire = 0;
    //按越久跳躍高
    private float jumpTimeCounter;
    private Text hintText;
    private Image dialogue;
    public static float hintTimer;





    private void Awake()
    {
        hintText = GameObject.Find("dialogueText").GetComponent<Text>();
        dialogue = GameObject.Find("IntoDialogue").GetComponent<Image>();
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(8, 11);
        HPText = GameObject.Find("HPText").GetComponent<Text>();
        _scripthp = HP;
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
        if (onsubmarine == false)
        {
            Move();
            Jump();
        }
        if (onsubmarine == true)
        {
            SubmarineMove();
        }
    }
    void Update()
    {
        if (Application.loadedLevelName != "well")
        {
            hintTimer += Time.deltaTime;
            if (hintTimer >= 5)
            {
                dialogue.enabled = false;
                hintText.enabled = false;
            }
            if (BossSwim.swimhint == true)
            {
                hintText.text = "SOMETHING HAPPENS. CHECK IT OUT!";
                dialogue.enabled = true;
                hintText.enabled = true;

                if (hintTimer >= 5)
                {
                    hintTimer = 0;
                    BossSwim.swimhint = false;
                }
            }
            if (gate.gatedestroyhint == true)
            {
                hintText.text = "YOU HAVE CLOSED THE SEWAGE SYSTEM";
                dialogue.enabled = true;
                hintText.enabled = true;
                if (hintTimer >= 5)
                {
                    hintTimer = 0;
                    gate.gatedestroyhint = false;
                }
            }

        }
        if (Application.loadedLevelName == "No9") gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        swimblock = GameObject.Find("禁止下水");
        submarine = GameObject.Find("submarine");
        submarineblock = GameObject.Find("Submarineblock");
        HPText.text = "ENERGY:" + _scripthp.ToString("F0");
        Dead();
        Swim();
        Shoot();
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
        if (onsubmarine == false)
        {
            Light();
        }

    }
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
        ani.SetBool("RunShot", (h > 0 || h < 0) && Input.GetKey(KeyCode.C));

    }
    private void SubmarineMove()
    {
        float y = Input.GetAxis("Vertical");
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
        rig.AddForce(Vector3.up * y * speed);
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
        if (selfbody.gameObject.tag == "DeathZone")
        {
            Application.LoadLevel("GameOver");
            _scripthp = 99f;
            onsubmarine = false;
        }
        if (selfbody.gameObject.tag == "Enemy" || selfbody.gameObject.tag == "SwordBoss" || selfbody.gameObject.tag == "BossOctopus" || selfbody.gameObject.tag == "EnemyJumper")
        {
            _scripthp -= 8;
            ani.SetTrigger("Hurt");
        }
        if (selfbody.gameObject.name == "Toxic")
        {
            Application.LoadLevel("GameOver");
            _scripthp = 99f;
            onsubmarine = false;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwordBoss")
        {
            _scripthp -= 8;
            ani.SetTrigger("Hurt");
        }
        if (collision.gameObject.name == "" && Input.GetKeyDown(KeyCode.Z))
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "submarine" && Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            submarine.transform.SetParent(gameObject.transform);
            submarine.transform.localPosition = new Vector3(0, 0, 0);
            submarine.transform.rotation = gameObject.transform.rotation;
            submarine.GetComponent<Collider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            BossSwim.swim = false;
            swimblock.GetComponent<Collider2D>().enabled = true;
            swimblock.GetComponent<TilemapRenderer>().enabled = true;
            submarineblock.GetComponent<Collider2D>().enabled = false;
            submarineblock.GetComponent<TilemapRenderer>().enabled = false;
            onsubmarine = true;
        }
        if (collision.gameObject.name == "GoToUnderwater" && Input.GetKeyDown(KeyCode.Z))
        {
            submarine.transform.SetParent(null);
            Destroy(submarine);
            onsubmarine = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (collision.gameObject.name == "DoubleJumpEnable" && Input.GetKeyDown(KeyCode.Z))
        {
            BossJump.doublejump = true;
            hintTimer = 0;
            hintText.text = "Press X twice to double jump";
            dialogue.enabled = true;
            hintText.enabled = true;

        }
        if (collision.gameObject.name == "GoToEnding")
        {
            hintTimer = 0;
            hintText.text = "MISSION COMPLETE!";
            dialogue.enabled = true;
            hintText.enabled = true;
        }
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if ((isGround || jump) && Input.GetKeyDown(KeyCode.X))
        {
            jumpTimeCounter = jumpTime;
            isJumping = true;
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
        if (isJumping == true && Input.GetKey(KeyCode.X))
        {
            if (jumpTimeCounter > 0)
            {
                rig.AddForce(new Vector2(0, height));
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            isJumping = false;
        }
        /*if (!isGround)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                timer = 0;
                rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }*/


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
        ani.SetBool("ShotUp", Input.GetKey(KeyCode.UpArrow));
        ani.SetBool("Duck", Input.GetKey(KeyCode.DownArrow));
    }
    /// <summary>
    /// 手電筒開關
    /// </summary>
    private void Light()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _light = !_light;
            _Light.SetActive(_light);
        }
    }
    private void Swim()
    {
        if (BossSwim.swim == true)
        {
            if (Application.loadedLevelName == "No9")
            {
                swimblock.GetComponent<Collider2D>().enabled = false;
                swimblock.GetComponent<TilemapRenderer>().enabled = false;

            }
        }
    }
    private void Dead()
    {
        if (_scripthp <= 0)
        {
            submarine.transform.SetParent(null);
            Destroy(submarine);
            Application.LoadLevel("GameOver");
            _scripthp = 99f;
            onsubmarine = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
