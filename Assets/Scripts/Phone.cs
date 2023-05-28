using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public static Phone Instance;
    public Order SelectedOrder;
    public Order AcceptedOrder;
    new Animation animation;

    [SerializeField] TextMeshProUGUI currentTime;
    [SerializeField] Transform ordersContent;
    [SerializeField] OrderPanel orderPanelPrefab;
    [SerializeField] ProductPanel productPanelPrefab;

    [SerializeField] GameObject detailsWindow;
    [SerializeField] GameObject mainWindow;

    [SerializeField] Transform productListContent;

    public bool IsActive { get; set; }

    [SerializeField] Button acceptButton;

    private void Awake()
    {
        Instance = this;
        animation = GetComponent<Animation>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime.SetText(DateTime.Now.ToString("HH:mm"));
    }

    public void ShowPhone()
    {
        IsActive = !IsActive;

        animation.Play(IsActive ? "PhoneShow" : "PhoneHide");
    }

    public void RefreshOrders(List<Order> orders)
    {
        for (int i = 0; i < ordersContent.childCount; i++)
        {
            Destroy(ordersContent.GetChild(i).gameObject);
        }

        for (int i = 0; i < orders.Count; i++)
        {
           var panel = Instantiate(orderPanelPrefab, ordersContent);
            panel.InitializePanel(orders[i]);
        }
    }

    public void ShowDetails(Order order)
    {
        mainWindow.SetActive(false);
        detailsWindow.SetActive(true);

        for (int i = 0; i < productListContent.childCount; i++)
        {
           Destroy(productListContent.GetChild(i).gameObject);
        }

        for (int i = 0; i < order.Products.Count; i++)
        {
            var panel = Instantiate(productPanelPrefab, productListContent);
            panel.InitializePanel(order.Products[i]);
        }

        SelectedOrder = order;
    }

    public void ShowOrdersWindow()
    {
        if (AcceptedOrder != null)
            return;

        mainWindow.SetActive(true);
        detailsWindow.SetActive(false);
        SelectedOrder = null;
    }

    public void AcceptOrder()
    {
        SelectedOrder.isAccepted = true;
        AcceptedOrder = SelectedOrder;
        acceptButton.interactable = false;

       var customer = CustomerManager.Instance.CreateCustomerModel(AcceptedOrder.Customer, AcceptedOrder);

        Arrow.Instance.ShowArrow(customer.transform);
    }

    public void Unlock()
    {
        acceptButton.interactable = true;
        AcceptedOrder = null;
    }
}
