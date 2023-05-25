using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region varaibles
    [SerializeField]
    private EnemyHealth myHealth;
    private float damage;
    private PlayerController player;
    #endregion

    #region Attack_functions
    private void rat_launch()
    {
        //RatProjectile temp = Instantiate(rat_projectile);
        //rat_projectile. direction = this.transform.position - player.transform.position;
        //rat_projectile.direction.z = 0;
        //myHealth.damage(self_damage);

    }

    private void eat()
    {
        //so something with direction and animations or something
    }
    #endregion

}
