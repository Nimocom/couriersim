using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Order
{
    public bool isAccepted;

    public CustomerData Customer;
    public float OrderTime;

    public List<ProductData> Products;
}

[Serializable]
public class ProductData
{
    public Product ProductToBuy;
    public float Amount;

    public override bool Equals(object obj)
    {
        ProductData data = (ProductData)obj;
        return ProductToBuy.ID == data.ProductToBuy.ID;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}