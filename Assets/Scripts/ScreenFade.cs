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
    PlayerController playerControllerRef;
    void Start()
    {

        scenePassThroughDataRef = ScenePassThroughData.GetData();
        imageToFade.gameObject.SetActive(false); 
    }

    public void loadNextLevel()
    {
        //playerControllerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //playerControllerRef.playerDead();
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
        //playerControllerRef.playerDead();
        SceneManager.LoadScene(levelToLoad.ToString());
    }

}
