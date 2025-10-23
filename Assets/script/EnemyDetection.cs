using UnityEngine;
using System.Collections;

public class EnemyDetection : MonoBehaviour
{
    public float detectionRange = 5.0f;
    public float moveSpeed = 2.0f;
    public Transform player;

    [SerializeField]
    private bool playerDetected = false;

    void Start()
    {
    }

    void Update()
    {
        if (player == null)
            return;

        // Calcul de la distance entre l'ennemi et le joueur
        float distance = Vector2.Distance(transform.position, player.position);

        // Détection
        if (distance < detectionRange)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    void FixedUpdate()
    {
        if (playerDetected)
        {
            // Déplacement vers le joueur
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.fixedDeltaTime
            );
        }
    }

    }



