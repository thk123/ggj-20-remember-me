using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string DialogueFileNameEditor;

    DialogueController DialogueControllerRef;
    DialogueData DialogueDataRef;
    string CurrentEventRef;

    int CurrentSentence;

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
    }

    void GetReferences()
    {
        DialogueControllerRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueController>();
        TextAsset jsonDialogueTextFile = Resources.Load<TextAsset>("CharacterDialogue/" + DialogueFileNameEditor);
        DialogueDataRef = JsonUtility.FromJson<DialogueData>(jsonDialogueTextFile.text);
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

        DialogueControllerRef.DisplayDialogue(DialogueDataRef.Dialogue[CurrentSentence]);
        CurrentSentence += 1;
    }
}





