using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private JoystickInput _joystickInput;


    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player.RunAnimation += RunAnimation;
        _joystickInput.RunAnimation += RunAnimation;
    }

    public void RunAnimation(float speed, float flip)
    {
        _anim.SetFloat("Speed", speed);

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
