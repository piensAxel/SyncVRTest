using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRange : MonoBehaviour
{
    [SerializeField]
    private List<TargetAnimation> _targets;
    [SerializeField]
    private float _timeBetweenTargetUp = 5.0f;
    private float _elapsedTime = 0.0f;
    private float _cachedTimeBetweenTargetUp;
    // Start is called before the first frame update
    void Start()
    {
        _cachedTimeBetweenTargetUp = _timeBetweenTargetUp;
        ChooseRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //choose a random target to come up
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime > _timeBetweenTargetUp)
        {
            ChooseRandomTarget();
            _timeBetweenTargetUp -= 0.1f;
            if (_timeBetweenTargetUp < 1.5f)
                _timeBetweenTargetUp = 1.5f;
            _elapsedTime = 0.0f;
        }
    }

    private void ChooseRandomTarget()
    {
        bool hasChosen = false;
        while (!hasChosen)
        {
            int random = Random.Range(0, _targets.Count);
            if (!_targets[random].GetIsAnimatingUp() && !_targets[random].GetHasToAnimate())
            {
                _targets[random].SetHasToAnimate(true);
                _targets[random].SetIsAnimatingUp(true);
                hasChosen = true;
            }
        }
    }

    public void ResetRange()
    {
        //reset all targets and values
        _timeBetweenTargetUp = _cachedTimeBetweenTargetUp;
        //will make a target move up straight away
        _elapsedTime = _cachedTimeBetweenTargetUp;
        foreach(TargetAnimation target in _targets)
        {
            target.ResetTarget();
        }
    }
}
