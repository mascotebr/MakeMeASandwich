using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    RaycastHit hit;
    Ray r;
    GameObject catched;
    void Update()
    {
        r = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(r.origin, r.direction * Mathf.Infinity, Color.red, 100, true);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Click();
    }

    private void Click()
    {

        if (Physics.Raycast(r, out hit))
        {
            if (!catched)
            {

                switch (hit.transform.name)
                {
                    case "BoxCheese":
                        catched = Instantiate(GameManager.instance.ingredients[0], Input.mousePosition, Quaternion.identity);

                        break;
                    case "BoxSalame":
                        catched = Instantiate(GameManager.instance.ingredients[1], Input.mousePosition, Quaternion.identity);

                        break;
                    case "BoxTomate":
                        catched = Instantiate(GameManager.instance.ingredients[2], Input.mousePosition, Quaternion.identity);

                        break;
                    case "BoxSalad":
                        catched = Instantiate(GameManager.instance.ingredients[3], Input.mousePosition, Quaternion.identity);

                        break;
                    case "BoxBacon":
                        catched = Instantiate(GameManager.instance.ingredients[4], Input.mousePosition, Quaternion.identity);

                        break;


                }
            }

            if (hit.transform.tag == "Sandwich" && catched)
            {
                hit.transform.GetComponent<SandwichDisplay>().PutIngredient(catched);
                Destroy(catched);
            }
        }
    }
}
