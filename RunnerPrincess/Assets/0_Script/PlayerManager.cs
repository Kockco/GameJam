﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D _rigid;
    Vector3 Movement;
    Animator _anim;

    // Player Speed
    public float _speed;
    public float _savespeed;

    // Save
    private float _savepoint = 0;

    // Horizontal , Vertical
    float h;
    float v;

    // Player State
    private bool _isDead;
    private bool _isRun;
    private bool _isWalk;

    private float _deaddelay = 0;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerRun();
        PlayerWalk();
        PlayerRotation();
        PlayerDead();
        Debug.Log(_isRun);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerRotation()
    {
        transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);
    }

    private void PlayerMove()
    {
        if (_isDead)
            return;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Movement.Set(h, v, 0);
        Movement = Movement.normalized * _speed * Time.deltaTime;
        _rigid.MovePosition(_rigid.transform.position + Movement);
        if (h == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (h == -1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRun = true;
            _isWalk = false;
            _speed *= 2f;
            if (_isRun)
            {
                _anim.SetInteger("PlayerState", 2);
            }
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _savespeed;
            _isRun = false;
        }
    }

    private void PlayerWalk()
    {
        if (!_isRun && _speed >= _savespeed && Input.GetAxisRaw("Horizontal") != 0 | Input.GetAxisRaw("Vertical") != 0 )
        {
            _isWalk = true;
            if (_isWalk)
            {
                _anim.SetInteger("PlayerState", 1);
            }
        }
        else if(!_isRun && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 )
        {
            _anim.SetInteger("PlayerState", 0);
        }
    }

    private void PlayerDead()
    {
        if (_isDead)
        {
            _anim.SetInteger("PlayerState", 3);
            _deaddelay += Time.deltaTime;
            if (_deaddelay >= 0.7f)
            {
                _deaddelay = 0;
                gameObject.SetActive(false);
                _isDead = false;
                SceneManager.LoadScene("Stage1");
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Save":
                _savepoint++;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Bomb":
                _isDead = true;
                break;
        }
    }

}
