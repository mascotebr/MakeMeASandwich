using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;

    [Header("Objects")]
    public GameObject sandwichObj;
    public List<Sandwich> sandwichs = new List<Sandwich>();
    public List<GameObject> ingredients = new List<GameObject>();
    public GameObject order;
    Order actualOrder;
    public Transform posPlate;

    [Header("HUD")]
    public GameObject posOrder;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;

    [Header("Objetives")]
    public int points = 0;
    float time = 120;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        NextSandwich();
        timeText.gameObject.SetActive(true);
        InvokeRepeating("TimeUpdate", 0f, 1f);
    }

    public void ReadySandwich(SandwichDisplay s)
    {
        int isCorrect = 0;

        for (int i = 0; i < 3 ; i++)
        {
            if (actualOrder.ingredients.Any(ing => ing.index == s.ingredients[i].index))
            {
                isCorrect += 1;
                actualOrder.ingredients.RemoveAt(actualOrder.ingredients.FindIndex(a => a.index == s.ingredients[i].index));
            }

        }

        if (isCorrect == 3)
            AddPoints(10);
        else
        {
            audioSource.Play();
            AddPoints(-10);
        }

        Destroy(actualOrder.gameObject);
        NextSandwich();
    }

    void AddPoints(int p)
    {
        points += p;
        pointsText.text = points.ToString();
    }
    public void NextSandwich()
    {
        Sandwich sandwichChoose = sandwichs[UnityEngine.Random.Range(0, sandwichs.Count)];
        actualOrder = Instantiate(order, posOrder.transform).GetComponent<Order>();
        actualOrder.OnStart(sandwichChoose.ingredientsOrder, sandwichChoose.nome);

        Instantiate(sandwichObj, posPlate).GetComponent<SandwichDisplay>().sandwich = sandwichChoose;
    }

    void TimeUpdate()
    {
        time -= 1;
        timeText.text = time + " seg";
        if(time == 0)
            timeText.gameObject.SetActive(false);
    }
}
