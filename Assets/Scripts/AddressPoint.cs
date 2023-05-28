using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressPoint : MonoBehaviour
{
    public string StreenName;

    public int House;
    public int Apartment;

    private void Awake()
    {
        Apartment = Random.Range(1, 100);
    }
}
