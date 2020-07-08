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
    [Header("子彈音效")]
    public AudioSource shootingsound;

    private int HeartNum = 3;
    private int jumpTimes = 0;
    private Rigidbody2D rig;
    private Animator ani;
    private bool isGround = true;
    private bool shootup = false;
    private bool jump = false;
    private float timer = 0;




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
        ani.SetBool("RunShot", h > 0 && h < 0 && Input.GetKeyDown(KeyCode.C));
        
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
        if (isGround && Input.GetKeyDown(KeyCode.X))
        {
            jumpTimes++;
            jump = true;
            rig.AddForce(new Vector2(0, height));
            ani.SetTrigger("Jump");

        }
        if (!isGround)
        {


        }

        //ani.SetFloat("Jump", jump);
    }
    /// <summary>
    /// 射擊
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
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


        ani.SetBool("ShotUp", Input.GetKey(KeyCode.UpArrow));
        ani.SetBool("Duck", Input.GetKey(KeyCode.DownArrow));
    }

    private void Awake()
    {
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

        if (jump == true)
        {
            isGround = true;

            if (jumpTimes > 1)
            {
                isGround = false;
                jump = false;
                jumpTimes = 0;
            }
        }
        Jump();
        Shoot();


    }
}
