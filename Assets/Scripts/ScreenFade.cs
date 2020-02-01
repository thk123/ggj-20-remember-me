using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenFade : MonoBehaviour
{
    public bool FadeBool;
    Color ColourChange;
    Color TextboxColourChange;
    private float WaitTime;
    public Image DialogueBox;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        FadeBool = false;
        ColourChange = GetComponent<Image>().color;
        TextboxColourChange = DialogueBox.color;
        WaitTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeBool == true)
        {
            ColourChange.a += 0.01f;
            //TextboxColourChange.a += 0.1f;
            GetComponent<Image>().color = ColourChange;
            //Text.color = ColourChange;
            //DialogueBox.color = TextboxColourChange;
            WaitTime += Time.deltaTime;
            //SceneManager.LoadScene("TibScene");
            if (WaitTime > 2) { Application.LoadLevel(Application.loadedLevel); }
        }

    }
}
