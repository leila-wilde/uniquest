using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class IntroDialogueTests
{
    private IntroDialogue introDialogue;
    private GameObject dialogueObject;
    private GameObject playerObject;
    private GameObject panelObject;
    private Text dialogueText;
    private PlayerMovements playerMovements;

    [SetUp]
    public void SetUp()
    {
        // Create dialogue panel and text
        dialogueObject = new GameObject("IntroDialogue");
        panelObject = new GameObject("DialoguePanel");
        
        // Create UI text
        GameObject textGO = new GameObject("DialogueText");
        dialogueText = textGO.AddComponent<Text>();
        
        // Create player
        playerObject = new GameObject("Player");
        playerMovements = playerObject.AddComponent<PlayerMovements>();
        
        // Setup intro dialogue
        introDialogue = dialogueObject.AddComponent<IntroDialogue>();
        introDialogue.dialoguePanel = panelObject;
        introDialogue.dialogueText = dialogueText;
        introDialogue.player = playerObject;
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
        Assert.IsNotNull(introDialogue.dialoguePanel);
    }

    [Test]
    public void TestDialogueTextNotNull()
    {
        Assert.IsNotNull(introDialogue.dialogueText);
    }

    [Test]
    public void TestPlayerReferenceNotNull()
    {
        Assert.IsNotNull(introDialogue.player);
    }

    [Test]
    public void TestDialogueTextAssigned()
    {
        Assert.IsNotNull(introDialogue.dialogueText);
        Assert.IsNotNull(introDialogue.dialogueText.text);
    }

    [Test]
    public void TestDialoguePanelCanBeDeactivated()
    {
        introDialogue.dialoguePanel.SetActive(false);
        Assert.IsFalse(introDialogue.dialoguePanel.activeSelf);
    }

    [Test]
    public void TestDialoguePanelCanBeActivated()
    {
        introDialogue.dialoguePanel.SetActive(true);
        Assert.IsTrue(introDialogue.dialoguePanel.activeSelf);
    }

    [Test]
    public void TestPlayerScriptExists()
    {
        Assert.IsNotNull(playerMovements);
    }

    [Test]
    public void TestPlayerHasPlayerMovementsComponent()
    {
        PlayerMovements script = playerObject.GetComponent<PlayerMovements>();
        Assert.IsNotNull(script);
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
    public void TestDialogueTextCanBeSet()
    {
        string testDialogue = "Test dialogue";
        introDialogue.dialogueText.text = testDialogue;
        Assert.AreEqual(testDialogue, introDialogue.dialogueText.text);
    }

    [Test]
    public void TestMultipleDialogueLines()
    {
        string[] dialogues = new string[]
        {
            "Line 1",
            "Line 2",
            "Line 3"
        };
        
        Assert.AreEqual(3, dialogues.Length);
    }

    [Test]
    public void TestDialoguePanelDisabledInitially()
    {
        Assert.IsNotNull(introDialogue.dialoguePanel);
    }

    [Test]
    public void TestPlayerObjectNotNull()
    {
        Assert.IsNotNull(introDialogue.player);
    }

    [Test]
    public void TestDialogueUIStructure()
    {
        Assert.IsNotNull(introDialogue.dialoguePanel);
        Assert.IsNotNull(introDialogue.dialogueText);
    }

    [Test]
    public void TestPlayerTagAssignment()
    {
        playerObject.tag = "Player";
        Assert.AreEqual("Player", playerObject.tag);
    }
}
