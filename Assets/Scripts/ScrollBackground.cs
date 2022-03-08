// Background Scrolling
// Author: Rakesh Malik
// Date: 6-Dec-2016

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class ScrollBackground : MonoBehaviour
{

    //target can be rigidbody2d component of a player or some object
    public Rigidbody2D target;
    //speed of scrolling
    public float speed;

    private float initPos;

    public float vert_speed;

    private float last_y;

    Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
        initPos = transform.localPosition.x;
        //Create a clone for filling rest of the screen
        GameObject objectCopy = GameObject.Instantiate(this.gameObject);
        //Destroy ScrollBackground component in clone
        Destroy(objectCopy.GetComponent<ScrollBackground>());

        objectCopy.transform.SetParent(transform);

        objectCopy.transform.position += new Vector3(GetWidth(), 0, 0);
        Debug.Log(GetWidth());
    }



    void FixedUpdate()
    {

        //get target velocity
        //if you wish to replace target with a non-rigidbody object, this is the place
        float targetVelocity = target.velocity.x;
        //translate sprite according to target velocity
        this.transform.Translate(new Vector3(-speed * targetVelocity, 0, 0) * Time.deltaTime);
        //set sprite is moving out of screen shift it to put clone in its place
        float width = GetWidth();
        if (targetVelocity > 0)
        {
            //shift right if player is moving right
            if (initPos - this.transform.localPosition.x > width)
            {
                this.transform.Translate(new Vector3(width, 0, 0));
            }
        }
        else
        {
            //shift left if player moving left
            if (initPos - this.transform.localPosition.x < 0)
            {
                this.transform.Translate(new Vector3(-width, 0, 0));
            }
        }
        //i added this - Evan
        Vector3 pos = transform.position;
        if (target.position.y != last_y)
        {
            
            
            pos.y = target.position.y;
            pos.y -= (target.position.y) * vert_speed;

            transform.position = pos;

            last_y = target.position.y;
        }
        
        transform.position = Vector3.Lerp(transform.position, pos, .01f);
        //This is where i stop adding things - Evan


    }
    float GetWidth()
    {
        return GetComponent<SpriteRenderer>().bounds.size.x;
    }

}