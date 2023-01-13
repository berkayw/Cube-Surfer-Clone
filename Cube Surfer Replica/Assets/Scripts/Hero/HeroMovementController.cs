using UnityEngine;

public class HeroMovementController : MonoBehaviour
{

    [SerializeField] private HeroInputController heroInputController;

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;

    [SerializeField] private float horizontalLimitValue;

    private float newPositionX;

    // Update is called once per frame
    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + heroInputController.GetHorizontalValue() * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue); //Limit
        
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        
        
    }
}
