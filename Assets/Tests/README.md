# Unit Tests for Uniquest Game

This directory contains unit tests for the game components.

## Test Files

### BattleManagerTests.cs
Tests for the `BattleManager` class (GameManager.cs):
- Initial health and mana values
- Damage calculations
- Mana consumption and validation
- Health bar updates
- Enemy and player defeat conditions
- Magic attack mechanics

### PlayerMovementsTests.cs
Tests for the `PlayerMovements` class:
- Movement speed configuration
- Rigidbody initialization
- Movement vector calculations
- Position updates
- Collision detection setup

## Running Tests

### In Unity Editor
1. Open the **Test Runner** window: `Window → Testing → Test Runner`
2. Click the **Play** button to run all tests
3. Individual tests can be run by clicking on them

### From Command Line
```bash
# Run all tests
unity -runTests -testPlatform editmode

# Run specific test file
unity -runTests -testPlatform editmode -testFilter BattleManagerTests

# Generate XML report
unity -runTests -testPlatform editmode -testResults results.xml
```

## Test Coverage

The tests cover:
- ✅ Health and mana initialization
- ✅ Damage calculations and health reduction
- ✅ Attack mechanics (physical and magical)
- ✅ Game state checks (victory/defeat)
- ✅ Player movement and input handling
- ✅ Physics and collision setup

## Adding More Tests

To add tests for other components:

1. Create a new file in `Assets/Tests/Editor/` named `YourComponentTests.cs`
2. Use NUnit framework with `[Test]` and `[SetUp]` attributes
3. Follow the existing test pattern
4. Run tests via the Test Runner

## Notes

- Tests use `[SetUp]` and `[TearDown]` for test initialization and cleanup
- Mock GameObjects are created to avoid scene dependencies
- Tests focus on logic, not visual elements
- Some coroutine-based methods may need refactoring to be fully testable
