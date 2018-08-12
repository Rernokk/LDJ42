Shader "Hidden/HPShader"
{
	Properties
	{
		_ColorA("Health Color", Color) = (1,1,1,1)
		_ColorB("Fade Color", Color) = (.25,.25,.25,.5)
		_Value("Health Value", Range(0, 1)) = 1.0
	}
	SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 _ColorA;
			fixed4 _ColorB;
			fixed _Value;

			fixed4 frag (v2f i) : SV_Target
			{
				if (i.uv.x <= _Value) {
					return _ColorA;
				} else {
					return _ColorB;
				}
			}
			ENDCG
		}
	}
}
