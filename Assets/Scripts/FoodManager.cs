using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    // Recipes to be made
    public Recipe[] recipes;

    // Foods required to spawn in the map
    public FoodType[] levelFoodTypes;

    // food counter to keep track of number of each type
    private FoodTypeCount[] foods;

    private void Start()
    {
        int count = levelFoodTypes.Length;
        foods = new FoodTypeCount[count];
        for(int i = 0; i < count; i++)
        {
            foods[i].type = levelFoodTypes[i];
        }
        // SPAWN FOODS
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
                    Debug.Log("Recipe Complete: " + recipes[i].foodName);
                }
            }
        }
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
                    Debug.Log("Not Enough of: " + System.Enum.GetName(typeof(FoodType), foods[j].type));
                    return false;
                }
            }
        }
        return true;
    }

    private bool IsEnoughFood(FoodTypeCount recipeInput, FoodTypeCount currentFood)
    {
        return currentFood.count >= recipeInput.count;
    }
}

[System.Serializable]
public struct Recipe
{
    public FoodTypeCount[] input;
    public string foodName;
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
    None,
    Onion,
    Tomato,
    Pepper
}