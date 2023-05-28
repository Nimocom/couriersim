using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI binText;
    [SerializeField] GameObject interactionHint;
    [SerializeField] TextMeshProUGUI money;
    [SerializeField] Slider stamina;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnProductAdded.AddListener(OnRefresh);
        Player.Instance.OnCleared.AddListener(OnRefresh);
        Player.Instance.OnMoneyChanged.AddListener(OnMoneyChanged);
    }

    // Update is called once per frame
    void Update()
    {
        stamina.value = Player.Instance.GetStamina();


    }

    public void OnRefresh()
    {
        string list = "";
        var bin = Player.Instance.bin;

        for (int i = 0; i < Player.Instance.bin.Count; i++)
        {
            list += bin[i].ProductToBuy.Name + " - " + bin[i].Amount + " " + bin[i].ProductToBuy.Unit + System.Environment.NewLine;
        }

        binText.SetText(list);
    }

    public void SetInteractionHint(bool isActive)
    {
        interactionHint.SetActive(isActive);
    }

    void OnMoneyChanged(int money)
    {
        this.money.SetText(money.ToString());
    }
}
