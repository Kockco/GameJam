using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D _rigid;
    Vector3 Movement;

    // Player Speed
    public float _speed;
    public float _savespeed;

    // Save
    private float _savepoint = 0;

    // Horizontal , Vertical
    float h;
    float v;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerRun();
        PlayerRotation();
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
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Movement.Set(h, v, 0);
        Movement = Movement.normalized * _speed * Time.deltaTime;
        _rigid.MovePosition(_rigid.transform.position + Movement);

        if(h == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(h == -1)
        {
            GetComponent<SpriteRenderer>().flipX = false;                
        }
    }

    private void PlayerRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed *= 1.5f;            
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = _savespeed;
        }        
    }

    private void PlayerDead()
    {

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

}
