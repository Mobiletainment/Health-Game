Shader "Custom/VertexLitAlphaColoring" 
{ 
	Properties 
	{ 
		_AlphaColor ("Alpha Color", Color) = (1,1,1,1) 
		_MainTex ("Base (RGB)", 2D) = "white" {} 
	}

    SubShader 
    {
	    Tags { "RenderType" = "Opaque" }
	    LOD 80
	     
	    Pass {
		    Tags { "LightMode" = "Vertex" }
		     
		    // Setup Basic
		    Material 
		    {
			    Diffuse (1,1,1,1)
			    Ambient (1,1,1,1)
		    }
		    
		    Lighting On
		    
		    // Lerp between AlphaColor and the basic vertex lighting color
		    SetTexture [_MainTex] {
			    constantColor [_AlphaColor]
			    combine previous lerp(texture) constant DOUBLE, previous lerp(texture) constant
		    }
		    
		    // Multiply in texture
		    SetTexture [_MainTex] {
		    	combine texture * previous
		    }
	    }
    }
}