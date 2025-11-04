using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class QuitappTests
{
    private QuitAfterDelay quitApp;
    private GameObject gameObject;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject("QuitApp");
        quitApp = gameObject.AddComponent<QuitAfterDelay>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gameObject);
    }

    [Test]
    public void TestDefaultDelay()
    {
        Assert.AreEqual(3f, quitApp.delay);
    }

    [Test]
    public void TestDelayCanBeModified()
    {
        quitApp.delay = 5f;
        Assert.AreEqual(5f, quitApp.delay);
    }

    [Test]
    public void TestDelayIsPositive()
    {
        Assert.Greater(quitApp.delay, 0f);
    }

    [Test]
    public void TestDelayCanBeSet()
    {
        quitApp.delay = 2f;
        Assert.AreEqual(2f, quitApp.delay);
    }

    [Test]
    public void TestGameObjectExists()
    {
        Assert.IsNotNull(gameObject);
    }

    [Test]
    public void TestComponentAttached()
    {
        QuitAfterDelay component = gameObject.GetComponent<QuitAfterDelay>();
        Assert.IsNotNull(component);
    }

    [Test]
    public void TestDelayMinimumValue()
    {
        quitApp.delay = 0.1f;
        Assert.Greater(quitApp.delay, 0f);
    }

    [Test]
    public void TestDelayMaximumValue()
    {
        quitApp.delay = 100f;
        Assert.Less(quitApp.delay, float.MaxValue);
    }

    [Test]
    public void TestMultipleDelayChanges()
    {
        quitApp.delay = 2f;
        Assert.AreEqual(2f, quitApp.delay);
        
        quitApp.delay = 5f;
        Assert.AreEqual(5f, quitApp.delay);
        
        quitApp.delay = 1f;
        Assert.AreEqual(1f, quitApp.delay);
    }

    [Test]
    public void TestGameObjectCanBeDisabled()
    {
        gameObject.SetActive(false);
        Assert.IsFalse(gameObject.activeSelf);
    }

    [Test]
    public void TestGameObjectCanBeEnabled()
    {
        gameObject.SetActive(true);
        Assert.IsTrue(gameObject.activeSelf);
    }

    [Test]
    public void TestComponentCanBeDisabled()
    {
        quitApp.enabled = false;
        Assert.IsFalse(quitApp.enabled);
    }

    [Test]
    public void TestComponentCanBeEnabled()
    {
        quitApp.enabled = true;
        Assert.IsTrue(quitApp.enabled);
    }

    [Test]
    public void TestDefaultDelayValue()
    {
        var newGO = new GameObject("TestQuit");
        var newQuit = newGO.AddComponent<QuitAfterDelay>();
        Assert.AreEqual(3f, newQuit.delay);
        Object.DestroyImmediate(newGO);
    }
}
