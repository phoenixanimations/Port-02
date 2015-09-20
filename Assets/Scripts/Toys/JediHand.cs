
public class JediHand : Item 
{
	protected override void Start () 
	{
		base.Start();
		Name = "Jedi Hand";
		Damage = 2;
		gameObject.AddComponent<ForcePush>();
	}
}
