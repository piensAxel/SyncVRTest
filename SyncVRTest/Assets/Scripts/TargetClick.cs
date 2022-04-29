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
        if(!_ball.GetCanThrowBall())
            _ball.ThrowBall(transform.position);
    }
}
