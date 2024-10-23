using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effects")]

public class StatusEffects : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public int TurnDuration;

}
