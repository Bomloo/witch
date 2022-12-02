using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEgg : MonoBehaviour
{
    #region Movement_vars
    [SerializeField]
    private Transform pc;
    #endregion

    #region Spawning_vars
    [SerializeField]
    private SpiderKid SK;
    [SerializeField]
    private float maxHatchTimer;
    private float HatchTimer;
    #endregion

    #region Damage_vars
    [SerializeField]
    private float damage;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        HatchTimer = maxHatchTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(HatchTimer <= 0)
        {
            SpiderKid sk = Instantiate(SK, transform.position, Quaternion.identity);
            Debug.Log("instatiated");
            sk.setPlayer(pc);
            Debug.Log("sest the player");
            Destroy(this.gameObject);
        }
        HatchTimer -= Time.deltaTime;
    }
    #region Movement_funcs
    public void setPlayer(Transform player)
    {
        pc = player;
    }

 
    #endregion
}
