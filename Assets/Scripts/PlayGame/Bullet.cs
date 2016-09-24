using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 6f;

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (transform.position.y > 4.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "enemy")
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy.hp <= 0)
            {
                FrameAnimation frameAnimation = hit.GetComponent<FrameAnimation>();
                PolygonCollider2D pc2d = hit.GetComponent<PolygonCollider2D>();
                pc2d.enabled = false;

                if (!frameAnimation.OnceDes)
                {
                    frameAnimation.OnceDes = true;
                    GameManager._i.score += enemy.score;
                }
            }
            else
            {
                enemy.hp -= 1;
            }

            Destroy(this.gameObject);
        }
    }

}
