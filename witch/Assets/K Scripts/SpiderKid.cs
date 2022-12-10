using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKid : MonoBehaviour
{
    #region Movement_vars
    [SerializeField]
    private Transform pc;
    private SmartMovement move;
    #endregion

    #region Damage_vars
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackTimer;
    private float timer;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<SmartMovement>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Movement_funcs
    public void setPlayer(Transform player)
    {
        pc = player;
        move = GetComponent<SmartMovement>();
        move.setPlayer(player);
    }



    #endregion

    #region Attackfuncs

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(timer <= 0)
            {
                StartCoroutine(Attack());
                timer = attackTimer;
            }
            
        }
    }

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(.5f);
        RaycastHit2D[] hits = Physics2D.BoxCastAll(((Vector2)this.transform.position) , Vector2.one, 0, transform.position - pc.position, 2f);
        Debug.Log(hits.Length);
        Debug.DrawRay(this.transform.position, this.transform.position - pc.transform.position, Color.red, 5f);
        Debug.Log(this.transform.position - pc.transform.position);
        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log(transform.tag);
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("I hit player");
                hit.transform.GetComponent<PlayerController>().take_dmg(damage, GetComponent<EnemyHealth>());
            }
        }
        yield return new WaitForSeconds(.5f);
        timer = 0;
    }
    #endregion
}
