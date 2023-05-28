using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddressManager : MonoBehaviour
{
    public static AddressManager Instance;

    public List<AddressPoint> AddressPoints;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddressPoints = FindObjectsByType<AddressPoint>(FindObjectsSortMode.None).ToList();
    }

    public AddressPoint GetAddress()
    {
        return AddressPoints[Random.Range(0, AddressPoints.Count)];
    }
}
