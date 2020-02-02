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
    public enum LevelName  {OpeningScene, TutorialScene, Scene1, Scene2, Scene3, EndScene}
    List<string> LevelLoadText = new List<string>()
    {
        "",
        "MEET",
        "TIME",
        "OATH",
        "MEND",
        "I miss you. Please come back."
    };
    LevelName CurrentLevelName;
    // Start is called before the first frame update

    ScenePassThroughData scenePassThroughDataRef;

    void Start()
    {
        scenePassThroughDataRef = GameObject.FindGameObjectWithTag("ScenePassThroughData").GetComponent<ScenePassThroughData>();

        CurrentLevelName = (LevelName)scenePassThroughDataRef.levelNum;

        imageToFade.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Message.text = levelText;

        imageToFade.gameObject.SetActive(true);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(levelToLoad.ToString());
    }
    //void Lose()
    //{
    //    DialogueBox.color = new Color(0, 0, 0, 0);
    //    ColourChange.a += 0.01f;
    //    WaitTime += Time.deltaTime;
    //    TextboxColourChange.a += 0.1f;
    //    GetComponent<Image>().color = ColourChange;
    //    Message.text = "You got lost in your memories...";
    //    if (WaitTime > 5) { SceneManager.LoadScene(LevelIndex.ToString()); }
    //}
    //void Win()
    //{
    //    DialogueBox.color = new Color(0, 0, 0, 0);
    //    WaitTime += Time.deltaTime;
    //    ColourChange.a += 0.01f;
    //    TextboxColourChange.a += 0.1f;
    //    GetComponent<Image>().color = ColourChange;
    //    Message.text = "I miss you. Please come back.";
    //    if (WaitTime > 5) { SceneManager.LoadScene("Ending"); }
    //}
    //void SceneChanger()
    //{
    //    switch (LevelIndex)
    //    {
    //        case LevelList.Tutorial:
    //            SceneManager.LoadScene("Tutorial");
    //            break;
    //        case LevelList.Main:
    //            SceneManager.LoadScene("Main");
    //            break;
    //    }
    //}
}
