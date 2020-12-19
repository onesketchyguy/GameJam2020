using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ButtonObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite downSprite, upSprite;

    [Tooltip("This item only triggers once.")]
    public UnityEngine.Events.UnityEvent OnTriggered;

    [Tooltip("This item can trigger more than once.")]
    public UnityEngine.Events.UnityEvent OnUp;

    [Tooltip("This item can trigger more than once.")]
    public UnityEngine.Events.UnityEvent OnDown;

    private bool hasTriggered = false;

    private void Start()
    {
        spriteRenderer.sprite = upSprite;
    }

    private void OnCollisionEnter2D()
    {
        spriteRenderer.sprite = downSprite;

        OnDown?.Invoke();

        if (Time.timeSinceLevelLoad < 1) return;

        if (hasTriggered) return;

        OnTriggered?.Invoke();
        hasTriggered = true;
    }

    private void OnCollisionExit2D()
    {
        spriteRenderer.sprite = upSprite;

        OnUp?.Invoke();
    }
}