using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移動速度")]
    public float speed;
    [Header("跳躍高度")]
    public float height;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rig;
    private Animator ani;
    private bool isGround;
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
        ani.SetBool("Run", Input.GetButton("Horizontal"));   
    }
    /// <summary>
    /// 是否碰到地面
    /// </summary>
    /// <param name="selfbody"></param>
    private void OnCollisionEnter2D(Collision2D selfbody)
    {
        if(selfbody.gameObject.tag == "ground")
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if(isGround && Input.GetButtonDown("Jump"))
        {
            jump = 0;
            rig.AddForce(new Vector2(0, height));
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
    }
}
