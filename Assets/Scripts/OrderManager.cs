using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> Orders;

    [SerializeField] float minRefresgingTime, maxRefreshingTime;
    [SerializeField] float refreshingTimer;

    [SerializeField] float refreshingTime;

    [SerializeField] int maxOrders;

    private void Awake()
    {
        Orders = new List<Order>();
    }

    // Start is called before the first frame update
    void Start()
    {
        refreshingTime = Random.Range(minRefresgingTime, maxRefreshingTime);
    }

    // Update is called once per frame
    void Update()
    {
        refreshingTimer += Time.deltaTime;

        if (refreshingTimer > refreshingTime)
        {
            refreshingTimer = 0f;
            refreshingTime = Random.Range(minRefresgingTime, maxRefreshingTime);

            if (Orders.Count >= maxOrders)
                return;

            Order order = new Order()
            {
                Customer = CustomerManager.Instance.GetCustomer(),
                OrderTime = Random.Range(15f, 60f),
                Products = ProductManager.Instance.GetProductsList(),
            };

            StartCoroutine(RemoveOrder(order, order.OrderTime));

            Orders.Add(order);


            Phone.Instance.RefreshOrders(Orders);
        }
    }

    IEnumerator RemoveOrder(Order order, float time)
    {
        yield return new WaitForSeconds(time);

        if (!order.isAccepted)
            Orders.Remove(order);

        Phone.Instance.RefreshOrders(Orders);
    }
}
