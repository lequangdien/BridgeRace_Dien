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

    private void Start()
    {
        _buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        _joystickGameOjbect.SetActive(true);
        
    }
}
