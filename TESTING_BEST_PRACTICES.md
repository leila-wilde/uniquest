# Unit Testing Best Practices for Your Game

## Overview
Your game now has a complete test infrastructure set up with 20+ unit tests covering the core gameplay logic.

## Current Test Structure

```
Assets/
├── script/
│   ├── PlayerMovements.cs
│   ├── GameManager.cs (BattleManager)
│   └── ...
└── Tests/
    └── Editor/
        ├── BattleManagerTests.cs (15 tests)
        └── PlayerMovementsTests.cs (14 tests)
```

## Tips for Writing Better Tests

### 1. **Arrange-Act-Assert Pattern**
```csharp
[Test]
public void TestEnemyHealthReduction()
{
    // Arrange
    int initialHealth = battleManager.enemyHealth;
    int damage = 20;
    
    // Act
    battleManager.enemyHealth -= damage;
    
    // Assert
    Assert.AreEqual(initialHealth - damage, battleManager.enemyHealth);
}
```

### 2. **Test One Thing Per Test**
❌ Bad:
```csharp
[Test]
public void TestAttackAndMana()
{
    // Tests multiple things
}
```

✅ Good:
```csharp
[Test]
public void TestAttackDamage() { ... }

[Test]
public void TestManaCost() { ... }
```

### 3. **Use Descriptive Names**
✅ Good names:
- `TestInsufficientManaPreventsMagicAttack`
- `TestPlayerHealthReducesOnEnemyAttack`
- `TestPlayerDefeatedWhenHealthReachesZero`

### 4. **Mock Game Objects**
The tests create minimal mock objects instead of relying on scenes:
```csharp
// Create mock UI elements
playerHealthBar = CreateSlider("PlayerHealthBar");
enemyHealthBar = CreateSlider("EnemyHealthBar");
infoText = CreateTextMeshPro("InfoText");
```

### 5. **Test Edge Cases**
```csharp
[Test]
public void TestZeroHealth() { ... }

[Test]
public void TestNegativeHealth() { ... }

[Test]
public void TestMaxHealth() { ... }
```

## Components to Test Next

### High Priority (Game-Critical)
- [ ] `EnemyDetection.cs` - Test collision detection
- [ ] `GameManager.cs` - Test scene transitions
- [ ] `IntroDialogue.cs` & `EndDialogue.cs` - Test dialogue triggers

### Medium Priority (Gameplay)
- [ ] `Quitapp.cs` - Test quit functionality
- [ ] Enemy AI logic (when extracted)
- [ ] Inventory system (if added)

### Low Priority (Polish)
- [ ] Audio/VFX managers
- [ ] UI animations
- [ ] Menu interactions

## Testing Coroutines

The current battle system uses coroutines (`StartCoroutine`). For better testability:

```csharp
// Before (hard to test)
StartCoroutine(EnemyTurn());

// After (more testable)
public IEnumerator EnemyTurn() 
{ 
    yield return new WaitForSeconds(1f);
    // ... game logic
}

// Test it separately
[Test]
public IEnumerator TestEnemyTurnLogic()
{
    yield return battleManager.EnemyTurn();
    // Assert after coroutine completes
}
```

## Continuous Integration Setup

For GitHub Actions (optional):
```yaml
# .github/workflows/test.yml
name: Run Unit Tests
on: [push, pull_request]
jobs:
  test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      - uses: game-ci/unity-test-runner@v2
        with:
          projectPath: /home/nyxx/Projects/uniquest
          testMode: editmode
```

## Code Coverage

Aim for these coverage targets:
- **Critical Logic**: 90%+ (health, mana, damage)
- **Core Features**: 70%+ (movement, attacks)
- **UI/Polish**: 30%+ (menus, animations)

## Common Issues & Solutions

### Issue: Tests fail with "NullReferenceException"
**Solution**: Ensure all GameObjects and components are created in `SetUp()`

### Issue: Tests timeout
**Solution**: Use `[UnityTest]` for coroutines instead of `[Test]`

### Issue: Physics-dependent tests fail
**Solution**: Set rigidbody to kinematic mode in tests

## Resources

- [NUnit Documentation](https://nunit.org/)
- [Unity Testing Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@latest/)
- [Unity Test Runner](https://docs.unity3d.com/Manual/testrunner.html)

## Quick Commands

```bash
# Run tests from terminal
unity -runTests -testPlatform editmode -projectPath . -logFile -

# Generate coverage report (requires OpenCover)
OpenCover.Console.exe -target:Unity.exe -targetargs:"-runTests"
```

---

**Last Updated**: 2024
**Test Framework Version**: 1.5.1
**Total Tests**: 29
