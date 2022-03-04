using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // Recipes to be made
    public Recipe[] recipes;

    // Foods required to spawn in the map
    public FoodType[] levelFoodTypes;

    public GameObject[] levelFoodPrefabs;

    // food counter to keep track of number of each type
    public FoodTypeCount[] foods;

    private void Start()
    {
        // Setup food counters
        int count = levelFoodTypes.Length;
        foods = new FoodTypeCount[count];
        for(int i = 0; i < count; i++)
        {
            foods[i].type = levelFoodTypes[i];
        }
        // SPAWN FOODS
        foreach(GameObject go in levelFoodPrefabs)
        {
            GameObject.Instantiate(go, GetRespawnPoint(), Quaternion.identity);
        }

        // Setup counts to be offset - Evan
        int offset = 0;
        FoodTypeCount[][] inputs = new FoodTypeCount[recipes.Length][];
        for(int i = 0; i < recipes.Length; i++)
        {
            inputs[i] = recipes[i].input;
        }
        
        foreach(FoodType f in levelFoodTypes)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                for (int j = 0; j < inputs[i].Length; j++)
                {
                    if(inputs[i][j].type == f)
                    {
                        int old = inputs[i][j].count;
                        inputs[i][j].count += offset;
                        offset += old;
                    }
                }
            }
            offset = 0;
        }     
            
        
    }

    private Vector3 GetRespawnPoint()
    {
        Transform t = GameObject.Find("Respawn Points Parent").transform;
        int selectedChild = Random.Range(0, t.childCount);
        return t.GetChild(selectedChild).position;
    }

    public void AddFood(FoodType type)
    {
        for(int i = 0; i < foods.Length; i++)
        {
            if (foods[i].type == type)
            {
                foods[i].count++;
            }
        }
        for(int i = 0; i < recipes.Length; i++)
        {
            if(!recipes[i].completed)
            {
                if(IsRecipeDone(i))
                {
                    recipes[i].completed = true;
                    Debug.Log("Recipe Complete: " + recipes[i].recipeName);
                    if(CheckAllDone())
                    {
                        GetComponent<Transition>().ChangeLevel();
                    }
                }
            }
        }
    }

    private bool CheckAllDone()
    {
        foreach(Recipe r in recipes)
        {
            if(!r.completed)
            {
                return false;
            }
        }
        return true;
    }

    private bool IsRecipeDone(int recipeNum)
    {
        for (int j = 0; j < foods.Length; j++)
        {
            for (int i = 0; i < recipes[recipeNum].input.Length; i++)
            {
                if(foods[j].type != recipes[recipeNum].input[i].type)
                {
                    continue;
                }
                if (!IsEnoughFood(recipes[recipeNum].input[i], foods[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsEnoughFood(FoodTypeCount recipeInput, FoodTypeCount currentFood)
    {
        return currentFood.count >= recipeInput.count;
    }
}

[System.Serializable]
public struct Recipe
{
    public FoodTypeCount[] input;
    public string recipeName;
    public bool completed;
}

[System.Serializable]
public struct FoodTypeCount
{
    public FoodType type;
    public int count;
}

public enum FoodType
{
    Onion,
    Tomato,
    Pepper,
    Egg,
    Flour,
    Butter
}