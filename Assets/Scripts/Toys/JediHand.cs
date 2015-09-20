
public class JediHand : Item {


	protected override void Start () 
	{
		base.Start();
		Name = "Jedi Hand";
		Damage = 2;
		Use = "Push";
		gameObject.AddComponent<ForcePush>();
	}

//	public JediHand () 
//	{
//
////		Ability = typeof(ForcePush);
////		Ability = typeof(MoveRight);
//
//	}

//	public override void Test (GameObject obj)
//	{
//	//	base.Test(obj);
//	//	obj.AddComponent<YESITLIVES>();
//	//	Debug.Log("Override");
//	}


//	Destroy(gameObject.GetComponent("ComponentName"));




}
