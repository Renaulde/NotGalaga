using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    //player shot handling
    public GameObject PlayerFastBullet;
    //public GameObject PlayerHomeBullet;
    //public GameObject PlayerLaserBullet;
    int shootFastDelay = 0;
    public int shootFastDelayMax;

    //player speed handling
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {

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

        //shooting keys
        //fast shot
        if ((Input.GetKey(KeyCode.RightArrow)) && (shootFastDelay >= shootFastDelayMax))
        {
            Instantiate(PlayerFastBullet, transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
            shootFastDelay = 0;
        }

        //calculating delay and cooldowns
        if (shootFastDelay < shootFastDelayMax)
        {
            shootFastDelay++;
        }
    }
}
