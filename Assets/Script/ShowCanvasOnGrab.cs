using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowCanvasOnGrab : MonoBehaviour
{
    public Canvas canvas; // Asigna el Canvas desde el inspector

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("No XRGrabInteractable found on the object.");
            return;
        }

        // Asegúrate de que el Canvas esté desactivado al inicio
        canvas.gameObject.SetActive(false);

        // Suscribirse a los eventos de XRGrabInteractable
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDestroy()
    {
        // Asegúrate de desuscribirte de los eventos para evitar errores
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed"); // Mensaje de depuración
        // Activar el Canvas cuando el objeto es agarrado
        canvas.gameObject.SetActive(true);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released"); // Mensaje de depuración
        // Desactivar el Canvas cuando el objeto es soltado
        canvas.gameObject.SetActive(false);
    }
}
