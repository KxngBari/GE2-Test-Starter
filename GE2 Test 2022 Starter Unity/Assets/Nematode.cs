using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;

    [SerializeField]
    Gradient gradient;

    public Material material;

    void Awake()
    {
        for (int i = 0; i < length; i++)
        {
            float value = Mathf.Lerp(0f, 1f, (i/(float)length));
            Color color = gradient.Evaluate(value);
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = transform.position - transform.forward *i;
            sphere.transform.parent = transform;
            var sphereRenderer = sphere.GetComponent<Renderer>();
            sphereRenderer.material.SetColor("_Color", color);

            if (i == 0)
            {
                sphere.AddComponent(typeof(NoiseWander));
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
