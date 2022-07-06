using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float horizontalTime;
    public Rigidbody2D rb;
     float force = 5000;
    float distance; 
    public bool touchWithGround = false ;
   // public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
        horizontalTime = Input.GetAxisRaw("Horizontal")*speed;
        //verticalTime = Input.GetAxisRaw("Vertical");
        run();

        if(Input.GetButtonDown("Jump") && touchWithGround )
        {
            
           // rb.gravityScale = 0;
            //rb.AddForce(new Vector2(0, jumpForce));
            rb.AddForce(Vector2.up * force);
            touchWithGround = false;
           //rb.gravityScale = 50;
        }

       
      
    

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            touchWithGround = true;
        }
        

    }
    public void run()

    {
        rb.velocity = new Vector2(horizontalTime, 0);
    }

    //public void jump()
    //{
    //    //rb.velocity = Vector2.up * force;
    //    rb.AddForce(Vector2.up * force);
    //}
    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject.GetComponent<MagnetBehaviour>()!=null)
        Debug.Log("magnetcollider");
    }
}
