using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

    public Sprite[] lifes;
    public Image heart;

    public Sprite[] books;
    public Image book;

    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        heart.sprite = lifes[pm.lifes];

        book.sprite = books[pm.bookTaken];

       if(pm.lifes == 0)
       {
            //Time.timeScale = 0.0f;
       }
    }
}
