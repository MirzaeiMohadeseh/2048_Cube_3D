using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text[] numbersText;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;
    [HideInInspector] public Rigidbody CubeRigidBody;
    private MeshRenderer cubeMeshRenderer;
    [HideInInspector] public bool IsMainCube;

    private void Awake()
    {
        CubeRigidBody = GetComponent<Rigidbody>();
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        CubeColor = color;
        cubeMeshRenderer.material.color = color;
    }
    public void SetNumber(int number)
    {
        CubeNumber = number;
        for(int i = 0; i<6; i++)
        {
            numbersText[i].text = number.ToString();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
