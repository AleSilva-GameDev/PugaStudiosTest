using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChooseCharacter", menuName = "ChooseCharacter")]
public class ChooseCharacter : ScriptableObject
{
    public Sprite image;
    public new string name;
    public string description;
}
