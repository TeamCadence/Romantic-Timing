using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public List<GameObject> Selects;

    public int Index = 0;

    // Update is called once per frame
    void Update()
    {
        if(Index<0)
        {
            Index = 0;
        }
        else if(Selects.Count<Index)
        {
            Index = Selects.Count;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Selects[Index].GetComponent<SpriteRenderer>().color = Color.red;
            Index--;
            Selects[Index].GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Selects[Index].GetComponent<SpriteRenderer>().color = Color.white;
            Index++;
            Selects[Index].GetComponent<SpriteRenderer>().color = Color.red;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Selects[Index].GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("asd");
            }
        }
    }
}
