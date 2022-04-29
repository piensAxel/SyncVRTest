using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _range, _ball, _score, _menu, _backButton;
    // Start is called before the first frame update
    void Start()
    {
        _range.SetActive(false);
        _ball.SetActive(false);
        _score.SetActive(false);
        _backButton.SetActive(false);
        _menu.SetActive(true);
    }

    public void StartGame()
    {
        _range.SetActive(true);
        _ball.SetActive(true);
        _score.SetActive(true);
        _backButton.SetActive(true);
        _menu.SetActive(false);
    }

    public void BackButton()
    {
        _range.SetActive(false);
        _ball.SetActive(false);
        _score.SetActive(false);
        _backButton.SetActive(false);
        _menu.SetActive(true);
    }
}
