using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootSteps {get; private set;}
    [field: SerializeField] public EventReference hurt {get; private set;}
    
    [field: Header("")]

    [field: Header("World Effects")]
    [field: SerializeField] public EventReference ambience {get; private set;}

    public static FMODEvents instance {get; private set;}

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;
    }
}
