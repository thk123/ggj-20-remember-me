using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScreenFade : MonoBehaviour
{
    public Image imageToFade;
    public Image DialogueBox;
    public TextMeshProUGUI Message;

    public Image LastLevelDialogueBox;
    public TextMeshProUGUI LastLevelMessage;
    public enum LevelName  {OpeningScene, TutorialScene, MainScene1, MainScene2, MainScene3, CreditsScene}
    List<string> LevelLoadText = new List<string>()
    {
        "",
        "MEET",
        "TIME",
        "OATH",
        "MEND",
        "I miss you. Please come back."
    };

    ScenePassThroughData scenePassThroughDataRef;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("ScenePassThroughData"))
        {
            scenePassThroughDataRef = GameObject.FindGameObjectWithTag("ScenePassThroughData").GetComponent<ScenePassThroughData>();
        }
        else
        {
            Debug.LogWarning("Could not find level data, so falling back to always loading level 2 if you die.");
            scenePassThroughDataRef = new ScenePassThroughData();
            scenePassThroughDataRef.levelNum = 2;
        }

        imageToFade.gameObject.SetActive(false); 
    }

    public void loadNextLevel()
    {
        scenePassThroughDataRef.levelNum += 1;
        StartCoroutine(loadLevel(LevelLoadText[scenePassThroughDataRef.levelNum]));
    }

    public void loadCurrentLevelBecauseDead()
    {
        StartCoroutine(loadLevel("You got lost in your memories..."));
    }

    IEnumerator loadLevel(string levelText)
    {
        LevelName levelToLoad = (LevelName)scenePassThroughDataRef.levelNum;

        if(levelToLoad == LevelName.CreditsScene)
        {
            DialogueBox.gameObject.SetActive(false);
            LastLevelDialogueBox.gameObject.SetActive(true);
            LastLevelMessage.text = levelText;
        }
        else
        {
            DialogueBox.gameObject.SetActive(true);
            LastLevelDialogueBox.gameObject.SetActive(false);
            Message.text = levelText;
        }

        imageToFade.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(levelToLoad.ToString());
    }

}
