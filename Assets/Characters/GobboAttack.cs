using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GobboAttack : MonoBehaviour
{
    private TurnBasedBehaviour turn;

    private int _cycleLength = 2;

    public List<Card> Attacks = new List<Card>();

    Enemy enemy;
    Character player;

    private Button drawButton;

    private int intent = 0;

    private Image intentSprite;
    public List<Sprite> intentSpriteList = new List<Sprite>();

    private int picked = 0;




    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        drawButton = GameObject.FindGameObjectWithTag("EndTurn").GetComponent<Button>();

        turn = GameObject.FindGameObjectWithTag("GM").GetComponent<TurnBasedBehaviour>();

        intentSprite = this.gameObject.transform.GetChild(0).GetChild(3).GetComponent<Image>(); //GameObject.FindGameObjectWithTag("Intent").GetComponent<Image>();

        PickIntent();
    }

    void PickIntent()
    {
        intent = Random.Range(0, 1);

        intentSprite.sprite = intentSpriteList[intent];
        picked = intent;

    }

    public void UseAttack()
    {
        Debug.Log(Attacks[picked].dmg);
        transform.DOLocalMoveY(1, 1).SetLoops(2, LoopType.Yoyo);
        StartCoroutine(TakeDmg());
        PickIntent();
    }


    IEnumerator TakeDmg()
    {
        yield return new WaitForSeconds(2f);
        player.currentHP -= Attacks[picked].dmg;
    }
}