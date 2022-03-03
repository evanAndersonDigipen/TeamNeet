using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]
public class BounceEnemy : MonoBehaviour
{
    //[Header("Ground stuff")]
    public Transform groundCheck;
    public Transform leftCheck;
    public Transform rightCheck;

    public bool grounded;
    public LayerMask ground;
    
    
  
    Rigidbody2D rb;

    public float JumpForce;
    public float xSpeed;

    public bool speedUp;
    bool direction = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        JumpForce = JumpForce > 0 ? JumpForce : 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        bool right = Physics2D.OverlapCircle(rightCheck.position, .1f, ground);
        bool left = Physics2D.OverlapCircle(leftCheck.position, .1f, ground);

        


        grounded = Physics2D.OverlapCircle(groundCheck.position, .1f, ground);
        if (right)
        {
            direction = false;
            grounded = true;
        }
        if (left)
        {
            direction = true;
            grounded = true; 
            
        }
        if (grounded)
        {
            rb.velocity *= speedUp ? 1 : 0;
            rb.AddForce(new Vector2(direction ? xSpeed : -xSpeed, 5)*JumpForce);
        }
    }
    
    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(groundCheck.position, .1f);
        Gizmos.DrawWireSphere(leftCheck.position, .1f);
        Gizmos.DrawWireSphere(rightCheck.position, .1f);

        //Debug.DrawLine(transform.position, transform.position + new Vector3(1, 0), Color.red);
        //Debug.DrawLine(transform.position, transform.position + new Vector3(-1, 0), Color.red);

    }
}
