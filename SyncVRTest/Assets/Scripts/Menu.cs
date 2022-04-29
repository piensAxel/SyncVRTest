using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _range, _ball, _score, _menu, _backButton, _lifes, _endscreen;
    [SerializeField]
    private TextMeshProUGUI _endScore;
    // Start is called before the first frame update
    void Start()
    {
        _range.SetActive(false);
        _ball.SetActive(false);
        _score.SetActive(false);
        _backButton.SetActive(false);
        _lifes.SetActive(false);
        _endscreen.SetActive(false);
        _menu.SetActive(true);
    }

    public void StartGame()
    {
        _range.SetActive(true);
        _ball.SetActive(true);
        _score.SetActive(true);
        _backButton.SetActive(true);
        _lifes.SetActive(true);
        _endscreen.SetActive(false);
        _menu.SetActive(false);
    }

    public void BackButton()
    {
        _range.SetActive(false);
        _ball.SetActive(false);
        _score.SetActive(false);
        _backButton.SetActive(false);
        _lifes.SetActive(false);
        _endscreen.SetActive(false);
        _menu.SetActive(true);
    }

    public void EndScreen()
    {
        _range.SetActive(false);
        _ball.SetActive(false);
        _score.SetActive(false);
        _backButton.SetActive(false);
        _lifes.SetActive(false);
        _menu.SetActive(false);
        _endscreen.SetActive(true);
        _endScore.text = "Score: " + GetComponent<Score>().GetScore();
    }
}
