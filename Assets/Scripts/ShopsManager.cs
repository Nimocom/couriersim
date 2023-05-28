using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopsManager : MonoBehaviour
{
    public static ShopsManager Instance;

    public List<ShopData> Shops;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetShopByID(int id)
    {
        for (int i = 0; i < Shops.Count; i++)
        {
            if (Shops[i].ShopID == id)
                return Shops[i].ShopName;
        }

        return "Не указано";
    }
}

[System.Serializable]
public class ShopData
{
    public int ShopID;
    public string ShopName;
}