using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool isStarted;
    [SerializeField] GameObject loadingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (isStarted)
            return;

        isStarted = true;

        SceneManager.LoadSceneAsync(1);
        loadingText.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
