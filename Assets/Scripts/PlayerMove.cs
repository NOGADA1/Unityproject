using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MaxSpeed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Move by control
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right*h,ForceMode2D.Impulse);
        if(rigid.velocity.x > MaxSpeed)
        {
            rigid.velocity  = new Vector2(MaxSpeed, rigid.velocity.y);
        }
        else  if (rigid.velocity.x < MaxSpeed*(-1))
        {
            rigid.velocity = new Vector2(MaxSpeed*(-1), rigid.velocity.y);
        }
    }
}
