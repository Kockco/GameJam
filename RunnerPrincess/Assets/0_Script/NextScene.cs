using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Transform _camera;
    SpriteRenderer _spr;
    Animator _anim;
    float _fadeTime;

    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
        _anim = _camera.GetComponent<Animator>();
        _fadeTime = 1;

    }

    private void Update()
    {
        CutSceneFade();
    }

    private void CutSceneFade()
    {
        _spr.color = new Color(1, 1, 1, _fadeTime);
        if(_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.98f)
        {
            _anim.speed = 0;
            _fadeTime -= 0.01f;
            if(_fadeTime <= 0)
            {
                SceneManager.LoadScene("Stage1");
            }
        }
    }
}
