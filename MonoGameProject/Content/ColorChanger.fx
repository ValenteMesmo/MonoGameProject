sampler s0;

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(s0, coords);

	/*if (color.a)
		color.rgb = coords.y;*/
	if (color.a)
		color = float4(0.5, 0.5, 0.5, 0.5);

	return color;

}

technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}
