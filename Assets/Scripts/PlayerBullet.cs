using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class PlayerBullet is responsible for the behaviour of the player bullet 
/// </summary>
public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private ProjectileScriptableObject _ebs;
    [SerializeField] private PlayerStatsScriptableObject _ps;

    /// <summary>
    /// Method awake that is responsible for destroying the bullet 0.7 seconds after it is fired
    /// </summary>
    private void Awake()
    {
        Destroy(this.gameObject, 0.7f);
    }

    /// <summary>
    ///  Method that updates the position of the bullet every frame
    /// </summary>
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * _ebs.getBulletSpeed();
    }

    /// <summary>
    /// Method that checks if it's an enemy if so it takes a certain amount of damage to the enemy depending on the buff damage 
    /// </summary>
    /// <param name="collision">Collider with the game object</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Collectable")
        {
            Destroy(this.gameObject);
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyScript>().TakeDamage(_ebs.getDamage() * _ps.getBonusDamage());

            }
        }
    }
}
