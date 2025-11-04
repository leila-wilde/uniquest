using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class EndDialogueTests
{
    private EndDialogue endDialogue;
    private GameObject dialogueObject;
    private GameObject playerObject;
    private GameObject panelObject;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;
    private PlayerMovements playerMovements;

    [SetUp]
    public void SetUp()
    {
        // Create dialogue panel
        dialogueObject = new GameObject("EndDialogue");
        panelObject = new GameObject("DialoguePanel");
        
        // Create UI elements
        GameObject nameGO = new GameObject("NameText");
        nameText = nameGO.AddComponent<TextMeshProUGUI>();
        
        GameObject textGO = new GameObject("DialogueText");
        dialogueText = textGO.AddComponent<TextMeshProUGUI>();
        
        // Create player
        playerObject = new GameObject("Player");
        playerMovements = playerObject.AddComponent<PlayerMovements>();
        
        // Setup end dialogue
        endDialogue = dialogueObject.AddComponent<EndDialogue>();
        endDialogue.dialoguePanel = panelObject;
        endDialogue.nameText = nameText;
        endDialogue.dialogueText = dialogueText;
        endDialogue.player = playerObject;
        endDialogue.texts = new List<DialogueLine>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(dialogueObject);
        Object.DestroyImmediate(playerObject);
        Object.DestroyImmediate(panelObject);
    }

    [Test]
    public void TestDialoguePanelNotNull()
    {
        Assert.IsNotNull(endDialogue.dialoguePanel);
    }

    [Test]
    public void TestNameTextNotNull()
    {
        Assert.IsNotNull(endDialogue.nameText);
    }

    [Test]
    public void TestDialogueTextNotNull()
    {
        Assert.IsNotNull(endDialogue.dialogueText);
    }

    [Test]
    public void TestPlayerReferenceNotNull()
    {
        Assert.IsNotNull(endDialogue.player);
    }

    [Test]
    public void TestDialogueListInitialized()
    {
        Assert.IsNotNull(endDialogue.texts);
    }

    [Test]
    public void TestDialogueListIsEmpty()
    {
        Assert.AreEqual(0, endDialogue.texts.Count);
    }

    [Test]
    public void TestDialoguePanelCanBeDeactivated()
    {
        endDialogue.dialoguePanel.SetActive(false);
        Assert.IsFalse(endDialogue.dialoguePanel.activeSelf);
    }

    [Test]
    public void TestDialoguePanelCanBeActivated()
    {
        endDialogue.dialoguePanel.SetActive(true);
        Assert.IsTrue(endDialogue.dialoguePanel.activeSelf);
    }

    [Test]
    public void TestPlayerScriptExists()
    {
        Assert.IsNotNull(playerMovements);
    }

    [Test]
    public void TestPlayerCanBeEnabled()
    {
        playerMovements.enabled = true;
        Assert.IsTrue(playerMovements.enabled);
    }

    [Test]
    public void TestPlayerCanBeDisabled()
    {
        playerMovements.enabled = false;
        Assert.IsFalse(playerMovements.enabled);
    }

    [Test]
    public void TestNameTextCanBeSet()
    {
        string testName = "Speaker";
        endDialogue.nameText.text = testName;
        Assert.AreEqual(testName, endDialogue.nameText.text);
    }

    [Test]
    public void TestDialogueCanBeAddedToList()
    {
        DialogueLine line = new DialogueLine();
        line.speaker = "Test Speaker";
        
        endDialogue.texts.Add(line);
        
        Assert.AreEqual(1, endDialogue.texts.Count);
    }

    [Test]
    public void TestMultipleDialoguesCanBeAdded()
    {
        for (int i = 0; i < 5; i++)
        {
            DialogueLine line = new DialogueLine();
            line.speaker = $"Speaker {i}";
            endDialogue.texts.Add(line);
        }
        
        Assert.AreEqual(5, endDialogue.texts.Count);
    }

    [Test]
    public void TestDialogueSpeakerCanBeRetrieved()
    {
        DialogueLine line = new DialogueLine();
        line.speaker = "Test Speaker";
        endDialogue.texts.Add(line);
        
        Assert.AreEqual("Test Speaker", endDialogue.texts[0].speaker);
    }

    [Test]
    public void TestPlayerObjectNotNull()
    {
        Assert.IsNotNull(endDialogue.player);
    }

    [Test]
    public void TestDialogueUIStructure()
    {
        Assert.IsNotNull(endDialogue.dialoguePanel);
        Assert.IsNotNull(endDialogue.nameText);
        Assert.IsNotNull(endDialogue.dialogueText);
    }

    [Test]
    public void TestPlayerHasPlayerMovementsComponent()
    {
        PlayerMovements script = endDialogue.player.GetComponent<PlayerMovements>();
        Assert.IsNotNull(script);
    }

    [Test]
    public void TestDialogueLineContainsSpeaker()
    {
        DialogueLine line = new DialogueLine();
        line.speaker = "Speaker Name";
        
        Assert.IsNotNull(line.speaker);
        Assert.AreNotEqual("", line.speaker);
    }
}
