using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyFire : MonoBehaviour
{
    private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //kill enemy ship
            collision.gameObject.GetComponent<Enemy>().kill();
            Destroy(gameObject);
        }
    }
}
