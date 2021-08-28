using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
     public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get position
        Vector2 position = transform.position;

        //compute enemy's new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //update enemy position
        transform.position = position;

        //thats the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //if enemy goes outside of the bottom screen then destroy it
        if (transform.position.y < min.y)
        {
            //take a life away from the player
            MainPlayer.TakeDamage();
            Destroy(gameObject);
        }

    }
}
