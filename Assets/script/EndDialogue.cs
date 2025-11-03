using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    public GameObject text;
}

public class EndDialogue : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public List<DialogueLine> texts = new List<DialogueLine>();
    

    [Header("Références du joueur")]
    public GameObject player;

    private PlayerMovements playerScript;
    private int dialogueIndex = 0;
    private bool isDialogueActive = true;

    

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isDialogueActive) return;

        // Passage au dialogue suivant
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    void DisplayDialogue()
    {

        texts[dialogueIndex].text.SetActive(true);
        if (dialogueIndex > 0)
        {
            texts[dialogueIndex - 1].text.SetActive(false);
        }

        nameText.text = texts[dialogueIndex].speaker;
    }

    void NextDialogue()
    {
        if (dialogueIndex < texts.Count)
        {
            DisplayDialogue();
        }
        else
        {
            FinishDialogue();
        }
        dialogueIndex++;
    }

    void FinishDialogue()
    {
        isDialogueActive = false;

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        if (playerScript != null)
            playerScript.enabled = true;
    }
}
