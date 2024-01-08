using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    public ColorType colorType;
    public Material[] colorMat;
    [SerializeField] private ColorData colorData;
    [SerializeField] private MeshRenderer renderer;
    // Start is called before the first frame update
    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = colorData.GetColorMat(colorType);
    }

   
}
