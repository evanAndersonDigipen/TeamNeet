/*****************************************
 * Edited by: Ryan Scheppler
 * Last Edited: 1/27/2021
 * Description: Add this to objects thaht are picked up by the player for points and removed
 * *************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 10;

    public AudioClip PickUpNoise;

    public GameObject SpawnOnPickUp;

    // Current time before food rots
    private float timer;

    // Total time before food rots;
    public float lifetime = 12f;

    // Type of food
    public FoodType type;

    // Start is called before the first frame update
    void Start()
    {
        timer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float ratio = timer / lifetime;
        GetComponent<Renderer>().material.color = new Color(ratio, ratio, ratio);
        if(timer < 0)
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            RespawnFood();
        }
    }

    private void RespawnFood()
    {
        if(timer < -1)
        {
            Vector3 point = GetRespawnPoint();
            GameObject g = Instantiate(gameObject, point, Quaternion.identity);
            g.GetComponent<Renderer>().enabled = true;
            g.GetComponent<Collider2D>().enabled = true;
            Destroy(gameObject);
        }
    }

    private Vector3 GetRespawnPoint()
    {
        Transform t = GameObject.Find("Respawn Points Parent").transform;
        int selectedChild = Random.Range(0, t.childCount);
        return t.GetChild(selectedChild).position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<FoodManager>().AddFood(type);
            AudioSource PAud = collision.gameObject.GetComponent<AudioSource>();
            if(PAud != null)
            {
                PAud.PlayOneShot(PickUpNoise);
            }
            if(SpawnOnPickUp != null)
            {
                Instantiate(SpawnOnPickUp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
