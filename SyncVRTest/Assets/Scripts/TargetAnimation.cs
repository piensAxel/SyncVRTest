using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnimation : MonoBehaviour
{
    [SerializeField]
    private float _rotSpeed = 10.0f;
    [SerializeField]
    private Vector3 _endRot = new Vector3(-90, 0, 0);
    private bool _hasToAnimate = false;
    private bool _isAnimatingUp = false;

    [SerializeField]
    private float _timeToShoot = 3.0f;
    private float _elapsedTime = 0.0f;
    [SerializeField]
    private ParticleSystem _stars;
    public void SetHasToAnimate(bool hasToAnimate) { _hasToAnimate = hasToAnimate; }
    public bool GetHasToAnimate() { return _hasToAnimate; }
    public void SetIsAnimatingUp(bool isAnimatingUp) { _isAnimatingUp = isAnimatingUp; }
    public bool GetIsAnimatingUp() { return _isAnimatingUp; }
    [SerializeField]
    private Lifes _lifes;
    // Update is called once per frame
    void Update()
    {
        //if animating, animate up or down
        if (_hasToAnimate)
        {
            _elapsedTime = 0.0f;
            if (_isAnimatingUp)
                AnimateUp();
            else
                AnimateDown();
        }
        else
        {
            //if the target is up and player takes too long remove life and animate down
            if (_isAnimatingUp)
            {
                _elapsedTime += Time.deltaTime;
                if(_elapsedTime > _timeToShoot)//player was to late
                {
                    _hasToAnimate = true;
                    _isAnimatingUp = false;
                    _lifes.RemoveLife();
                }
            }
        }
    }

    private void AnimateUp()
    {
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_endRot), _rotSpeed * Time.deltaTime);
        transform.rotation = rot;
        if (transform.rotation == Quaternion.Euler(_endRot))
            _hasToAnimate = false;
    }

    private void AnimateDown()
    {
        Quaternion rot = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, _rotSpeed * Time.deltaTime);
        transform.rotation = rot;
        if (transform.rotation == Quaternion.identity)
            _hasToAnimate = false;
    }

    public void PlayParticle()
    {
        _stars.Play();
    }

    public void ResetTarget()
    {
        _stars.Stop();
        _hasToAnimate = false;
        _isAnimatingUp = false;
        transform.rotation = Quaternion.identity;
        _elapsedTime = 0.0f;
    }
}
