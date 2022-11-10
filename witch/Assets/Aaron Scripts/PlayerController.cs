using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public GameObject shootpt;
    public PlayerAction pa;

    public bool attack_state = false;
    public bool move_state = false;
    public bool reload_state = false;
    public bool reloading = false;
    public bool dash_state = false;
    public bool resting = false;

    public float health = 100;
    public float max_health = 100;
    public float shield = 0;
    public float max_shield = 0;
    public bool vulnerable = true;
    public bool reflect = false;
    public float reflect_dmg = 0f;
    public float negate_dmg = 0f;

    public int ammo = 2;
    public int max_ammo = 2;
    public int range = 10;
    public float dmg = 20;
    public float crit_rate = 0.1f;
    public float crit_dmg = 1.2f;
    public bool last_shot = false;
    public bool stack_crit = false;
    public int max_stack = 0;
    public float vamp = 0f;
    public bool focus_fire = false;
    public EnenemyHealth curr_ene = null;
    
    
    public Card[] hand= new Card[3];
    public int indx = 0;

    public void add_hand (Card card)
    {
        if (indx < 3)
        {
            hand[indx] = card;
            if (card.isActive == false)
            {
                card.StartPassive(this);
            }
            indx++;
        }
        else
        {
            Destroy(card.gameObject);
        }
    }

    public void move(float x, float y)
    {
        if (x == 0 && y == 0)
        {
            move_state = false;
        }
        else if (dash_state == true)
        {
            move_state = false;
        }
        else
        {
            move_state = true;
        }
        Vector2 target_velocity = new Vector2(x, y);
        rb.velocity = target_velocity;
        //Debug.Log("moving");
    }

    public void attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.transform.position, shootpt.transform.up, range);
        
        if (hit.collider == null)
        {
            Debug.Log("missed");
        }
        else
        {
            if (ammo == 1 && last_shot)
            {
                if (hit.transform.GetComponent<EnenemyHealth>() != null)
                {
                    if (focus_fire && hit.transform.GetComponent<EnenemyHealth>() == curr_ene)
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg * crit_dmg * 1.2f);
                    }
                    else
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg * crit_dmg);
                    }
                    
                }
                Debug.Log("crit");
            }
            else if (Random.value < crit_rate)
            {
                if (hit.transform.GetComponent<EnenemyHealth>() != null)
                {
                    if (focus_fire && hit.transform.GetComponent<EnenemyHealth>() == curr_ene)
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg * crit_dmg * 1.2f);
                    }
                    else
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg * crit_dmg);
                    }
                    
                }
                Debug.Log("crit");
            }
            else
            {
                if (hit.transform.GetComponent<EnenemyHealth>() != null)
                {
                    if (focus_fire && hit.transform.GetComponent<EnenemyHealth>() == curr_ene)
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg * 1.2f);
                    }
                    else
                    {
                        hit.transform.GetComponent<EnenemyHealth>().TakeDamage(dmg);
                    }
                    
                }
                Debug.Log("hit");
            }
            
            if (stack_crit && max_stack < 5)
            {
                crit_dmg += 0.1f;
                max_stack++;
            }
            //Debug.Log("attacking" + hit.transform.name);

            heal(vamp);
            //curr_ene = hit.transform.GetComponent<Salamandermove>();
        }
        ammo--;
        if (ammo == 0)
        {
            reload_state = true;
            reloading = true;
        }

        attack_state = false;
    }

    //public void crouch()
    //{
    //    crouch_state = true;
    //    move_state = false;
    //    //Debug.Log("crouching");
    //}

    public void take_dmg(float dmg)
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
            }

            if (stack_crit)
            {
                crit_dmg -= max_stack * 0.1f;
                max_stack = 0;
            }
        }

        if (reflect)
        {
            // enemycontroller.takedamage(reflect_dmg);
        }
        
    }

    public void add_health(float extra_health)
    {
        health += extra_health;
        max_health += extra_health;
    }

    public void heal(float amount)
    {
        if (health < max_health)
        {
            health += amount;
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
    }

    public void reload()
    {
        ammo = max_ammo;
        reloading = false;
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

    public void ace_clubs()
    {
        last_shot = true;
    }

    public void ace_diamonds()
    {
        vulnerable = false;
        StartCoroutine(countdown_invul(2));
    }

    public void jack_clubs()
    {
        stack_crit = true;
    }

    public void jack_diamonds()
    {
        reflect = true;
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
        focus_fire = true;
    }

    public void king_spades()
    {

    }

    private IEnumerator countdown_invul(float invul_timer)
    {
        yield return new WaitForSeconds(invul_timer);
        vulnerable = true;
    }
}
