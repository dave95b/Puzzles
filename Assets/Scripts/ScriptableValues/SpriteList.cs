using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpriteList", menuName = "Game data/Sprite list")]
public class SpriteList : ScriptableList<Sprite>
{
    public int ListIndex;
}
