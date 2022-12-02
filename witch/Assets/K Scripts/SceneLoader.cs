using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        
        if(instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelone()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    public void secondCard()
    {
        SceneManager.LoadScene("SecondCard");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Complex scene");
    }

}
