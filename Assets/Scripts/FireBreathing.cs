using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour
{
    LayerMask enemyMask;
    public AudioClip fireee;

    private void Start()
    {
        enemyMask = LayerMask.GetMask("Enemy");
    }
    public void Blast()
    {
        Animator a = GetComponent<Animator>();
        AudioSource source = GetComponent<AudioSource>();

        source.PlayOneShot(fireee);
        a.Play("Fire");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1<<collision.gameObject.layer) & enemyMask) != 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
