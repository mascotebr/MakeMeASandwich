using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour
{
    public List<GameObject> ingredientsStatic = new List<GameObject>();
    public List<Ingredient> ingredients = new List<Ingredient>();
    public List<Transform> pos = new List<Transform>();

    [Header("HUD")]
    public TextMeshProUGUI nomeText;
    public void OnStart(List<GameObject> newIngredients, string nome)
    {
        nomeText.text = nome;
        foreach (GameObject i  in newIngredients)
        {
            ingredients.Add(i.GetComponent<Ingredient>());
        }
        for (int i = 0; i < ingredients.Count; i++)
        {
            Instantiate(ingredientsStatic[ingredients[i].index], pos[i]);
        }
    }
}
