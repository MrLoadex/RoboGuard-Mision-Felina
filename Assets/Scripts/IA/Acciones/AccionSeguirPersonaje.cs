using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "IA/Acciones/Seguir Personaje")]
public class AccionSeguirPersonaje : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        SeguirPersonaje(controller);
    }

    private void SeguirPersonaje(IAController controller)
    {
        if(controller.PersonajeReferencia == null)
        {
            return;
        }

        // Mirar hacia el personaje
        controller.transform.LookAt(controller.PersonajeReferencia.transform.position);

        // Calcular distancia hacia el personaje
        Vector3 direccionHaciaPersonaje = controller.PersonajeReferencia.transform.position - controller.transform.position;
        Vector3 direccion = direccionHaciaPersonaje.normalized;
        float distanciaDelPersonaje = direccionHaciaPersonaje.magnitude;

        if (distanciaDelPersonaje >= 1.5f)
        {
            controller.transform.Translate(direccion * controller.VelocidadMovimiento * Time.deltaTime);
        }
    }
}
