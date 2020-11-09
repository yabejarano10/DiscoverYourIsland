using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm =  GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        gm.ResetGame();
    }
}
