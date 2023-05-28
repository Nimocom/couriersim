using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProductPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI productName;
    [SerializeField] TextMeshProUGUI amount;
    [SerializeField] TextMeshProUGUI shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializePanel(ProductData productData)
    {
        productName.SetText(productData.ProductToBuy.Name);
        amount.SetText(productData.Amount.ToString() + " " + productData.ProductToBuy.Unit);
        shop.SetText(ShopsManager.Instance.GetShopByID(productData.ProductToBuy.ShopID));
    }
}
