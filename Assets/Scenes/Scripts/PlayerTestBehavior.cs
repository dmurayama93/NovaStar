using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestBehavior : MonoBehaviour
{

  /*
    Weapon power ups sustainability is dependent on damage taken by the player. If the player
   takes damage, the player’s weapon level will be reset to the starting weapon level.
   If the player takes damage in standard weapon mode, their ship will explode and they
   will need to restart the level. 

    My Tasks: 
   -variable for player health
   -deduct from player health upon damage
   -if player takes damage then weapon resets to start weapon level.
   -if player takes damage standard then destroy object.


    */

    [SerializeField]
    private GameObject[] _weaponsPrefab;

    [SerializeField]
    private int _weaponPowerUpID = 0;

    [SerializeField]
    private GameObject _fireballPrefab;

    private enum CurrentWeapon : int
    {
        FirstWeapon,
        SecondWeapon,
        ThirdWeapon,
        FourthWeapon,
        FifthWeapon

    }

    private CurrentWeapon weaponCurrentlyOn;

    //setting this to 1 in case we want to add in a health bar
    [SerializeField]
    private float _health = 1;

    [SerializeField]
    private float _maximumHealth = 1;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireShot();
        }

        PlayerDamageTest();
    }

    public void FireShot()
    {
        if(weaponCurrentlyOn == CurrentWeapon.FirstWeapon)
        {
            Instantiate(_weaponsPrefab[0], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.SecondWeapon)
        {
            Instantiate(_weaponsPrefab[1], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.ThirdWeapon)
        {
            Instantiate(_weaponsPrefab[2], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.FourthWeapon)
        {
            Instantiate(_weaponsPrefab[3], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.FifthWeapon)
        {
            Instantiate(_weaponsPrefab[4], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

    }

   
    public void PlayerDamage()
    {
        _health -= .5f;
        _weaponPowerUpID = 0;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //for testing
    public void PlayerDamageTest()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerDamage();
            Debug.Log("Health= " + _health);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponPowerUp weaponPowerUp = other.transform.GetComponent<WeaponPowerUp>();
        _weaponPowerUpID++;
 
        if (weaponPowerUp != null)
        {
            switch (_weaponPowerUpID)
            {

                case 0:
                    weaponCurrentlyOn = CurrentWeapon.FirstWeapon;
                    break;

                case 1:
                    weaponCurrentlyOn = CurrentWeapon.SecondWeapon;
                    _weaponPowerUpID++;
                    _health = _maximumHealth;
                    Debug.Log(_weaponPowerUpID);
                    //weapon behavior 2
                    break;

                case 2:
                    weaponCurrentlyOn = CurrentWeapon.ThirdWeapon;
                    _weaponPowerUpID++;
                    _health = _maximumHealth;
                    Debug.Log(_weaponPowerUpID);
                    //weapon behavior 3
                    break;

                case 3:
                    weaponCurrentlyOn = CurrentWeapon.FourthWeapon;
                    _weaponPowerUpID++;
                    _health = _maximumHealth;
                    Debug.Log(_weaponPowerUpID);
                    //weapon behavior 4
                    break;

                case 4:
                    weaponCurrentlyOn = CurrentWeapon.FifthWeapon;
                    _weaponPowerUpID++;
                    _health = _maximumHealth;
                    Debug.Log(_weaponPowerUpID);
                    //weapon behavior 5
                    break;


                default:
                    Debug.Log("Invalid ID!");
                    break;
            }

        }

        Destroy(other.gameObject);

        }

    }
    
