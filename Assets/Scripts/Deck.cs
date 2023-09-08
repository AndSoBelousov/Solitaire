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

    //InitDeck ���������� ����������� Prospector, ����� ����� ����� 
    public void InitDeck(string deckXMLText)
    {
        ReadDeck(deckXMLText);
    }

    //ReadDeck ������ ��������� XML-���� � ������� ������ ����������� CardDefinition
    public void ReadDeck(string deckXMLText)
    {
        xmlr = new PT_XMLReader();
        xmlr.Parse(deckXMLText);

        //����� ����������� ������
        string s = "xml[0] decorator[0]";
        s += "type=" + xmlr.xml["xml"][0]["decorator"][0].att("type");
        s += " x=" + xmlr.xml["xml"][0]["decorator"][0].att("x");
        s += " y=" + xmlr.xml["xml"][0]["decorator"][0].att("y");
        s += " scale=" + xmlr.xml["xml"][0]["decorator"][0].att("scale");
        //print(s);
        
        // ��������� �������� <decorator> ��� ���� ����
        decorators = new List<Decorator>(); // ���������������� ������ � ����������� Decorator
        // ������� ������ PT_XMLHashList ���� ��������� <decorator> �� ��L-�����
        PT_XMLHashList xDecos = xmlr.xml["xml"][0]["decorator"];
        Decorator deco;
        for (int i = 0; i < xDecos.Count; i++)
        {
            // ��� ������� �������� <decorator> � XML
            deco = new Decorator(); // ������� ��������� Decorator
                                    // ����������� �������� �� <decorator> � Decorator
            deco.type = xDecos[i].att("type");
            // deco.flip ������� �������� true, ���� ������� flip ��������
            // ����� "1"
            deco.flip = (xDecos[i].att("flip") == "1"); // a
                                                        // �������� �������� float �� ��������� ���������
            deco.scale = float.Parse(xDecos[i].att("scale"));
            // Vector3 loc ���������������� ��� [0,0,0],
            // ������� ��� �������� ������ �������� ���
            deco.loc.x = float.Parse(xDecos[i].att("x"));
            deco.loc.y = float.Parse(xDecos[i].att("y"));
            deco.loc.z = float.Parse(xDecos[i].att("z"));
        // �������� deco � ������ decorators
        decorators.Add(deco);
    }
    // ��������� ���������� ��� �������, ������������ ����������� �����
    cardDefs = new List<CardDefinition>(); // ���������������� ������ ����
    // ������� ������ PT_XMLHashList ���� ��������� <card> �� XML-�����
    PT_XMLHashList xCardDefs = xmlr.xml["xml"][0]["card"];
    for (int i=0; icxCardDefs.Count; i++) {
        // ��� ������� �������� <card> ��������������� ���� �� �������� 693
    CardDefinition cDef = new CardDefinitionQ;
    //� �������� �������� �������� � �������� �� � �Def
    cDef.rank = int.Parse(xCardDefs[i].att ("rank�) );
    // ������� ������ PT_XMLHashList ���� ���������<pip>
    // ������ ����� �������� <card>
    PT_XMLHashList xPips = xCardDefs[i]["pip�];
    if (xPips != null) {
        for (int j = 0; jcxPips.Count; j++)
        {
            11 ������ ��� ��������<pip>
            deco = new Decorator();
            // �������� <pip> � <card> �������������� ������� Decorator
            deco.type = "pip";
            deco.flip = (xPips[j].att("flip") == "1");
            deco.loc.x = float.Parse(xPips[j].att("x"));
            deco.loc.y = float.Parse(xPips[j].att("y"));
            deco.loc.z = float.Parse(xPips[j].att("z"));
            if (xPips[j].HasAtt("scale"))
            {
                deco.scale = float.Parse(xPips[j].att("scale�) );
            }
            cDef.pips.Add(deco);
        }
    }
// ����� � ���������� (�����, ���� � ������) ����� ������� face
if (xCardDefs[i].HasAtt("face")) {
cDef.face = xCardDefs[i].att("face"); // b
}
cardDefs.Add(cDef);
}
}
}
    }
}
