using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [SerializeField]
    private int _amountOfLifes = 3;
    [SerializeField]
    private List<GameObject> _hearts;
    [SerializeField]
    private Menu _menu;
    [SerializeField]
    private TargetRange _targetRange;
    public void RemoveLife()
    {
        Invoke("RemoveInvoke", 0.5f);

    }

    private void RemoveInvoke()
    {
        --_amountOfLifes;
        _hearts[_amountOfLifes].SetActive(false);
        if(_amountOfLifes == 0)
        {
            _targetRange.ResetRange();
            _menu.EndScreen();

        }
    }

    public void ResetLifes()
    {
        _amountOfLifes = 3;
        foreach (GameObject heart in _hearts)
            heart.SetActive(true);
    }
}
