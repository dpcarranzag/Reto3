using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LevelOne()
    {
        //SceneManager.LoadScene(2);
    }
    private void LevelTwoo()
    {
        //SceneManager.LoadScene(2);
    }
    private void LevelThree()
    {
        //SceneManager.LoadScene(2);
    }
    public void LevelFour()
    {
        SceneManager.LoadScene(1);
    }
}
