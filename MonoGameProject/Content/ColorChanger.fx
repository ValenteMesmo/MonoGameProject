sampler s0;

float4 redColor;
float4 greenColor;
float4 blueColor;
float4 yellowColor;
float4 cyanColor;
float4 magentaColor;

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
	float4 color = tex2D(s0, coords);

	if (color.r == 0 && color.g == 0 && color.b == 0)
		return color;

	float minValue = 0.15f;

	//red
	if (color.r > minValue
		&& color.g < minValue
		&& color.b < minValue)
		return redColor;

	//green
	if (color.r < minValue
		&& color.g > minValue
		&& color.b < minValue)
		return greenColor;

	//blue
	if (color.r < minValue
		&& color.g < minValue
		&& color.b > minValue)
		return blueColor;

	//yellow
	if (color.r > minValue
		&& color.g > minValue
		&& color.b < minValue)
		return yellowColor;

	//cyan
	if (color.r < minValue
		&& color.g > minValue
		&& color.b > minValue)
		return cyanColor;

	//magenta
	if (color.r > minValue
		&& color.g < minValue
		&& color.b > minValue)
		return magentaColor;

	return color;
}

technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}
