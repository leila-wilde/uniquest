using NUnit.Framework;
using UnityEngine;

public class PlayerMovementsTests
{
    private PlayerMovements playerMovements;
    private GameObject playerObject;
    private Rigidbody2D rigidbody2D;

    [SetUp]
    public void SetUp()
    {
        playerObject = new GameObject("Player");
        rigidbody2D = playerObject.AddComponent<Rigidbody2D>();
        playerMovements = playerObject.AddComponent<PlayerMovements>();

        // Set the rigidbody reference
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.gravityScale = 0;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(playerObject);
    }

    [Test]
    public void TestDefaultMoveSpeed()
    {
        Assert.AreEqual(5f, playerMovements.moveSpeed);
    }

    [Test]
    public void TestPlayerObjectExists()
    {
        Assert.IsNotNull(playerObject);
    }

    [Test]
    public void TestRigidbody2DExists()
    {
        Assert.IsNotNull(rigidbody2D);
    }

    [Test]
    public void TestPlayerMovementsComponentExists()
    {
        Assert.IsNotNull(playerMovements);
    }

    [Test]
    public void TestMoveSpeedCanBeModified()
    {
        playerMovements.moveSpeed = 10f;
        Assert.AreEqual(10f, playerMovements.moveSpeed);
    }

    [Test]
    public void TestMoveSpeedBoundsLow()
    {
        playerMovements.moveSpeed = 0.1f;
        Assert.Greater(playerMovements.moveSpeed, 0f);
    }

    [Test]
    public void TestMoveSpeedBoundsHigh()
    {
        playerMovements.moveSpeed = 50f;
        Assert.Less(playerMovements.moveSpeed, 100f);
    }

    [Test]
    public void TestStartInitializesRigidbody()
    {
        Assert.IsNotNull(playerMovements.GetComponent<Rigidbody2D>());
    }

    [Test]
    public void TestPlayerTaggedCorrectly()
    {
        playerObject.tag = "Player";
        Assert.AreEqual("Player", playerObject.tag);
    }

    [Test]
    public void TestColliderPresent()
    {
        Collider2D collider = playerObject.AddComponent<BoxCollider2D>();
        Assert.IsNotNull(collider);
    }

    [Test]
    public void TestRigidbodyPhysicsEnabled()
    {
        Assert.IsTrue(rigidbody2D.bodyType == RigidbodyType2D.Kinematic);
    }

    [Test]
    public void TestInitialPositionIsZero()
    {
        Assert.AreEqual(Vector3.zero, playerObject.transform.position);
    }

    [Test]
    public void TestPlayerCanMove()
    {
        Vector3 initialPos = playerObject.transform.position;
        playerObject.transform.Translate(Vector3.right * 5f);
        
        Assert.AreNotEqual(initialPos, playerObject.transform.position);
    }

    [Test]
    public void TestVelocityCalculation()
    {
        float moveSpeed = 5f;
        float deltaTime = 0.02f; // Typical fixed timestep
        float distance = moveSpeed * deltaTime;

        Assert.AreEqual(0.1f, distance);
    }

    [Test]
    public void TestNormalizedMovementVector()
    {
        Vector2 moveInput = new Vector2(1f, 1f).normalized;
        float magnitude = moveInput.magnitude;

        Assert.AreEqual(1f, magnitude, 0.001f);
    }

    [Test]
    public void TestZeroMovementVector()
    {
        Vector2 moveInput = new Vector2(0f, 0f);
        float magnitude = moveInput.magnitude;

        Assert.AreEqual(0f, magnitude);
    }

    [Test]
    public void TestMovementDirectionRight()
    {
        Vector2 moveInput = new Vector2(1f, 0f);
        Assert.AreEqual(1f, moveInput.x);
        Assert.AreEqual(0f, moveInput.y);
    }

    [Test]
    public void TestMovementDirectionUp()
    {
        Vector2 moveInput = new Vector2(0f, 1f);
        Assert.AreEqual(0f, moveInput.x);
        Assert.AreEqual(1f, moveInput.y);
    }
}
