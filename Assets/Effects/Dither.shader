Shader "Unlit/Dither"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DitherTex ("Dither Texture", 2D) = "white" {}
        _ColourRampTex ("Colour Ramp Texture", 2D) = "white" {}
        _BaseLuminance ("Base Luminance", Range(-1,1)) = 0.5
        _lR ("Luminance Red", Range(-1,1)) = 0.1
        _lG ("Luminance Green", Range(-1,1)) = 0.5
        _lB ("Luminance Blue", Range(-1,1)) = 0.1

    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always // All my homies hate the Z-buffer

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _DitherTex;
            float4 _DitherTex_ST;

            sampler2D _ColourRampTex;
            
            float _BaseLuminance;
            float _lR;
            float _lG;
            float _lB;
            
            v2f vert (appdata v) // normal vertex shader
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float lum = dot(col,float3(_lR,_lG,_lB)) + _BaseLuminance;

                float2 ditherUV = i.uv * _DitherTex_ST.xy + _DitherTex_ST.zw;
                float dither = tex2D(_DitherTex, ditherUV);

                float ramp = (lum <= clamp(dither, 0.1f, 0.9f)) ? 0.1f : 0.9f;
                float3 color_out = tex2D(_ColourRampTex, float2(ramp, 0.5f));
                return float4(color_out,1.0f);
            }
            ENDCG
        }
    }
}
