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

	//float4 grayColor = dot(color, float4(0.3, 0.59, 0.11, 1));
	float minValue = 0.12f;

	//red
	if (color.r > minValue
		&& color.g < minValue
		&& color.b < minValue)
		return 
		//lerp(grayColor ,
			redColor
			//, 0.8f)
		;

	//green
	if (color.r < minValue
		&& color.g > minValue
		&& color.b < minValue)
		return
		//lerp(grayColor, 
			greenColor
			//, 0.8f)
		;

	//blue
	if (color.r < minValue
		&& color.g < minValue
		&& color.b > minValue)
		return 
		//lerp(grayColor, 
			blueColor
			//, 0.8f)
		;

	//yellow
	if (color.r > minValue
		&& color.g > minValue
		&& color.b < minValue)
		return 
		//lerp(grayColor, 
			yellowColor
			//, 0.8f)
		;

	//cyan
	if (color.r < minValue
		&& color.g > minValue
		&& color.b > minValue)
		return 
		//lerp(grayColor, 
			cyanColor
			//, 0.8f)
		;

	//magenta
	if (color.r > minValue
		&& color.g < minValue
		&& color.b > minValue)
		return 
		//lerp(grayColor, 
			magentaColor
			//, 0.8f)
		;

	return color;
}

technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_2_0 PixelShaderFunction();
	}
}
