using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCanvasController : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void SelectItem()
    {
        var obj =  transform.parent.gameObject;
        bool win = gm.CheckSelection(obj);
        if(!win)
        {
            Disable();
        }
    }
}
