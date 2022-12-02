using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMother : MonoBehaviour
{
    #region Spawning_vars
    [SerializeField]
    private SpiderEgg eggref;
    private float spawnTimer;
    private float moveTimer;
    private float spawnWait;
    [Tooltip("For babies to find player")]
    private Transform pc;
    #endregion

    #region Move_vars
    [SerializeField]
    private float movespeed;
    private float x;
    private float y;
    private bool moving;
    private Vector2 direction;
    private bool spawning;
    #endregion

    #region Physics_var
    private Rigidbody2D MotherBody;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        MotherBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving && !spawning)
        {
            direction = Vector2.zero;
            while (direction.Equals(Vector2.zero))
            {
                x = Random.Range(-1f, 1f);
                y = Random.Range(-1f, 1f);
                direction.x = x;
                direction.y = y;
            }
            direction.Normalize();
            direction *= movespeed;
            MotherBody.velocity = direction;
            moving = true;
            moveTimer = Random.Range(1f, 4f);

        } else if(moving && !spawning)
        {
            MotherBody.velocity = direction;
            moveTimer -= Time.deltaTime;
            if(moveTimer <= 0)
            {
                moving = false;
                spawning = true;
                spawnTimer = 1f;
            }
        } else if (spawning)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0)
            {
                SpiderEgg sb = Instantiate(eggref, this.transform.position, Quaternion.identity);
                sb.setPlayer(pc);
                spawning = false;
            }
        }
        
    }

   
}
