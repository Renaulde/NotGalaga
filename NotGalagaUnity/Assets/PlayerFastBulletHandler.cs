using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastBulletHandler : MonoBehaviour
{
    public float damage;
    public float speed;
    public float damModifier;

    public GameObject PlayerFastBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move bullet to top of screen
        transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);

        //destroy if leaving screen
        if (PlayerFastBullet.transform.position.y > 30)
        {
            Destroy(PlayerFastBullet);
        }
    }
}
