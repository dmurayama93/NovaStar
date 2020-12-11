using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Enemy_Weapon : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15;

    public PlayerHealthAndDamage player;

    private void Start()
    {
         player = GameObject.Find("PlayerHealthAndDamage").GetComponent<PlayerHealthAndDamage>();

        if (player == null)
        {
            Debug.Log("Player is NULL");
        }
    }


    // Start is called before the first frame update
    void Update()
    {
        WeaponMovement();
    }

    public void WeaponMovement()
    {

        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -37)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.PlayerDamage();
            Destroy(this.gameObject);
        }
    }


}
