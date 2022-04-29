using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private int _score = 0;
    public int GetScore() { return _score; }
    public void ScoreUpdate()
    {
        ++_score;
        _scoreText.text = _score.ToString();
    }

    public void ReseScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
