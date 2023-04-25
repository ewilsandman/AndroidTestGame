using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileHandleScript : MonoBehaviour
{
    private int _state = 0;
    
    [SerializeField] public int x;
    [SerializeField] public int y;
    
    [SerializeField] private Image image;
    [SerializeField] private GameHandlerScript handlerScript;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void HandleClick()
    {
        if (_state == 0)
        {
            _state = handlerScript.HandleClick(x,y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_state == 1)
        {
            image.color = Color.green;
            
        }
        else if (_state == 2)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
