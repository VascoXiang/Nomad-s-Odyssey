using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _ebs;
    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * _ebs.getBulletSpeed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrei");
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Collectable")
        {
            Destroy(this.gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyScript>().TakeDamage(_ebs.getDamage());

                //Vector2 direction = (collision.gameObject.transform.position - this.gameObject.transform.position);
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _ebs.Bullet_force, ForceMode2D.Impulse);
            }
        }
    }
}
