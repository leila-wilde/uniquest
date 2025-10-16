using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Vitesse de déplacement
    private Rigidbody2D rb;             // Référence au Rigidbody2D
    private Vector2 moveInput;          // Direction de déplacement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // On récupère le Rigidbody du joueur
    }

    void Update()
    {
        // On lit les entrées du clavier
        float moveX = Input.GetAxisRaw("Horizontal"); // Flèches gauche/droite
        float moveY = Input.GetAxisRaw("Vertical");   // Flèches haut/bas

        // On crée un vecteur de direction
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // On applique le mouvement au Rigidbody
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
