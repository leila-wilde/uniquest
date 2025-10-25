using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroDialogue : MonoBehaviour

{

    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public Text dialogueText;

    [Header("Références du joueur")]
    public GameObject player;

    private PlayerMovements playerScript;

    private int dialogueIndex = 0;
    private string[] dialogues = new string[]
    {
        "Je suis un serviteur du Feu Secret, porteur de la flamme d'Anor.",
        "Le feu obscur ne te servira à rien, flamme d'Udûn.",
        "Repartez dans l'ombre",
        "VOUS",
        "NE",
        "PASSEREZ",
        "PAS !!!!!"

    };

    private bool isDialogueActive = true;

    void Start()
    {
        if (player != null)
            playerScript = player.GetComponent<PlayerMovements>();

        // 🔒 Bloque le joueur pendant le dialogue
        if (playerScript != null)
            playerScript.enabled = false;

        // Affiche le premier texte
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogues[dialogueIndex];
    }

    void Update()
    {
        // Quand on clique ou appuie sur espace
        if (isDialogueActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            NextDialogue();
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);

        // 🔓 Redonne le contrôle au joueur
        if (playerScript != null)
            playerScript.enabled = true;
    }
}
