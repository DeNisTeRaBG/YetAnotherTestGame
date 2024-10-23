using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoDamage : MonoBehaviour, IDropHandler
{
    private GameObject theCard;
    private CardDisplay cStats;

    private GameObject parentGameObject;
    private Enemy eStats;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Card dropped on my ass damn");

        theCard = eventData.pointerDrag;
        Draggable d = theCard.GetComponent<Draggable>();

        if (d != null)
        {
            d.returnToParent = this.transform;

            cStats = theCard.GetComponent<CardDisplay>();

            int damage = ShieldDamage(eStats.currentShield, cStats.card.dmg);

            eStats.currentHP -= damage;
            eStats.currentShield += cStats.card.shield;

            eStats.vulnerable.buffValue += cStats.card.vulnerable.buffValue;
            eStats.weak.buffValue += cStats.card.weak.buffValue;
            eStats.strength.buffValue += cStats.card.strength.buffValue;
            eStats.ritual.buffValue += cStats.card.ritual.buffValue;

            Destroy(theCard);
        }
    }

    public int ShieldDamage(int shield, int dmg)
    {
        if (shield >= dmg)
        {
            eStats.currentShield = shield - dmg;
            return 0;
        }

        eStats.currentShield = 0;
        return dmg - shield;
    }

    void Start() 
    {
        parentGameObject = transform.parent.parent.gameObject;
        eStats = parentGameObject.GetComponent<Enemy>();
    }
}
