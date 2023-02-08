using UnityEngine;

public static class LayerMasks  {
	public static LayerMask Wall = LayerMask.GetMask ("Wall");
	public static LayerMask Ground = LayerMask.GetMask ("Ground", "Wall");
	public static LayerMask Stair = LayerMask.GetMask("Stair");
}
