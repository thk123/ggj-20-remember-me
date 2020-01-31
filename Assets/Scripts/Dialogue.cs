using Newtonsoft.Json;
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
        CurrentEventRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetCurrentEvent();

        TextAsset jsonDialogueTextFile = Resources.Load<TextAsset>("CharacterDialogue/" + DialogueFileNameEditor);
        DialogueDataRef = JsonConvert.DeserializeObject<DialogueData>(jsonDialogueTextFile.text);
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

        DialogueControllerRef.DisplayDialogue(DialogueDataRef.Name, DialogueDataRef.Dialogue[CurrentSentence]);
        CurrentSentence += 1;
    }
}





