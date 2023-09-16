using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Image))]
public class chabgeButtonColor : MonoBehaviour
{
    public Color Color;
    public player Player;

    [Header("References")]
    public Image UIimage;

    public void OnValidate()
    {
        UIimage = GetComponent<Image>();
    }
    void start()
    {
        UIimage.color = Color;
    }

    public void OnClick()
    {
        Player.ChangeColor(Color);
    }
}
