using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflySpawn : MonoBehaviour
{

    public int loc = 12;
    public int num = 12;
    public float spawn_time = 3f;
    public Transform player;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time_spawn(spawn_time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void spawn(int num, int loc)
    {
        Instantiate(cloud, player.position + new Vector3(12, 0, 0), Quaternion.identity);
    }

    private IEnumerator time_spawn(float spawn_time)
    {
        float start = 0f;
        while (start <= spawn_time)
        {
            start += Time.deltaTime;
            yield return null;
        }
        Debug.Log("butterflies");
        spawn(num, loc);
    }

}
