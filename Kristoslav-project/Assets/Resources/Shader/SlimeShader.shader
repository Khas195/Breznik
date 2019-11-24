Shader "Custom/SlimeShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SpecMap("Spec Map", 2D) = "white" {}
        _BumpMap("Bump map", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
       _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
       _RimLimit ("Rim Size", Range(0,1.0)) = 0.5
       _ScrollXSpeed("Scroll X Speed", Range(-10,10)) = 2
		_ScrollYSpeed("Scroll Y Speed", Range(-10,10)) = 2
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 200
        Blend SrcAlpha OneMinusSrcAlpha
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _SpecMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_SpecMap;
            float3 viewDir;
        };

        half _Glossiness;
        fixed4 _Color;
        float4 _RimColor;
        float _RimPower;
        float _RimLimit;
        fixed _ScrollXSpeed;
        fixed _ScrollYSpeed;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed offsetX = _ScrollXSpeed * _Time;
            fixed offsetY = _ScrollYSpeed * _Time;
            fixed2 offsetUV = fixed2(offsetX, offsetY);
            

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            fixed4 metallic =  tex2D(_SpecMap, IN.uv_SpecMap);
            o.Metallic = metallic.r;
            o.Smoothness = metallic.a * _Glossiness;

            fixed ScrollUV = IN.uv_BumpMap + offsetUV;

            o.Normal = UnpackNormal(tex2D(_BumpMap, ScrollUV));



            half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow (rim, _RimPower);
            if (rim <= _RimLimit) {
                o.Alpha = c.a;
            } else {
                o.Alpha = rim;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
