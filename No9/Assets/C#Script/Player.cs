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
    public Transform createobjetright;
    public Transform createobjetleft;
    public Transform createobjetup;
    [Header("子彈音效")]
    public AudioSource shootingsound;

    private int HeartNum = 3;
    private Rigidbody2D rig;
    private Animator ani;
    private bool isGround;
    private bool shootup = false;
    private float jump;



    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (h < 0)
        {
            spriteRenderer.flipX = true;
        }
        rig.AddForce(Vector3.right * h * speed);
        ani.SetBool("Run", Input.GetButton("Horizontal") && isGround == true);
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
            jump = 0;
            rig.AddForce(new Vector2(0, height));
            ani.SetTrigger("Jump");
        }
        if (!isGround)
        {
            jump += Time.deltaTime;

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
                Instantiate(bullet, createobjetup.position, createobjetup.rotation);
            }
            if (spriteRenderer.flipX == false && shootup == false)
            {
                Instantiate(bullet, createobjetright.position, createobjetright.rotation);
            }
            if (spriteRenderer.flipX == true && shootup == false)
            {
                Instantiate(bullet, createobjetleft.position, createobjetleft.rotation);
            }
            else
            {
                shootup = false;
            }
            shootingsound.Play();
        }
        ani.SetBool("RunShot", Input.GetButton("Horizontal") && Input.GetKeyDown(KeyCode.C));
        ani.SetBool("ShotUp", Input.GetKey(KeyCode.UpArrow));
    }
    void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        Shoot();

    }
}
