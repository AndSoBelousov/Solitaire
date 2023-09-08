using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;
using static Card;

public class Deck : MonoBehaviour
{
    [Header("Set Dynamically")]
    public PT_XMLReader xmlr;
    public List<string> cardNames;
    public List<Card> cards;
    public List<Decorator> decorators;
    public List<CardDefinition> cardDefs;
    public Transform deckAnchor;
    public Dictionary<string, Sprite> dictSuits;

    //InitDeck вызывается экземпляром Prospector, когда будет готов 
    public void InitDeck(string deckXMLText)
    {
        ReadDeck(deckXMLText);
    }

    //ReadDeck читает указанный XML-файл и создает массив экземпляров CardDefinition
    public void ReadDeck(string deckXMLText)
    {
        xmlr = new PT_XMLReader();
        xmlr.Parse(deckXMLText);

        //вывод проверочной строки
        string s = "xml[0] decorator[0]";
        s += "type=" + xmlr.xml["xml"][0]["decorator"][0].att("type");
        s += " x=" + xmlr.xml["xml"][0]["decorator"][0].att("x");
        s += " y=" + xmlr.xml["xml"][0]["decorator"][0].att("y");
        s += " scale=" + xmlr.xml["xml"][0]["decorator"][0].att("scale");
        //print(s);
        
        // Прочитать элементы <decorator> для всех карт
        decorators = new List<Decorator>(); // Инициализировать список и экземпляров Decorator
        // Извлечь список PT_XMLHashList всех элементов <decorator> из ХМL-файла
        PT_XMLHashList xDecos = xmlr.xml["xml"][0]["decorator"];
        Decorator deco;
        for (int i = 0; i < xDecos.Count; i++)
        {
            // Для каждого элемента <decorator> в XML
            deco = new Decorator(); // Создать экземпляр Decorator
                                    // Скопировать атрибуты из <decorator> в Decorator
            deco.type = xDecos[i].att("type");
            // deco.flip получит значение true, если атрибут flip содержит
            // текст "1"
            deco.flip = (xDecos[i].att("flip") == "1"); // a
                                                        // Получить значения float из строковых атрибутов
            deco.scale = float.Parse(xDecos[i].att("scale"));
            // Vector3 loc инициализируется как [0,0,0],
            // поэтому нам остается только изменить его
            deco.loc.x = float.Parse(xDecos[i].att("x"));
            deco.loc.y = float.Parse(xDecos[i].att("y"));
            deco.loc.z = float.Parse(xDecos[i].att("z"));
        // Добавить deco в список decorators
        decorators.Add(deco);
    }
    // Прочитать координаты для значков, определяющих достоинство карты
    cardDefs = new List<CardDefinition>(); // Инициализировать список карт
    // Извлечь список PT_XMLHashList всех элементов <card> из XML-файла
    PT_XMLHashList xCardDefs = xmlr.xml["xml"][0]["card"];
    for (int i=0; icxCardDefs.Count; i++) {
        // Для каждого элемента <card> Конструирование карт из спрайтов 693
    CardDefinition cDef = new CardDefinitionQ;
    //И Получить значения атрибута и добавить их в сDef
    cDef.rank = int.Parse(xCardDefs[i].att ("rank”) );
    // Извлечь список PT_XMLHashList всех элементов<pip>
    // внутри этого элемента <card>
    PT_XMLHashList xPips = xCardDefs[i]["pip”];
    if (xPips != null) {
        for (int j = 0; jcxPips.Count; j++)
        {
            11 Обойти все элементы<pip>
            deco = new Decorator();
            // Элементы <pip> в <card> обрабатываются классом Decorator
            deco.type = "pip";
            deco.flip = (xPips[j].att("flip") == "1");
            deco.loc.x = float.Parse(xPips[j].att("x"));
            deco.loc.y = float.Parse(xPips[j].att("y"));
            deco.loc.z = float.Parse(xPips[j].att("z"));
            if (xPips[j].HasAtt("scale"))
            {
                deco.scale = float.Parse(xPips[j].att("scale”) );
            }
            cDef.pips.Add(deco);
        }
    }
// Карты с картинками (Валет, Дама и Король) имеют атрибут face
if (xCardDefs[i].HasAtt("face")) {
cDef.face = xCardDefs[i].att("face"); // b
}
cardDefs.Add(cDef);
}
}
}
    }
}
