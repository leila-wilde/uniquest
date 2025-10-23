using UnityEngine;
using UnityEngine.UI;      // pour les boutons
using TMPro;
using System.Collections;            // pour TextMeshPro

public class BattleManager : MonoBehaviour
{
    private bool isPlayerTurn = true;

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
        // Lier les fonctions aux boutons
        Button.onClick.AddListener(OnAttack);
        Button2.onClick.AddListener(OnAttack);
        Button3.onClick.AddListener(OnMagicAttack);
        Button4.onClick.AddListener(OnMagicAttack);

        infoText.text = "Choisissez une action !";
    }

    void OnAttack()
    {
        if (!isPlayerTurn) return;

        int damage = playerStrength;

        enemyHealth -= damage;

        infoText.text = $"Attaque physique inflige {damage} dégâts ! (PV ennemi : {enemyHealth})";

        CheckEnemyDeath();
        
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

        int enemyDamage = Random.Range(5, 30);
        playerHealth -= enemyDamage;

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
    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(2f);
        
        Application.Quit();
    }
}
