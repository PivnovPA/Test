using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    private int _score;

    [SerializeField]
    private Text _textScore;

    [SerializeField]
    private Text _textstrength;

    [SerializeField]
    private GameObject gameLoosePanel;

    [SerializeField]
    private Button reloadLvlButton;

    [SerializeField]
    private Text _textScoreFinal;

    private void Start()
    {
        EventManager.Instance.EventOnScoreUpdate.AddListener(ValueScoreUpdate);
        EventManager.Instance.EventPlayerHealthUpdate.AddListener(TextStrenghtUpdate);
        EventManager.Instance.EventPlayerDeath.AddListener(GameLoosePanelActive);
        EventManager.Instance.EventPlayerDeath.AddListener(FinalTextScoreUpdate);
        reloadLvlButton.onClick.AddListener(HandleRestartClick);
    }

    public void ValueScoreUpdate(int _value)
    {
        _score += _value;
        TextScoreUpdate();
    }

    private void TextScoreUpdate()
    {
        _textScore.text = "Score: " + _score;
    }

    private void TextStrenghtUpdate(float _health)
    {
        _textstrength.text = "Strength: " + _health + "%";
    }

    private void GameLoosePanelActive()
    {
        gameLoosePanel.SetActive(true);
    }

    private void FinalTextScoreUpdate()
    {
        _textScoreFinal.text = "Score: " + _score;
    }

    private void HandleRestartClick()
    {
        GameManager.Instance.RestartLevel();
    }
}
