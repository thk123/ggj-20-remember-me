using System;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dialogue : MonoBehaviour
{
    public string DialogueFileNameEditor;
    public string CharacterNamesFileNameEditor;

    DialogueController DialogueControllerRef;
    DialogueData DialogueDataRef;
    CharacterNamesData CharacterNamesDataRef;
    string CurrentEventRef;

    int CurrentSentence;
    public ScreenFade screenFadeRef;


    private bool PrintGibberish = true;
    private string playerName;

    void Awake()
    {
        InitializeState();
    }
    void Start()
    {
        GetReferences();
    }

    void OnMouseDown()
    {
        ChangeDialogueOnClick();
    }

    void InitializeState()
    {
        CurrentSentence = 0;
        GameObject passthroughData = GameObject.FindGameObjectWithTag("ScenePassThroughData");
        if(passthroughData != null)
        {
            playerName = passthroughData.GetComponent<ScenePassThroughData>().playerName;
        }
        else
        {
            playerName = "Charlie";
            Debug.LogWarning("No passthrough data found... player name will be default");
        }
    }

    public void DisableGibberish()
    {
        PrintGibberish = false;
    }

    void GetReferences()
    {
        DialogueControllerRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueController>();
        TextAsset jsonDialogueTextFile = Resources.Load<TextAsset>("CharacterDialogue/" + DialogueFileNameEditor);
        DialogueDataRef = JsonUtility.FromJson<DialogueData>(jsonDialogueTextFile.text);
        TextAsset jsonCharacterNamesTextFile = Resources.Load<TextAsset>("CharacterNames/" + CharacterNamesFileNameEditor);
        CharacterNamesDataRef = JsonUtility.FromJson<CharacterNamesData>(jsonCharacterNamesTextFile.text);
    }

    void ChangeDialogueOnClick()
    {
        if (CurrentSentence == 0)
        {
            DialogueControllerRef.OpenDialogue();
        }
        else if (CurrentSentence == DialogueDataRef.Dialogue.Count || (PrintGibberish && CurrentSentence >= 3))
        {
            if (!PrintGibberish)
            {
                screenFadeRef.loadNextLevel();

            }
            DialogueControllerRef.CloseDialogue();
            CurrentSentence = 0;
            return;
        }
        
        var characterName = CharacterNamesDataRef.CharacterName[CurrentSentence];
        if (CharacterNamesDataRef.CharacterName[CurrentSentence] == "Player_Initial")
        {
            characterName = playerName[0] + "...";
        }
        else if(CharacterNamesDataRef.CharacterName[CurrentSentence] == "Player_Name")
        {
            characterName = playerName;

        }

        string trueSentence = DialogueDataRef.Dialogue[CurrentSentence];
        string sentence = PrintGibberish ? gibberish(trueSentence.Length) : trueSentence;

        string name = PrintGibberish ? gibberish(characterName.Length) : characterName;

        DialogueControllerRef.DisplayDialogue(name, sentence);

        CurrentSentence += 1;
    }

    String gibberish(int length)
    {
        StringBuilder sb = new StringBuilder(length);
        for (int i = 0; i < length; ++i)
        {
            char randomChar = (char) Random.Range(32, 127);
            sb.Append(randomChar);
        }    

        return sb.ToString();
    }
}





