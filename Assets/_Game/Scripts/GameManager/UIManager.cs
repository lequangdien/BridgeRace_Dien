using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject _joystickGameOjbect;
    [SerializeField] public GameObject Pause;
    [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public Button _buttonPause;
    [SerializeField] public Button _buttonPlay;
    [SerializeField] public GameObject uiPasue;
    [SerializeField] public Button continueButton;
    [SerializeField] public Button backMainMenuButton;
    [SerializeField] public GameObject winGame;
    [SerializeField] public GameObject loseGame;

    private void Start()
    {
        _buttonPlay.onClick.AddListener(PlayGame);
        _buttonPause.onClick.AddListener(PasueGame);
        continueButton.onClick.AddListener(ButtonContinue);
    }
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        _joystickGameOjbect.SetActive(true);
        Pause.SetActive(true);
    }
    public void PasueGame()
    {
        Time.timeScale = 0;
        uiPasue.SetActive(true);
        _joystickGameOjbect.SetActive(false);
    }
    public void ButtonContinue()
    {
        uiPasue.SetActive(false);
        Time.timeScale = 1;
        _joystickGameOjbect.SetActive(true);
    }
    public void WinGame()
    {
        winGame.SetActive(true);
        _joystickGameOjbect.SetActive(false);
        Pause.SetActive(false);
        Time.timeScale = 0;
    }
    public void LoseGame()
    {
        loseGame.SetActive(true);
        _joystickGameOjbect.SetActive(false);
        Pause.SetActive(false);
        Time.timeScale = 0;
    }
}
