using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class OrderPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Order order;

    [SerializeField] TextMeshProUGUI customer;
    [SerializeField] TextMeshProUGUI addressPoint;
    [SerializeField] TextMeshProUGUI rating;
    [SerializeField] TextMeshProUGUI amount;

    [SerializeField] List<Product> products;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializePanel(Order order)
    {
        customer.SetText(order.Customer.Name);
        addressPoint.SetText(order.Customer.Address.StreenName + ", " + order.Customer.Address.Apartment);
        rating.SetText(order.Customer.Rating.ToString());
        amount.SetText("Количество продуктов: " + order.Products.Count.ToString());

        this.order = order;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Phone.Instance.ShowDetails(order);
    }
}
