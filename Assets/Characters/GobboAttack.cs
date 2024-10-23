using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GobboAttack : MonoBehaviour
{
    public int dmg = 6;
    public int snow = 2;

    public List<Card> Attacks = new List<Card>();

    Enemy enemy;
    Character player;

    private Button drawButton;

    private int intent=0;

    private Image intentSprite;
    public List<Sprite> intentSpriteList = new List<Sprite>();

    private int picked = 0;




    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        drawButton = GameObject.FindGameObjectWithTag("EndTurn").GetComponent<Button>();

        intentSprite = this.gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>(); //GameObject.FindGameObjectWithTag("Intent").GetComponent<Image>();

        PickIntent();
    }

    void PickIntent()
    {
        intent = Random.Range(0, 10);

        Debug.Log(intent);

        if (intent < 5)
        {
            picked = 0;
            intentSprite.sprite = intentSpriteList[1];
        }
        else
        {
            picked = 1;
            intentSprite.sprite = intentSpriteList[0];
        }

    }

    void UseAttack()
    {
        if (picked == 0)
        {
            player.currentHP -= dmg;
        }
        else if (picked == 1)
        {
            player.currentHP -= snow;
        }
    }
}
