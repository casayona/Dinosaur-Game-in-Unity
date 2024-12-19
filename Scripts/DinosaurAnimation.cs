using UnityEngine;

public class DinosaurAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Invoke(nameof(AnimationPlay),0f);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(AnimationPlay));
    }
    private void AnimationPlay()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
        Invoke(nameof(AnimationPlay),1f / GameManager.instance.gameSpeed);
    }
}
