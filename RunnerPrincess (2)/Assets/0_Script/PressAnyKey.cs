using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    public Image _pressanykey;
    public Image _fadeimg;
    private float _alpha;
    private float _fadealpha;
    private bool _bFade;
    private bool _bStart;

    private void Awake()
    {
        _alpha = 1;
        _fadealpha = 0;
    }

    private void Update()
    {
        _alpha = Mathf.Clamp(_alpha, 0, 1);
        KeyAlphaChange();
        GameStart();
    }

    private void GameStart()
    {
        _fadeimg.color = new Color(1, 1, 1, _fadealpha);
        if (Input.anyKeyDown)
        {
            _bStart = true;
        }
        else if (_bStart)
        {
            _fadealpha += 0.015f;
            if (_fadealpha >= 1)
            {
                _bStart = false;
                SceneManager.LoadScene("CutScene");
            }
        }
    }

    private void KeyAlphaChange()
    {
        _pressanykey.color = new Color(1, 1, 1, _alpha);
        if (!_bFade)
        {
            _alpha -= 0.03f;
            if (_alpha <= 0)
            {
                _bFade = true;
            }
        }
        else if (_bFade)
        {
            _alpha += 0.03f;
            if (_alpha >= 1)
            {
                _bFade = false;
            }
        }
    }
}
