using UnityEngine;

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

        DialogueControllerRef.DisplayDialogue(characterName, DialogueDataRef.Dialogue[CurrentSentence]);
        CurrentSentence += 1;
    }
}





