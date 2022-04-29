using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetClick : MonoBehaviour
{
    [SerializeField]
    private BallThrow _ball;
    private void OnMouseDown()
    {
        //when clicked on target throw a ball towards target
        if(!_ball.GetCanThrowBall())
            _ball.ThrowBall(transform.position);
    }
}
