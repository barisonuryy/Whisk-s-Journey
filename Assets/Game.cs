using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] Transform TopSinir;
    [SerializeField] Transform AltSinir;
    [SerializeField] Transform Fish;
    [SerializeField] Transform hook;

    float fishPosition;
    float fishDestination;
    bool pause = false;

    float fishTimer;
    [SerializeField] float timerimpact = 3f;

    float fishSpeed;

    [SerializeField] float Smoothing = 1f;

    float hookPosition;
    float hookPullVelocity;
    float hookProgress;
    [SerializeField] float hookSize = 0.05f;
    [SerializeField] float hookPower = 50f;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float HookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;

    [SerializeField] SpriteRenderer hookSpriteRenderer;

    [SerializeField] Transform progressBar;
    


    private void Start()
    {
         // Resize();


    }
     /* private void Resize()
     {

         Bounds b = hookSpriteRenderer.bounds;
         float ySize = b.size.y;
         Vector3 ls = hook.localScale;
         float distance = Vector3.Distance(TopS�n�r.position, AltS�n�r.position);
         ls.y = (distance / ySize * hookSize);
         hook.localScale = ls; */


    




    private void Update()
    {
        if (pause) { return;  }
        FishMovement();
        Hook();
        ProgressCheck();
    }
    private void ProgressCheck()
    {
        Vector3 ls = progressBar.localScale;
            ls.y = hookProgress;
        progressBar.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)

        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

        }
        if(hookProgress >= 250f )
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 100f, 250f); 

    }

    private void Win()
    {
        //pause = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Kazand�n");
    }


    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        hookPullVelocity -= HookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;
        hookPullVelocity = Mathf.Clamp(hookPullVelocity, 0f, 1f);
        hook.position = Vector3.Lerp(AltSinir.position, TopSinir.position, hookPosition);

        hookPosition += hookPullVelocity * Time.deltaTime; 
        hookPosition = Mathf.Clamp(hookPosition, hookSize /2, 1 - hookSize/2 ); 

       

        //float hookNormalizedPosition = Mathf.Clamp01(hookPosition); // hookPosition'� normalize edin

        ; // hookPosition'� kullanarak Lerp yap�n
    }

    void FishMovement()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerimpact;
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, Smoothing);
        Fish.position = Vector3.Lerp(AltSinir.position, TopSinir.position, fishPosition);
    }
}
