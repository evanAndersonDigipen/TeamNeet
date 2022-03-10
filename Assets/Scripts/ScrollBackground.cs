using UnityEngine;
using System.Collections;


public class ScrollBackground : MonoBehaviour
{

    //target can be rigidbody2d component of a player or some object

    public GameObject copy;
    public Rigidbody2D target;
    //speed of scrolling
    public float speed;

    public float vert_speed;

    private float last_y;

    bool dir = false;
    
    void Start()
    {
        Instantiate(copy, transform);
        Instantiate(copy, new Vector3(copy.GetComponent<SpriteRenderer>().bounds.size.x, 0), Quaternion.identity, transform).GetComponent<SpriteRenderer>().flipX = true;
          
    }



    void FixedUpdate()
    {

        for(int i = 0; i < transform.childCount; i++)
        {
            Transform g = transform.GetChild(i);
            g.Translate(new Vector3(-speed * target.velocity.x, 0)*Time.deltaTime);
            float width = g.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
            if (target.position.x - g.position.x > width)
            {
                g.Translate(new Vector3(width*2, 0));
            }
            else if(g.position.x - target.transform.position.x > width)
            {
                g.Translate(new Vector3(-width*2, 0));
            }
        }

        
        Vector3 pos = transform.position;
        if (target.position.y != last_y)
        {
            
            
            pos.y = target.position.y;
            pos.y -= (target.position.y) * vert_speed;

            transform.position = pos;

            last_y = target.position.y;
        }
        
        transform.position = Vector3.Lerp(transform.position, pos, .01f);
        


    }
    

}