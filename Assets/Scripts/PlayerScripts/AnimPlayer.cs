using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement player;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        player.RunAnimation += RunAnimation;
    }

    public void RunAnimation(float speed, float flip)
    {
        anim.SetFloat("Speed", speed);

        _spriteRenderer.flipX = Flip(flip);
    }

    private bool Flip(float flip)
    {
        if (flip < 0)
        {
            return true;
        }

        return false;
    }
}
