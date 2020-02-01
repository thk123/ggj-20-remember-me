using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI NameTextEditor;
    public TextMeshProUGUI DialogueTextEditor;
    public Animator AnimatorEditor;

    public void OpenDialogue()
    {
        AnimatorEditor.SetBool("IsDialogueOpen", true);
    }

    public void CloseDialogue()
    {
        AnimatorEditor.SetBool("IsDialogueOpen", false);
    }

    public void DisplayDialogue(string name, string sentence)
    {
        NameTextEditor.text = name;
        StopAllCoroutines();
        StartCoroutine(AnimateSentence(sentence));
    }

    IEnumerator AnimateSentence(string sentence)
    {
        DialogueTextEditor.text = "";
        foreach(char c in sentence.ToCharArray())
        {
            DialogueTextEditor.text += c;
            yield return null;
        }

    }
}
