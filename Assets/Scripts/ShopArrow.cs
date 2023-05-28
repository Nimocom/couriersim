using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopArrow : MonoBehaviour
{
    [SerializeField] Transform target;

    Camera arrowCamera;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] float offset;

    // Start is called before the first frame update
    void Start()
    {
        arrowCamera = transform.parent.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        nameText.transform.position = arrowCamera.WorldToScreenPoint(transform.position) + Vector3.down * offset;
        transform.rotation = Quaternion.LookRotation(target.position - Player.Instance.transform.position);
    }
}
