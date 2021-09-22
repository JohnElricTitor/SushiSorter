using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiType : MonoBehaviour
{
    [HideInInspector] public enum sushiTypes { Maki, Nigiri, Ikura, Roll };
    public sushiTypes sushi;
}
