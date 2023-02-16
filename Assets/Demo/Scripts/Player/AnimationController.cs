using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private Player input;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        input = Player.Instance;

        input.joystick.onJoystick += getMagnitude;
    }
    public void getMagnitude(Vector2 direction)
    {
        anim.SetFloat("Blend", direction.magnitude);
    }

}
