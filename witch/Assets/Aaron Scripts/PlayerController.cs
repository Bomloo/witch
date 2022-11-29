using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public GameObject shootpt;
    public PlayerAction pa;
    public HealthDrop heart;


    #region Basic_var_bools
    public bool attack_state = false;
    //private bool move_state = false;
    public bool reload_state = false;
    public bool reloading = false;
    public bool dash_state = false;
    public bool resting = false;
    public bool vulnerable = true;
    #endregion

    #region Health_vars
    private float health = 100;
    [SerializeField]
    private float max_health = 100;
    private float shield = 0;
    private float max_shield = 0;
    private float reflect_dmg = 0f;
    private float negate_dmg = 0f;
    #endregion

    #region Attack_vars
    private int ammo = 2;
    [SerializeField]
    public int max_ammo = 2;
    [SerializeField]
    private int range = 10;
    [SerializeField]
    private float dmg = 20;
    [SerializeField]
    private float crit_rate = 0.1f;
    [SerializeField]
    private float crit_dmg = 1.2f;
    public bool last_shot = false;
    private bool stack_crit = false;
    private int max_stack = 0;
    private float vamp = 0f;
    private float focus_fire = 1f;
    private EnemyHealth curr_ene = null;
    public bool deathdrop = false;
    public bool hitdrop = false;
    public bool selfdrop = false;
    public float selfdrop_timer = 10f;
    public bool selfdrop_pause = false;
    public bool knockback = false;
    #endregion

    #region UI_vars
    [SerializeField]
    private Slider hp;
    [SerializeField]
    private TextMeshProUGUI ammoText;
    #endregion


    public Card[] hand= new Card[3];
    private int indx;

    private void Start()
    {
        indx = 0;
    }

    private void Update()
    {
        if (selfdrop && selfdrop_pause == false)
        {
            selfdrop_pause = true;
            Vector3 spawn_pos = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * 10;
            if (!Physics2D.OverlapCircle(spawn_pos, 0.7f))
            {
                Instantiate(heart, spawn_pos, Quaternion.identity);
                StartCoroutine(countdown_drop(selfdrop_timer));
            }
            else
            {
                selfdrop_pause = false;
            }
            
        }
    }

    public void add_hand (Card card)
    {
        //Debug.Log(card);
        //Debug.Log(indx);
        if (indx < 3)
        {
            //Debug.Log("pass here");
            hand[indx] = card;
            if (card.isActive == false)
            {
                card.StartPassive(this);
                Debug.Log("passive");
            }
            
        }
        else
        {
            Destroy(card.gameObject);
        }
        Debug.Log("inc");
        indx++;
    }

    public void move(float x, float y)
    {
        //if (x == 0 && y == 0)
        //{
        //    move_state = false;
        //}
        //else if (dash_state == true)
        //{
        //    move_state = false;
        //}
        //else
        //{
        //    move_state = true;
        //}
        Vector2 target_velocity = new Vector2(x, y);
        rb.velocity = target_velocity;
        //Debug.Log("moving");

    }

    public void attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.transform.position, shootpt.transform.up, range);
        
        if (hit.collider == null)
        {
            //Debug.Log("missed");
            curr_ene = null;
        }
        else
        {
            Debug.Log("hit");
            if (hit.transform.GetComponent<EnemyHealth>() != null)
            {
                if (stack_crit && max_stack < 5)
                {
                    crit_dmg += 0.1f;
                    max_stack++;
                }

                if ((ammo == 1 && last_shot) || (Random.value < crit_rate))
                {
                    if (hit.transform.GetComponent<EnemyHealth>() == curr_ene)
                    {
                        //Debug.Log("here");
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg * focus_fire, hitdrop, deathdrop, knockback, shootpt.transform.up);
                    }
                    else
                    {
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg, hitdrop, deathdrop, knockback, shootpt.transform.up);
                    }
                }

                else
                {
                    if (hit.transform.GetComponent<EnemyHealth>() == curr_ene)
                    {
                        //Debug.Log("here");
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * focus_fire, hitdrop, deathdrop, knockback, shootpt.transform.up);
                    }
                    else
                    {
                        hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg, hitdrop, deathdrop, knockback, shootpt.transform.up);
                    }
                }
                curr_ene = hit.transform.GetComponent<EnemyHealth>();
                heal(vamp);
            }



            //if (ammo == 1 && last_shot)
            //{
            //    if (hit.transform.GetComponent<EnemyHealth>() != null)
            //    {
            //        curr_ene = hit.transform.GetComponent<EnemyHealth>();
            //        if (stack_crit && max_stack < 5)
            //        {
            //            crit_dmg += 0.1f;
            //            max_stack++;
            //        }
            //        if (focus_fire && hit.transform.GetComponent<EnemyHealth>() == curr_ene)
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg * 1.2f);
            //        }
            //        else
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg);
            //        }
                    
            //    }
            //    //Debug.Log("crit");
            //}
            //else if (Random.value < crit_rate)
            //{
            //    if (hit.transform.GetComponent<EnemyHealth>() != null)
            //    {
            //        curr_ene = hit.transform.GetComponent<EnemyHealth>();
            //        if (stack_crit && max_stack < 5)
            //        {
            //            crit_dmg += 0.1f;
            //            max_stack++;
            //        }
            //        if (focus_fire && hit.transform.GetComponent<EnemyHealth>() == curr_ene)
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg * 1.2f);
            //            //Debug.Log("focus");
            //        }
            //        else
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * crit_dmg);
            //        }
                    
            //    }
            //    //Debug.Log("crit");
            //}
            //else
            //{
            //    if (hit.transform.GetComponent<EnemyHealth>() != null)
            //    {
            //        curr_ene = hit.transform.GetComponent<EnemyHealth>();
            //        if (stack_crit && max_stack < 5)
            //        {
            //            crit_dmg += 0.1f;
            //            max_stack++;
            //        }
            //        if (focus_fire && hit.transform.GetComponent<EnemyHealth>() == curr_ene)
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg * 1.2f);
            //            //Debug.Log("focus");
            //        }
            //        else
            //        {
            //            hit.transform.GetComponent<EnemyHealth>().TakeDamage(dmg);
            //        }
                    
            //    }
                //Debug.Log("hit");
            //}
            
            
            //Debug.Log("attacking" + hit.transform.name);

            
            //curr_ene = hit.transform.GetComponent<Salamandermove>();
        }
        //ammoText.text = "Ammo: " + ammo.ToString();
        ammo--;
        if (ammo == 0)
        {
            reload_state = true;
            reloading = true;
        }

        attack_state = false;
    }

    public void take_dmg(float dmg, EnemyHealth enemy)
    {
        dmg -= negate_dmg;
        if (vulnerable)
        {
            if (shield > 0)
            {
                shield -= dmg;
            }
            else if (health > 0)
            {
                health -= dmg;
                //hp.value = health / max_health;
            }

            if (stack_crit)
            {
                crit_dmg -= max_stack * 0.1f;
                max_stack = 0;
            }
        }

        enemy.TakeDamage(reflect_dmg, deathdrop: deathdrop, reflect: true);
        
    }

    #region Basic_Card_funcs
    public void add_health(float extra_health)
    {
        health += extra_health;
        max_health += extra_health;
        //hp.value = health / max_health;
        Debug.Log("add h");
    }

    public void heal(float amount)
    {
        if (health < max_health)
        {
            health += amount;
            //hp.value = health / max_health;
        }
    }

    public void add_shields(float extra_shields)
    {
        shield += extra_shields;
        max_shield += extra_shields;
    }

    public void refresh_shields()
    {
        shield = max_shield;
    }

    public void add_ammo(int extra_ammo)
    {
        ammo += extra_ammo;
        max_ammo += extra_ammo;
        //ammoText.text = "Ammo: " + ammo.ToString();
    }

    public void reload()
    {
        ammo = max_ammo;
        reloading = false;
        //ammoText.text = "Ammo: " + ammo.ToString();
    }

    public void dec_reload(float time)
    {
        pa.reload_timer -= time;
    }

    public void add_crit_rate(float rate)
    {
        crit_rate += rate;
    }

    public void add_crit_dmg(float dmg)
    {
        crit_dmg += dmg;
    }
    #endregion

    #region Special_Card_funcs
    public void ace_clubs()
    {
        last_shot = true;
    }

    public void ace_diamonds()
    {
        StartCoroutine(countdown_invul(2));
    }

    public void jack_clubs()
    {
        stack_crit = true;
    }

    public void jack_diamonds()
    {
        reflect_dmg = 2f;
    }

    public void queen_diamonds()
    {
        negate_dmg = 2f;
    }

    public void ace_hearts()
    {
        vamp = 2f;
    }

    public void jack_spades()
    {
        focus_fire = 1.2f;
    }

    public void king_hearts()
    {
        deathdrop = true;
    }

    public void queen_hearts()
    {
        hitdrop = true;
    }

    public void jack_hearts()
    {
        selfdrop = true;
    }

    public void ace_spades()
    {
        dmg = dmg * 1.1f;
    }

    public void king_spades()
    {
        knockback = true;
    }



    #endregion
    private IEnumerator countdown_invul(float invul_timer)
    {
        float start = 0f;
        while (start <= invul_timer)
        {
            start += Time.deltaTime;
            vulnerable = false;
            yield return null;
        }
        vulnerable = true;
    }

    private IEnumerator countdown_drop(float selfdrop_timer)
    {
        float start = 0f;
        while (start <= selfdrop_timer)
        {
            start += Time.deltaTime;
            yield return null;
        }
        selfdrop_pause = false;
    }
}
