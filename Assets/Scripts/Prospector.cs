using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Prospector : MonoBehaviour
{
    static public Prospector _singleton;
        

    [Header("Set in Inspector")]
    public TextAsset deckXML;

    [Header("Set Dinamically")]
    public Deck deck;

    private void Awake()
    {
        _singleton= this;
    }

    private void Start()
    {
        deck = GetComponent<Deck>();
        deck.InitDeck(deckXML.text);
    }
}
