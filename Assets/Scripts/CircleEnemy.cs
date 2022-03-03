using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    Vector3 Center;
    public float radius;
    public float speed;
    void Start()
    {
        Center = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Cos(timer*speed), Mathf.Sin(timer*speed))*radius+Center;
        //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), transform.position, Quaternion.identity).transform.localScale /= 2 ;
    }
}
