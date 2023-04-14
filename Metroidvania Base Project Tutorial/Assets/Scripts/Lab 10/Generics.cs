using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generics : MonoBehaviour
{
    private int[] intArr = { 1, 2, 3 };
    private float[] floatArr = { 1.1f, 2.2f, 3.3f };
    private string[] strArr = { "Aa", "Bb", "Cc" };

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            DisplayElements(intArr);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            DisplayElements(floatArr);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            DisplayElements(strArr);
        }
    }

    // We can use generics to have a single method which can accept any data type
    public void DisplayElements<Type>(Type[] arr) 
    {
        foreach (Type type in arr) {
            print(type);
        }
    }
}
