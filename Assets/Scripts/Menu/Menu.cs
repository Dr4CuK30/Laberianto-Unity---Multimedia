using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button exitButton;
    public Button startButton;
    private void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            print("click");
            SceneManager.LoadScene("Level1");
        });
    }


}
