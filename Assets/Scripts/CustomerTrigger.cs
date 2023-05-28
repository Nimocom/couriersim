using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{
    PlayerInput player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("sdsd");
        player.OnCustomerMet(other.GetComponent<Customer>());
    }

    private void OnTriggerExit(Collider other)
    {
        player.OnCustomerLost(other.GetComponent<Customer>());
    }
}
