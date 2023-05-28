using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProductManager : MonoBehaviour
{
    public static ProductManager Instance;

    public List<Product> products;

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

    public List<ProductData> GetProductsList()
    {
        int amount = Random.Range(2, 6);

        List<Product> newList = new List<Product>();

        for (int i = 0; i < amount; i++)
        {
            var product = products[Random.Range(0, products.Count)];

            if (!newList.Contains(product))
            {
                newList.Add(product);
            }  
        }
        List<ProductData> dataList = new List<ProductData>();

        for (int i = 0; i < newList.Count; i++)
        {
            dataList.Add(new ProductData() { ProductToBuy = newList[i], Amount = Random.Range(1, 5) });
        }


        var ordered = dataList.OrderBy(x => x.ProductToBuy.ShopID);
        return ordered.ToList();
    }

    public Product GetProductByID(int id)
    {
        return products.SingleOrDefault(x => x.ID == id);
    }
}