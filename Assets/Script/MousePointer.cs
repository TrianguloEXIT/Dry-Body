using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public Transform pointer;
    private Camera mainCamera;

    private void Start()
    {
        Cursor.visible = false;
        mainCamera = Camera.main;

        // Verifique se a câmera principal foi encontrada
        if (mainCamera == null)
        {
            Debug.LogError("Câmera principal não encontrada. Certifique-se de que há uma câmera na cena com a tag 'MainCamera'.");
        }
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            Vector3 mouse = Input.mousePosition;

            // Verifique se a posição do mouse está dentro dos limites da tela
            if (mouse.x >= 0 && mouse.x <= Screen.width && mouse.y >= 0 && mouse.y <= Screen.height)
            {
                mouse.z = 0.5f; // ou mainCamera.nearClipPlane para uma profundidade ajustada dinamicamente
                pointer.position = mainCamera.ScreenToWorldPoint(mouse);
            }
            else
            {
                Debug.LogWarning("Posição do mouse fora dos limites da tela.");
            }
        }
    }
}
