# Quick Start Guide: Running Unit Tests

## Setup (Already Done ✓)
- ✅ Unity Test Framework 1.5.1 already installed
- ✅ Test structure created in `Assets/Tests/Editor/`
- ✅ 20+ tests added for BattleManager and PlayerMovements

## How to Run Tests

### Option 1: Unity Test Runner (Easiest)
1. In Unity Editor, go to **Window → Testing → Test Runner**
2. Click **EditMode** tab
3. Click **Run All** button
4. Watch tests execute and see results

### Option 2: Run Individual Test
1. Open Test Runner (Window → Testing → Test Runner)
2. Click on any specific test name
3. Click the play icon next to it

### Option 3: Command Line
```bash
# From project root
unity -runTests -testPlatform editmode -projectPath /home/nyxx/Projects/uniquest
```

## What's Tested

### BattleManagerTests (15 tests)
- Health initialization and updates
- Mana management
- Damage calculations
- Attack mechanics (physical & magical)
- Victory/defeat conditions
- Color-coded health bars

### PlayerMovementsTests (14 tests)
- Movement speed configuration
- Rigidbody initialization
- Vector calculations
- Physics setup
- Input handling

## Adding Your Own Tests

Create a new file `Assets/Tests/Editor/YourComponentTests.cs`:

```csharp
using NUnit.Framework;
using UnityEngine;

public class YourComponentTests
{
    [SetUp]
    public void SetUp()
    {
        // Initialize before each test
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after each test
    }

    [Test]
    public void TestYourFeature()
    {
        Assert.AreEqual(expected, actual);
    }
}
```

## Useful Assertions

```csharp
Assert.AreEqual(expected, actual);        // Check equality
Assert.IsTrue(condition);                 // Check true
Assert.IsFalse(condition);                // Check false
Assert.IsNotNull(obj);                    // Check not null
Assert.Greater(a, b);                     // Check a > b
Assert.Less(a, b);                        // Check a < b
Assert.Throws<Exception>(() => { ... });  // Check exception
```

## Next Steps

1. ✅ Run the existing tests to verify everything works
2. ✅ Add tests for `EnemyDetection.cs`, `EndDialogue.cs`, etc.
3. ✅ Refactor coroutine methods to make them more testable
4. ✅ Aim for 80%+ code coverage
