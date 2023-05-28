using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Animations.Rigging;

public class Customer : MonoBehaviour
{
    public Order CustomerOrder;

    [SerializeField] AudioClip angry;
    [SerializeField] AudioClip happy;
    [SerializeField] AudioClip sad;

    AudioSource audioSource;

    public Transform headTarget;

    public Rig HeadRig;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    public enum NatureType
    {
        Kind,
        Neutral,
        Angry
    }

    public NatureType Nature;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckOrder(List<ProductData> products)
    {
        for (int i = 0; i < CustomerOrder.Products.Count; i++)
        {
            if (!products.Contains(CustomerOrder.Products[i]))
            {
                React(false);
                return;
            }

            var prod = products[products.IndexOf(CustomerOrder.Products[i])];
            if (prod.Amount != CustomerOrder.Products[i].Amount)
            {
                React(false);
                return;
            }

        }

        React(true);
    }

    void React(bool isHappy)
    {
        audioSource.clip = isHappy ? happy : angry;
        audioSource.Play();

        if (isHappy)
            Player.Instance.AddMoney(CustomerOrder.Products.Count * 300);
        else
            Player.Instance.RemoveMoney(CustomerOrder.Products.Count * 100);

        Arrow.Instance.HideArrow();
        Phone.Instance.Unlock();
    }
}
