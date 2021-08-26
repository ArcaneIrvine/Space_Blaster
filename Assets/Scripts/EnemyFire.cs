using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private float speed = 10;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            //destroy enemy's bullets
            Destroy(gameObject);
            collision.gameObject.GetComponent<MainPlayer>().PlayExplosion();
        }
    }
}

