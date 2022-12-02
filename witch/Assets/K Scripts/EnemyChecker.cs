using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float maxtimer ;
    private float timer;
    [SerializeField]
    private int next_scene;

    [SerializeField]
    private SceneLoader s;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxtimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            int non_null = 0;
            foreach (GameObject g in enemies)
            {
                if (g != null)
                {
                    non_null++;
                }
            }
            if (non_null == 0)
            {
                scene_change();
                return;
            }
            timer = maxtimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }

    private void scene_change()
    {
        int i = next_scene;
        switch (i)
        {
            case 1:
                s.secondCard();
                break;
        }

    }
}
