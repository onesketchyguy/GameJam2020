using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private bool isOpen = false;

    public string levelToLoad;

    public void SetOpen(bool value)
    {
        isOpen = value;
        animator.SetBool("isOpen", isOpen);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Hit player let's do shit!
            if (isOpen)
            {
                SceneManager.LoadScene(levelToLoad);
            }
            else
            {
                // Do nothing
                // Maybe tell the player that they need to open the door....
            }
        }
    }
}