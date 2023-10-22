using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways, ImageEffectAllowedInSceneView, RequireComponent(typeof(Camera))] // Execute in edit mode and in the scene view
public class CameraEffectBlit : MonoBehaviour
{
    public Material effectMaterial; // this is the material that will be used to render the effect
    public bool UseEffect = true;
    void OnRenderImage(RenderTexture src, RenderTexture dst) // this is the method that will be called when the camera is rendering
    {
            // eh, it works
            RenderTexture rt = RenderTexture.GetTemporary(src.width, src.height);
            Graphics.Blit(src, rt, effectMaterial);
            Graphics.Blit(rt, dst);
            RenderTexture.ReleaseTemporary(rt);
    }
}
