using UnityEngine;
using UnityEngine.UI;      // pour les boutons
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

// using System.Net;            // pour TextMeshPro

public class BattleManager : MonoBehaviour
{

    private bool isPlayerTurn = true;
    [Header("Barre de vie")]
    public Slider playerHealthBar;
    public Slider enemyHealthBar;

    public Image playerHealthFill;
    public Image enemyHealthFill;

    [Header("Références du joueur")]
    public int playerHealth = 100;
    public int playerMana = 50;
    public int playerStrength = 15;

    [Header("Références de l'ennemi")]
    public int enemyHealth = 80;

    [Header("UI Elements")]
    public TextMeshProUGUI infoText;  // texte qui affichera les actions (TextMeshPro)
    public Button Button;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    void Start()
    {
        playerHealthBar.maxValue = playerHealth;
        playerHealthBar.value = playerHealth;

        enemyHealthBar.maxValue = enemyHealth;
        enemyHealthBar.value = enemyHealth;

        // Lier les fonctions aux boutons
        Button.onClick.AddListener(OnAttack);
        Button2.onClick.AddListener(OnAttack);
        Button3.onClick.AddListener(OnAttack3);
        Button4.onClick.AddListener(OnMagicAttack);

        infoText.text = "Choisissez une action !";
    }

    void UpdateHealthBarColor(Slider healthBar, Image fillImage)
    {
        float healthPercent = healthBar.value / healthBar.maxValue;

        // Définir les couleurs aux différents niveaux
        Color green = Color.green;
        Color orange = new Color(1f, 0.5f, 0f); // orange
        Color red = Color.red;

        // Interpolation : vert -> orange -> rouge
        if (healthPercent > 0.5f)
        {
            // De vert à orange entre 100% et 50%
            fillImage.color = Color.Lerp(orange, green, (healthPercent - 0.5f) * 2f);
        }
        else
        {
            // De orange à rouge entre 50% et 0%
            fillImage.color = Color.Lerp(red, orange, healthPercent * 2f);
        }
    }

    void OnAttack()
    {
        if (!isPlayerTurn) return;

        int damage = playerStrength;

        enemyHealth -= damage;
        enemyHealthBar.value = enemyHealth;
        UpdateHealthBarColor(enemyHealthBar, enemyHealthFill);

        infoText.text = $"Attaque physique inflige {damage} dégâts ! (PV ennemi : {enemyHealth})";

        CheckEnemyDeath();

        if (enemyHealth > 0)
        {
            isPlayerTurn = false;
            StartCoroutine(EnemyTurn());
        }
    }

    void OnAttack3()
    {
        infoText.text = "Gros Noob du feu contre du feu ca marche pas";

        if (enemyHealth > 0)
        {
            isPlayerTurn = false;
            StartCoroutine(EnemyTurn());
        }
    }
    void OnMagicAttack()
    {
        if (!isPlayerTurn) return;

        int manaCost = 10;

        int damage = playerStrength + 10;

        if (playerMana >= manaCost)
        {
            playerMana -= manaCost;

            enemyHealth -= damage;
            enemyHealthBar.value = enemyHealth;
            UpdateHealthBarColor(enemyHealthBar, enemyHealthFill);

            infoText.text = $"Attaque magique inflige {damage} dégâts ! (Mana : {playerMana}, PV ennemi : {enemyHealth})";
            CheckEnemyDeath();
            if (enemyHealth > 0)
            {
                isPlayerTurn = false;
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            infoText.text = "Pas assez de mana !";
        }
    }

    void CheckEnemyDeath()
    {
        if (enemyHealth <= 0)
        {
            infoText.text = "Ennemi vaincu !";
            StartCoroutine(EndBattle());
        }
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        int enemyDamage = Random.Range(10, 30);

        playerHealth -= enemyDamage;
        playerHealthBar.value = playerHealth;
        UpdateHealthBarColor(playerHealthBar, playerHealthFill);

        infoText.text = $"L'ennemi attaque et inflige {enemyDamage} dégâts ! (PV joueur : {playerHealth})";

        if (playerHealth <= 0)
        {
            infoText.text = "Vous avez été vaincu...";
        }
        else
        {
            isPlayerTurn = true;
            infoText.text += "\nChoisissez une action !";
        }
    }
    void Awake()
    {
    DontDestroyOnLoad(gameObject);
    }
    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("EndGameScene", LoadSceneMode.Single);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Mount Owen", LoadSceneMode.Single);

        yield return new WaitForSeconds(3f);


    }
}

