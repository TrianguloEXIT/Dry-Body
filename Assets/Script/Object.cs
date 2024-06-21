using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
   
    public SpriteRenderer MouseSprite;
    public Sprite MouseBase, MouseBusca;


    
    private void OnMouseEnter()
    {
       
       
        MouseSprite.sprite = MouseBusca;
    }

    private void OnMouseExit()
    {
        MouseSprite.sprite = MouseBase;
    }
}
