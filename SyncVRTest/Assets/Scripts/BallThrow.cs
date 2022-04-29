using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallThrow : MonoBehaviour
{
    [SerializeField]
    private float _timeOfThrow = 2.0f;
    [SerializeField]
    private float _height = 2.0f;
    private Vector3 _startPos;
    private Vector3 _targetPos;
    private bool _canThrowBall = false;
    private float _elapsedTime = 0.0f;
    private Rigidbody _rb;

    [SerializeField]
    private Score _scoreComp;
    [SerializeField]
    private float _rotSpeed = 5.0f;

    public bool GetCanThrowBall() { return _canThrowBall; }
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if the player can throw the ball move across a parabola to the target
        if (_canThrowBall)
        {
            _elapsedTime += Time.deltaTime;
            _rb.MovePosition(Parabola(_height, _elapsedTime / _timeOfThrow));
            //rotate ball when throwing
            RotateBall();
            //if the target is already gone reset ball
            if (_elapsedTime > _timeOfThrow +0.2f)
                ResetBall();
        }
    }

    public void ThrowBall(Vector3 targetPos)
    {
        _targetPos = targetPos;
        _canThrowBall = true;
    }

    private Vector3 Parabola(float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;
        Vector3 mid = Vector3.Lerp(_startPos, _targetPos, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(_startPos.y, _targetPos.y, t), mid.z);
    }

    private void RotateBall()
    {
        transform.Rotate(Vector3.right, _rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the ball hits target, animate it down, add point and play particle
        if (other.gameObject.tag == "Target")
        {
            _scoreComp.ScoreUpdate();
            TargetAnimation comp = other.gameObject.transform.parent.GetComponent<TargetAnimation>();
            comp.SetHasToAnimate(true);
            comp.SetIsAnimatingUp(!comp.GetHasToAnimate());
            //play particle
            comp.PlayParticle();
            ResetBall();
        }
    }

    private void ResetBall()
    {
        _canThrowBall = false;
        _elapsedTime = 0.0f;
        transform.position = _startPos;
        transform.rotation = Quaternion.identity;
    }
}
