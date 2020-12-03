﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    //1st attack pattern
    //Boss turn red and fires charged beam
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _curHp;

    //base movement
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    //_curTarget will set a new target throughout game
    [SerializeField] private Transform _curTarget;
    private int _startDirection;
    private int _randDirection;
    private bool _newDirection;

    //phase 2 movement
    [SerializeField] private Transform _pointC;
    [SerializeField] private bool _p2Active;
    private bool _activateP2;
    private bool _initialP2;
    private bool _stopHpCheck;
    private bool _startP2Move;

    private Animator _anim;
 
    //basic fire

    // Start is called before the first frame update
    void Start()
    {
        //assigning current hp
        _curHp = _maxHp;

        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("No Anim");
        }

        _startDirection = Random.Range(0, 2);
        //Sets Random Direction at Start
        if (_startDirection == 0)
        {
            _curTarget = _pointA;
        }
        else if (_startDirection == 1)
        {
            _curTarget = _pointB;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //activates the second phase of the fight
        if (_curHp <= _maxHp * .5 && _stopHpCheck == false)
        {
            _activateP2 = true;
            _initialP2 = true;
            //stops this if statement from being checked to prevent activate bool being set to true
            _stopHpCheck = true;
        }
        //if second phase abil not active then standard movement
        if (_p2Active == false)
        {
            StandardMovement();
            if (_activateP2 == true)
            {
                //change color, can create coroutine to start color flash to indicate charge
                //run through initial coroutine only once
                if (_initialP2 == true)
                {
                    StartCoroutine(InitialP2());
                    _initialP2 = false;
                    _activateP2 = false;
                }
                else if (_initialP2 == false)
                {
                    StartCoroutine(ActivateP2());
                    _activateP2 = false;
                }                
            }
        }
        //else stop standard movement, enable second phase movement
        else if (_p2Active == true)
        {
            SecondPhaseAbility();
        }          
    }
    private void BossEntrance()
    {
        //entrance pattern
        //boss moves onto screen and rotates to face the player
    }
    private void StandardMovement()
    {
        //Boss moves up and down on y axis randomly      
        if (_randDirection == 0 && transform.position.y <= 15.0f)
        {
            transform.position = transform.up * _speed * Time.deltaTime;
        }
        else
        {
            _randDirection = 1;
            transform.position = transform.up * -1.0f * _speed * Time.deltaTime;
        }
        if (_randDirection == 1 && transform.position.y >= -15.0f)
        {
            transform.position = transform.up * -1.0f * _speed * Time.deltaTime;
        }
        else
        {
            _randDirection = 0;
            transform.position = transform.up * _speed * Time.deltaTime;
        }
        if (_newDirection == false)
        {
            _newDirection = true;
            StartCoroutine(RandomDirection());
        }
    }
    IEnumerator RandomDirection()
    {   
        //Sets Random enemy direction towards point a or point b
        yield return new WaitForSeconds(Random.Range(2.5f, 5.0f));
        _randDirection = Random.Range(0, 2);
        if (_randDirection == 0)
        {
            _curTarget = _pointA;

        }
        if (_randDirection == 1)
        {
            _curTarget = _pointB;
        }
        _newDirection = false;
    }
    private void SecondPhaseAbility()
    {
        if (_startP2Move == true)
        {
            _anim.SetBool("Charge", true);
        }
        if (transform.position.x <= -40.0f)
        {
            _anim.SetBool("Charge", false);
            _anim.SetBool("BeamRoutine", true);
            _startP2Move = false;
            _p2Active = false;
        }
    }
    //Initial P2 Coroutine has a shorter wait for to start faster
    IEnumerator InitialP2()
    {
        yield return new WaitForSeconds(5.0f);
        //controls which movement function to use
        _p2Active = true;
        //controls coroutine bool
        _activateP2 = true;
        //control movement to first point
        _startP2Move = true;
    }
    IEnumerator ActivateP2()
    {
        yield return new WaitForSeconds(Random.Range(25.0f, 30.0f));
        _p2Active = true;
        _activateP2 = true;
        _startP2Move = true;
    }
}