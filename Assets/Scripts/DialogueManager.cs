﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    string path = "Assets/Resources/testscript.txt";
    StreamReader sr;
    Text DialogueText;
    Image NextLineButton;
    //public GameManager GM;
    Canvas dialogueCanvas;

    public void startDialogue()
    {
        if (!File.Exists(path))
        {
            Debug.Log("File doesn't exist, cannot read");
            return;
        }

        if (dialogueCanvas.enabled)
        {
            dialogueCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            dialogueCanvas.enabled = true;
            Time.timeScale = 0.0f;
        }

        sr = new StreamReader(path);
        DialogueText.text = sr.ReadLine();
    }

    public void nextLine()
    {
        DialogueText.text = sr.ReadLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GetComponentInChildren<Canvas>();
        dialogueCanvas.enabled = false;
        NextLineButton = GetComponent<Image>();
        DialogueText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // testing dialogue with space bar trigger -- remove for release
        if (Input.GetKeyDown("space"))
            startDialogue();
    }
}
