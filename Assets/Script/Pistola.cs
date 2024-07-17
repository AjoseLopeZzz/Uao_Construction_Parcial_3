using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistola : MonoBehaviour
{
    public XRGrabInteractable grabInteract;
    public DisparoRay disparo;

    void Start()
    {
        grabInteract.activated.AddListener(x => Disparando());
        grabInteract.deactivated.AddListener(x => DejarDisparo());
    }

    public void Disparando()
    {
        disparo.Disparar();
    } 

    public void DejarDisparo()
    {

    }
}
