using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningSceneController : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public Button startButton;
    ScenePassThroughData scenePassThroughDataRef;
    // Start is called before the first frame update
    void Start()
    {
        scenePassThroughDataRef = GameObject.FindGameObjectWithTag("ScenePassThroughData").GetComponent<ScenePassThroughData>();
        startButton.onClick.AddListener(startTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startTutorial()
    {
        string errorMessage = "Name must be at least 5 characters";
        if(NameInputField.text.Length > 5 && NameInputField.text != errorMessage)
        {
            scenePassThroughDataRef.playerName = NameInputField.text;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            NameInputField.text = errorMessage;
        }
    }
}
