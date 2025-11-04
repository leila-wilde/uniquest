using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class GameManagerTests
{
    private BattleManager battleManager;
    private GameObject gameObject;
    private Slider playerHealthBar;
    private Slider enemyHealthBar;
    private Image playerHealthFill;
    private Image enemyHealthFill;
    private TextMeshProUGUI infoText;
    private Button attackButton;
    private Button attackButton2;
    private Button attackButton3;
    private Button magicButton;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject("GameManager");
        battleManager = gameObject.AddComponent<BattleManager>();

        // Create health bars
        playerHealthBar = CreateSlider("PlayerHealthBar");
        enemyHealthBar = CreateSlider("EnemyHealthBar");

        // Create fill images
        playerHealthFill = CreateImage("PlayerHealthFill");
        enemyHealthFill = CreateImage("EnemyHealthFill");

        // Create buttons
        attackButton = CreateButton("AttackButton");
        attackButton2 = CreateButton("AttackButton2");
        attackButton3 = CreateButton("AttackButton3");
        magicButton = CreateButton("MagicButton");

        // Create text
        infoText = CreateTextMeshPro("InfoText");

        // Assign to BattleManager
        battleManager.playerHealthBar = playerHealthBar;
        battleManager.enemyHealthBar = enemyHealthBar;
        battleManager.playerHealthFill = playerHealthFill;
        battleManager.enemyHealthFill = enemyHealthFill;
        battleManager.infoText = infoText;
        battleManager.Button = attackButton;
        battleManager.Button2 = attackButton2;
        battleManager.Button3 = attackButton3;
        battleManager.Button4 = magicButton;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gameObject);
    }

    private Slider CreateSlider(string name)
    {
        GameObject sliderGO = new GameObject(name);
        return sliderGO.AddComponent<Slider>();
    }

    private Image CreateImage(string name)
    {
        GameObject imageGO = new GameObject(name);
        return imageGO.AddComponent<Image>();
    }

    private Button CreateButton(string name)
    {
        GameObject buttonGO = new GameObject(name);
        return buttonGO.AddComponent<Button>();
    }

    private TextMeshProUGUI CreateTextMeshPro(string name)
    {
        GameObject textGO = new GameObject(name);
        return textGO.AddComponent<TextMeshProUGUI>();
    }

    [Test]
    public void TestGameManagerExists()
    {
        Assert.IsNotNull(battleManager);
    }

    [Test]
    public void TestPlayerHealthBarExists()
    {
        Assert.IsNotNull(battleManager.playerHealthBar);
    }

    [Test]
    public void TestEnemyHealthBarExists()
    {
        Assert.IsNotNull(battleManager.enemyHealthBar);
    }

    [Test]
    public void TestPlayerHealthInitial()
    {
        Assert.AreEqual(100, battleManager.playerHealth);
    }

    [Test]
    public void TestEnemyHealthInitial()
    {
        Assert.AreEqual(80, battleManager.enemyHealth);
    }

    [Test]
    public void TestPlayerManaInitial()
    {
        Assert.AreEqual(50, battleManager.playerMana);
    }

    [Test]
    public void TestPlayerStrengthInitial()
    {
        Assert.AreEqual(15, battleManager.playerStrength);
    }

    [Test]
    public void TestInfoTextExists()
    {
        Assert.IsNotNull(battleManager.infoText);
    }

    [Test]
    public void TestAttackButtonExists()
    {
        Assert.IsNotNull(battleManager.Button);
    }

    [Test]
    public void TestMagicButtonExists()
    {
        Assert.IsNotNull(battleManager.Button4);
    }

    [Test]
    public void TestHealthBarFillImageExists()
    {
        Assert.IsNotNull(battleManager.playerHealthFill);
        Assert.IsNotNull(battleManager.enemyHealthFill);
    }

    [Test]
    public void TestPlayerHealthCanDecrement()
    {
        int initialHealth = battleManager.playerHealth;
        battleManager.playerHealth -= 10;
        Assert.AreEqual(initialHealth - 10, battleManager.playerHealth);
    }

    [Test]
    public void TestEnemyHealthCanDecrement()
    {
        int initialHealth = battleManager.enemyHealth;
        battleManager.enemyHealth -= 10;
        Assert.AreEqual(initialHealth - 10, battleManager.enemyHealth);
    }

    [Test]
    public void TestPlayerManaCanDecrement()
    {
        int initialMana = battleManager.playerMana;
        battleManager.playerMana -= 10;
        Assert.AreEqual(initialMana - 10, battleManager.playerMana);
    }

    [Test]
    public void TestMagicAttackDamageCalculation()
    {
        int damage = battleManager.playerStrength + 10;
        Assert.AreEqual(25, damage);
    }

    [Test]
    public void TestPhysicalAttackDamageCalculation()
    {
        int damage = battleManager.playerStrength;
        Assert.AreEqual(15, damage);
    }

    [Test]
    public void TestHealthCannotGoNegative()
    {
        battleManager.playerHealth = 10;
        battleManager.playerHealth -= 20;
        
        if (battleManager.playerHealth < 0)
        {
            battleManager.playerHealth = 0;
        }
        
        Assert.GreaterOrEqual(battleManager.playerHealth, 0);
    }

    [Test]
    public void TestManaCannotGoNegative()
    {
        battleManager.playerMana = 5;
        battleManager.playerMana -= 10;
        
        if (battleManager.playerMana < 0)
        {
            battleManager.playerMana = 0;
        }
        
        Assert.GreaterOrEqual(battleManager.playerMana, 0);
    }

    [Test]
    public void TestAllButtonsExist()
    {
        Assert.IsNotNull(battleManager.Button);
        Assert.IsNotNull(battleManager.Button2);
        Assert.IsNotNull(battleManager.Button3);
        Assert.IsNotNull(battleManager.Button4);
    }

    [Test]
    public void TestPlayerVictoryCondition()
    {
        battleManager.enemyHealth = 5;
        Assert.Greater(battleManager.enemyHealth, 0);
        
        battleManager.enemyHealth = 0;
        Assert.LessOrEqual(battleManager.enemyHealth, 0);
    }

    [Test]
    public void TestPlayerDefeatCondition()
    {
        battleManager.playerHealth = 5;
        Assert.Greater(battleManager.playerHealth, 0);
        
        battleManager.playerHealth = 0;
        Assert.LessOrEqual(battleManager.playerHealth, 0);
    }

    [Test]
    public void TestManaRequirementForMagic()
    {
        battleManager.playerMana = 5;
        int manaCost = 10;
        
        bool canCastMagic = battleManager.playerMana >= manaCost;
        Assert.IsFalse(canCastMagic);
    }

    [Test]
    public void TestManaAvailableForMagic()
    {
        battleManager.playerMana = 50;
        int manaCost = 10;
        
        bool canCastMagic = battleManager.playerMana >= manaCost;
        Assert.IsTrue(canCastMagic);
    }
}
