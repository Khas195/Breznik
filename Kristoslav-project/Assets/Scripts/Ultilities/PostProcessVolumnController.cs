using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;
using UnityEngine.Rendering;

public class PostProcessVolumnController : MonoBehaviour
{
    [SerializeField]
    [Required]
    Volume volume = null;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float changePercentage;
    [SerializeField]
    [ReadOnly]
    float targetBloom = 0f;
    Bloom bloomComponent;

    void Start()
    {
        Bloom testBloom;
        if (volume.profile.TryGet<Bloom>(out testBloom))
        {
            bloomComponent = testBloom;
        }
    }
    public void SetBloom(float bloom)
    {
        targetBloom = bloom;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        bloomComponent.intensity.value = Mathf.Lerp(bloomComponent.intensity.value, targetBloom, changePercentage);
    }
}
