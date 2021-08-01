using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimThrower : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Thrower thrower;

    private void Start()
    {
        thrower.ThrowAnimation += StartThrowAnimation;
    }

    public void StopThrowAnimation()
    {
        anim.SetBool("IsThrowing", false);
    }

    public void StartThrowAnimation()
    {
        anim.SetBool("IsThrowing", true);
    }
}
