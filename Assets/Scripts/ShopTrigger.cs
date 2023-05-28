using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShopTrigger : MonoBehaviour
{
    Player player;

    public int productID;

    public int ShopID;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Phone.Instance.AcceptedOrder == null)
            return;

        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            if (Phone.Instance.AcceptedOrder.Products.Any(x=>x.ProductToBuy.ShopID == ShopID))
                player.AddToBin(new ProductData() { ProductToBuy = ProductManager.Instance.GetProductByID(productID), Amount = 1 });
        }
    }
}
