using System;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dialogue : MonoBehaviour
{
    public string DialogueFileNameEditor;
    public string CharacterNamesFileNameEditor;
    public string CharacterName;

    DialogueController DialogueControllerRef;
    DialogueData DialogueDataRef;
    CharacterNamesData CharacterNamesDataRef;
    string CurrentEventRef;

    int CurrentSentence;
    ScenePassThroughData scenePassThroughDataRef;


    private bool PrintGibberish = true;

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
        scenePassThroughDataRef = GameObject.FindGameObjectWithTag("ScenePassThroughData").GetComponent<ScenePassThroughData>();

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
        else if (CurrentSentence == DialogueDataRef.Dialogue.Count)
        {
            DialogueControllerRef.CloseDialogue();
            CurrentSentence = 0;
            return;
        }
        
        var characterName = CharacterNamesDataRef.CharacterName[CurrentSentence];
        if (CharacterNamesDataRef.CharacterName[CurrentSentence] == "???")
        {
            characterName = scenePassThroughDataRef.playerName;
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





