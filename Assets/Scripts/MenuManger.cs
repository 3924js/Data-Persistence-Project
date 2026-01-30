using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManger : MonoBehaviour
{
    private Button StartButton;
    private Button QuitButton;
    private TMP_InputField NameInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartButton = GameObject.Find("StartButton").GetComponent<Button>();
        QuitButton = GameObject.Find("QuitButton").GetComponent<Button>();
        NameInput = GameObject.Find("NameField").GetComponent<TMP_InputField>();
        StartButton.onClick.AddListener(StartNew);
        QuitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartNew()
    {
        PlayerData.Instance.PlayerName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif

    }


}
