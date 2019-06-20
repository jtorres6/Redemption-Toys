using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMaterial : MonoBehaviour {
	/*0 -> cloth; 1 -> cotton; 2 -> thread; 3-> sheet; 4->wood; 5 -> gear;
	 * 6->leather;7->plastic;8->porcelain*/
	public int type;

	//0->nuevo; 1->arreglado
	public int status;

    public int repairPrice;
    public int buyPrice;
}
