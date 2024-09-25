using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform[] backgrounds; 
    public float[] parallaxSpeeds;  
    public float maxDistance = 5f;  
    private float direction = 1f;   

    private Vector3[] startPositions; 

    void Start()
    {
    
        startPositions = new Vector3[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPositions[i] = backgrounds[i].position;
        }
    }

    void Update()
    {
        // Movimentar cada fundo 
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float movement = parallaxSpeeds[i] * direction * Time.deltaTime;
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + movement, backgrounds[i].position.y, backgrounds[i].position.z);

            // Verificar se o fundo atingiu a distância 
            if (Mathf.Abs(backgrounds[i].position.x - startPositions[i].x) > maxDistance)
            {
                direction *= -1; // Inverte 
            }
        }
    }
}

