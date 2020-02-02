using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningSceneController : MonoBehaviour
{
    public Canvas openingSceneCanvas;
    public TMP_InputField NameInputField;
    public Button startButton;
    ScenePassThroughData scenePassThroughDataRef;

    public ScreenFade screenFadeRef;
    // Start is called before the first frame update
    void Start()
    {
        scenePassThroughDataRef = ScenePassThroughData.GetData();
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
            openingSceneCanvas.gameObject.SetActive(false);

            scenePassThroughDataRef.playerName = NameInputField.text;
            screenFadeRef.loadNextLevel();
            //SceneManager.LoadScene("TutorialScene");
        }
        else
        {
            NameInputField.text = errorMessage;
        }
    }
}
