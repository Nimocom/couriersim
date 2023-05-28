using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Player : Human
{
    public UnityEvent<int> OnMoneyChanged;

    public static Player Instance;

    public UnityEvent OnProductAdded;
    public UnityEvent OnCleared;

    public int Money;
    public float Exp;

    [SerializeField] 

    public List<ProductData> bin;


    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public void ClearBin()
    {
        bin.Clear();
        OnCleared.Invoke();
    }

    public void AddToBin(ProductData productData)
    {
        var product = productData.ProductToBuy;
        var existing = bin.SingleOrDefault(x => x.ProductToBuy.ID == productData.ProductToBuy.ID);

        if (existing != null)
        {
            existing.Amount++;
        }
        else
            bin.Add(productData);

        OnProductAdded.Invoke();
    }

    protected override void Update()
    {
        base.Update();


    }

    public void AddMoney(int money)
    {
        Money += money;
        OnMoneyChanged.Invoke(Money);
    }

    public void RemoveMoney(int money)
    {
        Money -= money;
        OnMoneyChanged.Invoke(Money);
    }

}
