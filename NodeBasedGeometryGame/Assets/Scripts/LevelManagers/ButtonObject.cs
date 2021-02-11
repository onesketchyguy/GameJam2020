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

    public Vector2 actualCollisionArea = Vector2.one * 0.25f;
    public float actualCollisionOffset = 0.1f;

    private bool hasTriggered = false;

    private void Start()
    {
        spriteRenderer.sprite = upSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var col = Physics2D.OverlapBox(transform.position + transform.up * actualCollisionOffset, actualCollisionArea, transform.rotation.z);
        if (col == null || col.gameObject != collision.gameObject) return;

        spriteRenderer.sprite = downSprite;

        OnDown?.Invoke();

        if (Time.timeSinceLevelLoad < 1) return;

        if (hasTriggered) return;

        OnTriggered?.Invoke();
        hasTriggered = true;
    }

    private void OnCollisionExit2D()
    {
        if (spriteRenderer.sprite != downSprite) return;

        spriteRenderer.sprite = upSprite;

        OnUp?.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + transform.up * actualCollisionOffset, actualCollisionArea);
    }
}