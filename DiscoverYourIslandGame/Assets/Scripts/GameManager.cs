using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject round1Prefab;
    [SerializeField] GameObject round2Prefab;
    [SerializeField] GameObject round3Prefab;
    [SerializeField] GameObject round4Prefab;

    private float levelCount = 1;
    private float LifeCount = 2;
    [SerializeField] Text objective;
    [SerializeField] Text Lifes;

    private GameObject clone1;
    private GameObject clone2;
    private GameObject clone3;
    private GameObject clone4;

    bool gameOver = false;

    // Start is called before the first frame update
    void Start ()
    {
        levelCount = 1;
        clone1 = Instantiate (round1Prefab);
        Lifes.text = $"{LifeCount}";
        DontDestroyOnLoad (this.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            if (EventSystem.current.IsPointerOverGameObject ())
            {
                Debug.Log ("Clicked on the UI");
            }
            else
            {
                Debug.Log ("Not ui");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                if (Physics.Raycast (ray, out hit, 100.0f))
                {
                    if (hit.transform.gameObject.tag == "Selectable" || hit.transform.gameObject.tag == "Win")
                    {
                        hit.transform.GetChild (0).gameObject.SetActive (true);
                    }
                }
            }

        }

        if (!gameOver)
        {
            CheckLife ();
        }
    }

    public bool CheckSelection (GameObject go)
    {
        if (go.tag == "Win")
        {
            levelCount++;
            ChangeRound (levelCount);
            return true;
        }
        else
        {
            LifeCount--;
            Lifes.text = $"{LifeCount}";
            return false;
        }
    }

    void ChangeRound (float level)
    {
        switch (level)
        {
            case 2:
                Destroy (clone1);
                clone2 = Instantiate (round2Prefab);
                objective.text = "Objetivo: Pan de fruta";
                break;
            case 3:
                Destroy (clone2);
                clone3 = Instantiate (round3Prefab);
                objective.text = "Objetivo: El Acuario";
                break;
            case 4:
                Destroy (clone3);
                clone4 = Instantiate (round4Prefab);
                objective.text = "Objetivo: La Piscinita";
                break;
            case 5:
                SceneManager.LoadScene ("WIN");
                break;
        }
    }

    void CheckLife ()
    {
        if (LifeCount <= 0)
        {
            SceneManager.LoadScene ("GameOverScene");
            gameOver = true;
        }
    }

    public void ResetGame ()
    {
        SceneManager.LoadScene ("MainGame");
        Destroy(this.gameObject);
    }
}