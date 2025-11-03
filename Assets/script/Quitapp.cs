using UnityEngine;

public class QuitAfterDelay : MonoBehaviour
{
    public float delay = 3f; // durée avant la fermeture

    void Start()
    {
        // Démarre la coroutine quand la scène de fin se charge
        StartCoroutine(QuitGameAfterDelay());
    }

    System.Collections.IEnumerator QuitGameAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("Fermeture du jeu...");

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // quitte le mode Play dans l éditeur
    #else
        Application.Quit(); // ferme l application buildée
    #endif
    }
}
