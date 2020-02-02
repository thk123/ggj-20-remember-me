using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScreenFade : MonoBehaviour
{
    public bool FadeBool;
    Color ColourChange;
    Color TextboxColourChange;
    private float WaitTime;
    public bool EndingSequence;
    public bool ChangeScene;

    //GameObject DialogueBox;
    public Image DialogueBox;
    public TextMeshProUGUI Message;
    public enum LevelList  {Tutorial, Main}
    LevelList LevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScene = false;
        FadeBool = false;
        EndingSequence = false;
        LevelIndex = LevelList.Tutorial;
        ColourChange = GetComponent<Image>().color;
        //TextboxColourChange = DialogueBox.color;
        WaitTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeBool == true)
        {
            if (EndingSequence == true)
            {
                Win();
            }
            else if (EndingSequence != true)
            {
                Lose();
            }
        }
        if (ChangeScene == true) { }
    }
    void Lose()
    {
        DialogueBox.color = new Color(0,0,0,0);
        ColourChange.a += 0.01f;
        WaitTime += Time.deltaTime;
        TextboxColourChange.a += 0.1f;
        GetComponent<Image>().color = ColourChange;
        Message.text = "You got lost in your memories...";
        if (WaitTime > 5) { SceneManager.LoadScene(LevelIndex.ToString()); }
    }
    void Win()
    {
        DialogueBox.color = new Color(0, 0, 0, 0);
        WaitTime += Time.deltaTime;
        ColourChange.a += 0.01f;
        TextboxColourChange.a += 0.1f;
        GetComponent<Image>().color = ColourChange;
        Message.text = "I miss you. Please come back.";
        if (WaitTime > 5) { SceneManager.LoadScene("Ending"); }
    }
    void SceneChanger()
    {
        switch (LevelIndex)
        {
            case LevelList.Tutorial:
                SceneManager.LoadScene("Tutorial");
                break;
            case LevelList.Main:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
