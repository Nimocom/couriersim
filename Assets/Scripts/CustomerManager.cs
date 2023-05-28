using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance;
    [SerializeField] Customer customerPrefab;
    public string[] Names;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadNames();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNames()
    {
        Names = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "Names.txt"));
    }

    public CustomerData GetCustomer()
    {
        CustomerData customerData = new CustomerData()
        {
            Name = Names[Random.Range(0, Names.Length)],
            Nature = (Customer.NatureType)Random.Range(0, 2),
            Address = AddressManager.Instance.GetAddress(),
            Rating = Random.Range(3, 6)
        };

        return customerData;
    }

    public Customer CreateCustomerModel(CustomerData customerData, Order order)
    {
        var customer = Instantiate(customerPrefab, customerData.Address.transform.position, customerData.Address.transform.rotation);
        customer.CustomerOrder = order;
        customer.Nature = customerData.Nature;
        return customer;
    }
}

[System.Serializable]
public class CustomerData
{
    public string Name { get; set; }
    public Customer.NatureType Nature { get; set; }

    public AddressPoint Address { get; set; }
    public float Rating { get; set; }

}