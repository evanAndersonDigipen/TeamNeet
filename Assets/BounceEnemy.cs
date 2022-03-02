using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]
public class BounceEnemy : MonoBehaviour
{
    //[Header("Ground stuff")]
    public Transform groundCheck;
    public bool grounded;
    public LayerMask ground;
    
    
  
    Rigidbody2D rb;

    public float JumpForce;

    public bool speedUp;

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
        grounded = Physics2D.OverlapCircle(groundCheck.position, .1f, ground);
        if (grounded)
        {
            rb.velocity *= speedUp ? 1 : 0;
            rb.AddForce(new Vector2(1, 5)*JumpForce);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, .1f);

    }
}
