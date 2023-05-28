using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{
    public static Arrow Instance;

    Transform target;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        transform.rotation = Quaternion.LookRotation(target.position - Player.Instance.transform.position);

    }

    public void ShowArrow(Transform target)
    {
        gameObject.SetActive(true);
        this.target = target;
    }

    public void HideArrow()
    {
        gameObject.SetActive(false);
    }
}
