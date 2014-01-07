using System.Collections;

public class TrackedBundleVersion
{
	public static readonly string bundleIdentifier = "at.technikum.mgs.healthgame";

	public static readonly TrackedBundleVersionInfo Version_1_21 =  new TrackedBundleVersionInfo ("1.21", 0);
	
	public ArrayList history = new ArrayList ();

	public TrackedBundleVersionInfo current = new TrackedBundleVersionInfo ("1.21", 0);

	public  TrackedBundleVersion() {
		history.Add (current);
	}

}
