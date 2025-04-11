#include <Packages/com.blendernodesgraph.core/Editor/Includes/Importers.hlsl>

void _4DNoise_float(float3 _POS, float3 _PVS, float3 _PWS, float3 _NOS, float3 _NVS, float3 _NWS, float3 _NTS, float3 _TWS, float3 _BTWS, float3 _UV, float3 _SP, float3 _VVS, float3 _VWS, Texture2D image_242508, out float4 ColorOut)
{
	
	float4 _Mapping_242524 = float4(mapping_point(float4(_UV, 0), float3(0, 0, 0), float3(0, 0, 0), float3(1, 1, 1)), 0);
	float4 _ImageTexture_242508 = node_image_texture(image_242508, _Mapping_242524, 0);

	ColorOut = _ImageTexture_242508;
}