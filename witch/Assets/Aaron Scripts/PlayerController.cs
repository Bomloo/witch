using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public GameObject shootpt;
    public PlayerAction pa;

    public bool crouch_state = false;
    public bool move_state = false;
    public bool reload_state = false;
    public bool reloading = false;

    public int health = 100;
    public int max_health = 100;
    public int shield = 0;
    public int max_shield = 0;

    public int ammo = 2;
    public int max_ammo = 2;
    public int range = 10;
    public float dmg = 20;
    public float crit_rate = 0.1f;
    public float crit_dmg = 1.2f;
    

    public Card[] hand= new Card[3];
    
    //add hp max
    //add shields max
    //heal hp
    //shield refresh


    //critrate
    //ammo

    

    // key down on crouch, key up no crouch
    // crouch only active behind cover, needs detection
    // player controller does the actual work
    // player movement triggers controller functions to move
    void Start()
    {
        
    }

    

    public void move(float x, float y)
    {
        move_state = true;
        crouch_state = false;
        bc.enabled = true;
        Vector2 target_velocity = new Vector2(x, y);
        rb.velocity = target_velocity;
        //Debug.Log("moving");
    }

    public void attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(shootpt.transform.position, shootpt.transform.up, range);
        ammo--;
        if (hit.collider == null)
        {
            Debug.Log("missed");
        }
        else
        {
            Debug.Log("attacking" + hit.transform.name);
        }
        
        if (ammo == 0)
        {
            reload_state = true;
            reloading = true;
        }
    }

    public void crouch()
    {
        crouch_state = true;
        move_state = false;
        bc.enabled = false;
        Debug.Log("crouching");
    }

    public void take_dmg(int dmg)
    {
        if (shield > 0)
        {
            shield -= dmg;
        }
        else if (health > 0)
        {
            health -= dmg;
        }
    }

    public void add_health(int extra_health)
    {
        health += extra_health;
        max_health += extra_health;
    }

    public void heal(int amount)
    {
        health += amount;
        if (health > max_health)
        {
            health = max_health;
        }
    }

    public void add_shields(int extra_shields)
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
}
