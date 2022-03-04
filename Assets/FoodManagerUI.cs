using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodManagerUI : MonoBehaviour
{
    public FoodManager FoodManager;

    public GameObject ingredient;
    public GameObject place_text;

    public Sprite[] ingredients;

    public Sprite checkmark;
    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < FoodManager.recipes.Length; j++)
        {
            Recipe r = FoodManager.recipes[j];
            GameObject t = Instantiate(place_text, transform);
            t.transform.localPosition += new Vector3(0, j * -40);
            t.name = r.recipeName;

            TMP_Text tmp = t.GetComponent<TMP_Text>();
            tmp.text = r.recipeName;

            for (int i = 0; i < r.input.Length; i++)
            {
                GameObject ing = Instantiate(ingredient, t.transform);
                ing.name = System.Enum.GetName(typeof(FoodType), r.input[i].type);
                ing.transform.localPosition = new Vector3(ing.transform.localPosition.x+i*40+20, 0, 0);

                Image image = ing.GetComponent<Image>();

                image.sprite = spriteFromFoodType(r.input[i].type);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int c = 0; c < FoodManager.recipes.Length; c++)
        {
            Recipe r = FoodManager.recipes[c];
            for(int i = 0; i < r.input.Length; i++)
            {
                for(int j = 0; j < FoodManager.foods.Length; j++)
                {
                    if (FoodManager.IsEnoughFood(r.input[i], FoodManager.foods[j]) && r.input[i].type == FoodManager.foods[j].type)
                    {
                        
                        GameObject g = transform.GetChild(c).GetChild(i).gameObject;
                        //GameObject parent = g.transform.parent.gameObject;
                        g.GetComponent<Image>().color = new Color(.5f, .5f, .5f);
                        if(g.transform.childCount < 1)
                        {
                            GameObject check = Instantiate(ingredient, g.transform.position, Quaternion.identity, g.transform);
                            //parent = g.transform.parent.gameObject;
                            check.GetComponent<Image>().sprite = checkmark;
                        }
                        
                    }
                }
                
            }
        }
    }

    Sprite spriteFromFoodType(FoodType food)
    {
        switch (food)
        {
            case FoodType.Tomato:
                return ingredients[0];
            case FoodType.Onion:
                return ingredients[1];
            case FoodType.Pepper:
                return ingredients[2];
            default:
                return ingredients[0];
                
        }
    }
}
