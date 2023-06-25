using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class EnemyBullet is responsible for the behaviour of the enemy bullet 
/// </summary>
public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _ebs;
    /// <summary>
    /// Method awake that is responsible for destroying the bullet 5 seconds after it is fired
    /// </summary>
    private void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    /// <summary>
    ///  Method that updates the position of the bullet every frame
    /// </summary>
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * _ebs.getBulletSpeed();
    }

    /// <summary>
    /// Method that checks if it's a player if so it takes a certain amount of damage to the player and plays the hit sound
    /// </summary>
    /// <param name="collision">Collider with the game object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Entrei");
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Collectable")
        {
            Destroy(this.gameObject);
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerCombat>().TakeDamage(_ebs.getDamage());
                collision.GetComponent<AudioSource>().Play();
                //Vector2 direction = (collision.gameObject.transform.position - this.gameObject.transform.position);
                //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * _ebs.Bullet_force, ForceMode2D.Impulse);
            }
        }
    }
}
