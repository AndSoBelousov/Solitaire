using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [System.Serializable]
    public class Decorator//этот класс хранит информацию из DeckXML о каждом значке на карте 
    {
        public string type; //значек определяющий достоинство карты
        public Vector3 loc; //местоположения спрайта на карте
        public bool flip = false;   // признак перворота спрайта по вертикали 
        public float scale = 1f;    // масштаб спрайта
    }

    [System.Serializable]
    public class CardDefinition
    {
        public string face; //спрайт лицевой стороны карты 
        public int rank;    //достоинства карты(1-13)
        public List<Decorator> pips = new List<Decorator>(); // занчки
    }
}
