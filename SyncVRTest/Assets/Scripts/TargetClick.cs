using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetClick : MonoBehaviour
{
    [SerializeField]
    private Score _scoreComp;
    [SerializeField]
    private TargetAnimation _targetAnim;
    private void OnMouseDown()
    {
        _scoreComp.ScoreUpdate();
        _targetAnim.SetHasToAnimate(true);
        _targetAnim.SetIsAnimatingUp(!_targetAnim.GetHasToAnimate());
    }
}
