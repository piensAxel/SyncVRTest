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

    public void SetHasToAnimate(bool hasToAnimate) { _hasToAnimate = hasToAnimate; }
    public bool GetHasToAnimate() { return _hasToAnimate; }
    public void SetIsAnimatingUp(bool isAnimatingUp) { _isAnimatingUp = isAnimatingUp; }
    public bool GetIsAnimatingUp() { return _isAnimatingUp; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            if (_isAnimatingUp)
            {
                _elapsedTime += Time.deltaTime;
                if(_elapsedTime > _timeToShoot)
                {
                    _hasToAnimate = true;
                    _isAnimatingUp = false;
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
}
