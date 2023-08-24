using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaraxBGNew : MonoBehaviour
{
    public Material[] backgrounds;             // Array of all the backgrounds to be parallaxed.
    public float parallaxScale;                 // The proportion of the camera's movement to move the backgrounds by.
    public float parallaxReductionFactor;       // How much less each successive layer should parallax.
    public float smoothing;                     // How smooth the parallax effect should be.

    public float autoMoveScale;

    [SerializeField]
    private Transform transPlayer;                      // Shorter reference to the main camera's transform.
    private Vector3 previousPlayerPos;             // The postion of the camera in the previous frame.


    void Awake()
    {
     
    }


    void Start()
    {
        // The 'previous frame' had the current frame's camera position.

        if(transPlayer)
            previousPlayerPos = transPlayer.position;
    }


    void Update()
    {
        // The parallax is the opposite of the camera movement since the previous frame multiplied by the scale.
        float parallax = 0;
        if (transPlayer)
            parallax = (previousPlayerPos.x - transPlayer.position.x) * parallaxScale;
        else
            parallax = autoMoveScale;

        // For each successive background...
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // ... set a target x position which is their current position plus the parallax multiplied by the reduction.
            float backgroundTargetPosX = backgrounds[i].GetTextureOffset("_MainTex").x - parallax * (i * parallaxReductionFactor);

            // Create a target position which is the background's current position but with it's target x position.
            Vector2 backgroundTargetPos = new Vector2(backgroundTargetPosX, 0);
            Vector2 newOffset = Vector2.Lerp(backgrounds[i].GetTextureOffset("_MainTex"), backgroundTargetPos, smoothing * Time.deltaTime);
            // Lerp the background's position between itself and it's target position.
            backgrounds[i].SetTextureOffset("_MainTex", newOffset) ;
            //backgrounds[i].position = Vector3.MoveTowards(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previousCamPos to the camera's position at the end of this frame.
        if (transPlayer)
            previousPlayerPos = transPlayer.position;
    }
}
