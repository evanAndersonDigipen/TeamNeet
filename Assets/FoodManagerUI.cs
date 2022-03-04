using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodManagerUI : MonoBehaviour
{
    public FoodManager FoodManager;

    public GameObject ingredient;
    public GameObject place_text;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Recipe r in FoodManager.recipes)
        {
            GameObject t = Instantiate(place_text, transform);
            t.name = r.foodName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
