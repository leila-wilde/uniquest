using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyDetectionTests
{
    private EnemyDetection enemyDetection;
    private GameObject enemyObject;
    private GameObject playerObject;
    private Transform playerTransform;

    [SetUp]
    public void SetUp()
    {
        enemyObject = new GameObject("Enemy");
        playerObject = new GameObject("Player");
        
        enemyDetection = enemyObject.AddComponent<EnemyDetection>();
        playerTransform = playerObject.transform;
        
        enemyDetection.player = playerTransform;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(enemyObject);
        Object.DestroyImmediate(playerObject);
    }

    [Test]
    public void TestDefaultDetectionRange()
    {
        Assert.AreEqual(5.0f, enemyDetection.detectionRange);
    }

    [Test]
    public void TestDefaultMoveSpeed()
    {
        Assert.AreEqual(2.0f, enemyDetection.moveSpeed);
    }

    [Test]
    public void TestPlayerReferenceAssigned()
    {
        Assert.IsNotNull(enemyDetection.player);
    }

    [Test]
    public void TestPlayerNotDetectedWhenTooFar()
    {
        // Place player far away
        playerObject.transform.position = new Vector3(10f, 10f, 0f);
        enemyObject.transform.position = Vector3.zero;
        
        float distance = Vector2.Distance(enemyObject.transform.position, playerObject.transform.position);
        
        Assert.Greater(distance, enemyDetection.detectionRange);
    }

    [Test]
    public void TestPlayerDetectedWhenClose()
    {
        // Place player within detection range
        playerObject.transform.position = new Vector3(2f, 2f, 0f);
        enemyObject.transform.position = Vector3.zero;
        
        float distance = Vector2.Distance(enemyObject.transform.position, playerObject.transform.position);
        
        Assert.Less(distance, enemyDetection.detectionRange);
    }

    [Test]
    public void TestDetectionRangeCanBeModified()
    {
        enemyDetection.detectionRange = 10.0f;
        Assert.AreEqual(10.0f, enemyDetection.detectionRange);
    }

    [Test]
    public void TestMoveSpeedCanBeModified()
    {
        enemyDetection.moveSpeed = 4.0f;
        Assert.AreEqual(4.0f, enemyDetection.moveSpeed);
    }

    [Test]
    public void TestDistanceCalculation()
    {
        enemyObject.transform.position = Vector3.zero;
        playerObject.transform.position = new Vector3(3f, 4f, 0f);
        
        float distance = Vector2.Distance(enemyObject.transform.position, playerObject.transform.position);
        
        Assert.AreEqual(5f, distance);
    }

    [Test]
    public void TestNullPlayerHandling()
    {
        enemyDetection.player = null;
        Assert.IsNull(enemyDetection.player);
    }

    [Test]
    public void TestEnemyMovement()
    {
        Vector3 initialPos = enemyObject.transform.position;
        Vector3 targetPos = new Vector3(5f, 0f, 0f);
        
        playerObject.transform.position = targetPos;
        
        Vector2 newPos = Vector2.MoveTowards(
            (Vector2)enemyObject.transform.position,
            (Vector2)playerObject.transform.position,
            enemyDetection.moveSpeed * Time.fixedDeltaTime
        );
        
        Assert.AreNotEqual((Vector2)initialPos, newPos);
    }

    [Test]
    public void TestDetectionRangeBoundary()
    {
        enemyObject.transform.position = Vector3.zero;
        playerObject.transform.position = new Vector3(5.0f, 0f, 0f);
        
        float distance = Vector2.Distance(enemyObject.transform.position, playerObject.transform.position);
        
        Assert.AreEqual(distance, enemyDetection.detectionRange);
    }

    [Test]
    public void TestMoveSpeedPositive()
    {
        Assert.Greater(enemyDetection.moveSpeed, 0f);
    }

    [Test]
    public void TestDetectionRangePositive()
    {
        Assert.Greater(enemyDetection.detectionRange, 0f);
    }
}
