using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wellhint : MonoBehaviour
{
    private Text hintText;
    private Image dialogue;
    private float hintTimer;
    private void Awake()
    {
        hintText = GameObject.Find("dialogueText").GetComponent<Text>();
        dialogue = GameObject.Find("IntoDialogue").GetComponent<Image>();
    }
    private void Start()
    {
        Invoke("hint", 5f);
    }
    private void Update()
    {
        hintTimer += Time.deltaTime;
        if (hintTimer >= 5)
        {
            hintTimer = 0;
            dialogue.enabled = false;
            hintText.enabled = false;
        }
    }
    private void hint()
    {
        hintTimer = 0;
        hintText.text = "BE CAREFUL! JUST TURN ON THE LIGHT (PRESS S)";
        dialogue.enabled = true;
        hintText.enabled = true;
        
    }
}
