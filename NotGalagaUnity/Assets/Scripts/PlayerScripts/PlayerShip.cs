using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public GameObject defaultPlayerShip;
    public GameObject playerFastBullet;

    //player base settings
    public float playerBaseHealth;
    public float playerBaseSpeed;
    public int playerCredit; //the amount of player lives

    //modifier settings
    public float playerModHealth;
    public float playerModSpeed;
    public float playerModDamage;

    //internal modifier handling
    float playerHealth;
    float playerSpeed;

    //shot handling

    //delay handling
    private int shootFastDelay = 0;
    public int shootFastDelayMax;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = playerBaseSpeed * playerModSpeed;
        playerHealth = playerBaseHealth * playerModHealth;
        
    }

    // Update is called once per frame, fixed will keep a steady frame rate
    void FixedUpdate()
    {
        //movement keys
        if (Input.GetKey(KeyCode.W))
        {
            transform.position=new Vector3(transform.position.x, transform.position.y + playerSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - playerSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - playerSpeed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + playerSpeed, transform.position.y, transform.position.z);
        }


        //shot key
        if ((Input.GetKey(KeyCode.RightArrow)) && (shootFastDelay >= shootFastDelayMax))
        {
            Instantiate(playerFastBullet, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), transform.rotation);
            shootFastDelay = 0;
        }
        //fast shot delay and cooldowns
        if (shootFastDelay < shootFastDelayMax)
        {
            shootFastDelay++;
        }


        //check for player death
        if (playerHealth <= 0)
        {
            Destroy(defaultPlayerShip);
        }
    }
}
