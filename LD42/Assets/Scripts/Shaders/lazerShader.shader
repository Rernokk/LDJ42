// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:32235,y:32601,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8bf9ce383de0409478ad24150aa1adcd,ntxv:0,isnm:False|UVIN-6473-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32793,varname:node_2393,prsc:2|A-1886-OUT,B-2053-RGB,C-797-RGB,D-9248-OUT,E-6894-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32235,y:33081,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6894,x:32467,y:33027,varname:node_6894,prsc:2|A-6074-A,B-797-A;n:type:ShaderForge.SFN_Time,id:5874,x:31605,y:32413,varname:node_5874,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7368,x:31343,y:32618,ptovrint:False,ptlb:xoffset,ptin:_xoffset,varname:node_7368,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:743,x:31343,y:32751,ptovrint:False,ptlb:yoffset,ptin:_yoffset,varname:node_743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:9567,x:31617,y:32591,varname:node_9567,prsc:2|A-7368-OUT,B-743-OUT;n:type:ShaderForge.SFN_Multiply,id:2522,x:31853,y:32556,varname:node_2522,prsc:2|A-2396-OUT,B-9567-OUT;n:type:ShaderForge.SFN_TexCoord,id:3576,x:31853,y:32338,varname:node_3576,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:6473,x:32048,y:32459,varname:node_6473,prsc:2|A-3576-UVOUT,B-2522-OUT;n:type:ShaderForge.SFN_Multiply,id:2396,x:31835,y:32722,varname:node_2396,prsc:2|A-5874-T,B-3259-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3259,x:31617,y:32768,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_3259,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-2;n:type:ShaderForge.SFN_Tex2d,id:358,x:32283,y:32182,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ca55956ce8f51c946ba6b5f47d20a064,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2706,x:32283,y:32389,ptovrint:False,ptlb:Maskt,ptin:_Maskt,varname:node_2706,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ca55956ce8f51c946ba6b5f47d20a064,ntxv:0,isnm:False|UVIN-6473-OUT;n:type:ShaderForge.SFN_Multiply,id:1886,x:32493,y:32382,varname:node_1886,prsc:2|A-2706-RGB,B-6074-RGB,C-358-RGB;proporder:6074-797-7368-743-3259-2706-358;pass:END;sub:END;*/

Shader "Shader Forge/lazerShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _xoffset ("xoffset", Float ) = 1
        _yoffset ("yoffset", Float ) = 0
        _Speed ("Speed", Float ) = -2
        _Maskt ("Maskt", 2D) = "white" {}
        _Mask ("Mask", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _xoffset;
            uniform float _yoffset;
            uniform float _Speed;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform sampler2D _Maskt; uniform float4 _Maskt_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_5874 = _Time;
                float2 node_6473 = (i.uv0+((node_5874.g*_Speed)*float2(_xoffset,_yoffset)));
                float4 _Maskt_var = tex2D(_Maskt,TRANSFORM_TEX(node_6473, _Maskt));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_6473, _MainTex));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float3 emissive = ((_Maskt_var.rgb*_MainTex_var.rgb*_Mask_var.rgb)*i.vertexColor.rgb*_TintColor.rgb*2.0*(_MainTex_var.a*_TintColor.a));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.5,0.5,0.5,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
