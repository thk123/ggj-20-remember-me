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


    public bool PrintGibberish = true;
    private string playerName;

    private Material[] materialsOriginal;
    private Material[] materialsToChange;


    void Awake()
    {
        Debug.Log("Dialogue: " + gameObject.name);
        InitializeState();
        startcolor = GetComponent<Renderer>().material.color;
        materialsOriginal = GetComponent<Renderer>().materials;
        materialsToChange = GetComponent<Renderer>().materials;
    }
    void Start()
    {
        GetReferences();
    }

    void OnMouseDown()
    {
        ChangeDialogueOnClick();
    }

    Color startcolor;
    Color OnHovercolor = Color.cyan;
    Color OnHovercolor1 = Color.red;
    void OnMouseEnter()
    {
        print("OnMouseEnter");
        Cursor.visible = true;
        float value = 1.5f;
        foreach (Material material in materialsToChange)
        {
            material.SetColor("_TColor", new Color(value, value, value));
        }
        //GetComponent<Renderer>().material.color = OnHovercolor;
    }
    void OnMouseExit()
    {
        print("OnMouseExit");
        Cursor.visible = false;
        int i = 0;
        foreach (Material material in materialsToChange)
        {
            material.SetColor("_TColor", new Color(1f, 1f, 1f));
            i++;
        }
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

        var DialogueLine = DialogueDataRef.Dialogue[CurrentSentence];
        string replacement;
        string trueSentence = DialogueDataRef.Dialogue[CurrentSentence];
        if (DialogueLine.Contains("Player_Name"))
        {
            replacement = DialogueLine.Replace("Player_Name", playerName);
            trueSentence = replacement;
        }

        
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





