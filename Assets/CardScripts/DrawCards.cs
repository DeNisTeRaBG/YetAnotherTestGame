using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    GameObject player;

    private Stack<GameObject> drawPile = new Stack<GameObject>();
    private Stack<GameObject> discardPile = new Stack<GameObject>();
    private List<GameObject> cardsInHand = new List<GameObject>();

    public Transform parent;

    [SerializeField] Button drawButton;

    private int maxAmountOfCardsInHand = 8;
    public float waitDelay = 0.4f;

    private void Awake()
    {
        drawButton.onClick.AddListener(() => StartCoroutine(DrawOneCardCoroutine(waitDelay)));
    }

    public void DrawACard()
    {
        if (cardsInHand.Count == maxAmountOfCardsInHand)
        {
            if (drawPile.Count == 0) Shuffle();

            GameObject card = drawPile.Pop();

            Debug.Log($"{card.name} was drawn");

            GameObject childCard = Instantiate(card);
            childCard.transform.SetParent(parent);
        }
    }

    public void DrawCards(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            StartCoroutine(DrawOneCardCoroutine(waitDelay * i));
        }
    }

    private IEnumerator DrawOneCardCoroutine(float waitDelay)
    {
        if (drawPile.Count == 0)
        {
            if (discardPile.Count == 0)
            {
                yield break; //No possible cards to draw
            }

            while (discardPile.Count > 0)
            {
                var cardToAdd = discardPile.Pop();
                drawPile.Push(cardToAdd);
            }
        }

        yield return new WaitForSeconds(waitDelay);
        GameObject card = drawPile.Pop();
        GameObject childCard = Instantiate(card);
        childCard.transform.SetParent(parent);
    }

    public void Shuffle()
    {
        List<GameObject> listDiscard = new List<GameObject>(discardPile);

        for (int i = 0; i < listDiscard.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, listDiscard.Count);
            GameObject temp = listDiscard[i];
            listDiscard[i] = listDiscard[randomIndex];
            listDiscard[randomIndex] = temp;
        }

        drawPile = new Stack<GameObject>(listDiscard);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        drawPile = new Stack<GameObject>(player.GetComponent<Player>().deck);

        DrawCards(amount: 2);
    }
}