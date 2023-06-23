using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int index = 0;
    public GameObject ingredientStatic;
    public Vector3 offset = new Vector3(0,10,1.6f);
    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+offset.x, Input.mousePosition.y+offset.y, offset.z));
    }
}
