using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController player;
    public GameObject prefab;
    public Sprite dead;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        for (int i = 0; i < player.lives-1; i++)
        {
            GameObject g = Instantiate(prefab, transform);
            Destroy(g.GetComponent<Lives>());
            g.transform.localPosition = new Vector3(100*(i+1), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int orig = transform.childCount + 1;
        for (int i = 0; i < orig; i++)
        {
            GameObject g = null;
            
            if (i == 0)
            {
                g = gameObject;
            }
            else
            {
                g = transform.GetChild(i-1).gameObject;
            }

            if (i < orig - player.lives)
            {
                g.GetComponent<Image>().sprite = dead;
            }

        }
    }
}
