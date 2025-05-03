using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float cubeMaxPosX;
    [Space]
    [SerializeField] private TouchSlider touchSlider;
    [SerializeField] private Cube mainCube;
    private bool isPointerDown;
    private Vector3 cubePos;
    private void Start()
    {
        // TODO Spawn new cube
        // listen to touch slider events
        touchSlider.onpointerDownEvent += OnPointerDown;
        touchSlider.onpointerDragEvent += OnPointerDrag;
        touchSlider.onpointerUpEvent += OnPointerUp;
      
    }
    private void Update() {
        if (isPointerDown)
        {
            mainCube.transform.position = Vector3.Lerp(
                mainCube.transform.position,
                cubePos,
                moveSpeed * Time.deltaTime);
            Vector3 clampedPosition = mainCube.transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x,-cubeMaxPosX, cubeMaxPosX);
            mainCube.transform.position = clampedPosition;
        }
    }
    private void OnPointerDown()
    {
        isPointerDown = true;
    }
    private void OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;
            mainCube.CubeRigidBody.AddForce(Vector3.forward * pushForce,ForceMode.Impulse);
        }
        // TODO: spwan a new cube after 0.5 seconds.
    }
    private void OnPointerDrag(float xMovement)
    {
        cubePos =mainCube.transform.position;
        cubePos.x = xMovement * cubeMaxPosX ;
 
    }
    private void OnDestroy()
    {
        touchSlider.onpointerDownEvent -= OnPointerDown;
        touchSlider.onpointerUpEvent -= OnPointerUp;
        touchSlider.onpointerDragEvent -= OnPointerDrag;

    }
}
