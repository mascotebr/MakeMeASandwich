using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SandwichDisplay : MonoBehaviour
{
    public Sandwich sandwich;
    Animator anim;
    public GameObject bread;
    public Transform pointIngredient;
    public List<Ingredient> ingredients = new List<Ingredient>();

    AudioSource audioSource;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void PutIngredient(GameObject ingredient)
    {
        ingredients.Add(ingredient.GetComponent<Ingredient>());

        if (ingredients.Count > 0)
            Instantiate(ingredient.GetComponent<Ingredient>().ingredientStatic, pointIngredient).transform.Translate(new Vector3(0, 0.025f * (ingredients.Count + 1), 0));

        if(ingredients.Count == 3)
        {
            Instantiate(bread, pointIngredient).transform.localPosition = new Vector3(0, 0.1f, 0);
            audioSource.Play();
            anim.SetTrigger("finish");
        }
    }

    public void Finish()
    {
        GameManager.instance.ReadySandwich(this);
        Destroy(gameObject);

    }
}
