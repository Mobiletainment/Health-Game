using System.Collections;

public class TrackedBundleVersion
{
	public static readonly string bundleIdentifier = "at.technikum.mgs.healthgame";

	public static readonly TrackedBundleVersionInfo Version_1_21 =  new TrackedBundleVersionInfo ("1.21", 0);
	public static readonly TrackedBundleVersionInfo Version_1_22 =  new TrackedBundleVersionInfo ("1.22", 1);
	public static readonly TrackedBundleVersionInfo Version_1_23 =  new TrackedBundleVersionInfo ("1.23", 2);
	
	public ArrayList history = new ArrayList ();

	public TrackedBundleVersionInfo current = new TrackedBundleVersionInfo ("1.23", 2);

	public  TrackedBundleVersion() {
		history.Add (Version_1_21);
		history.Add (Version_1_22);
		history.Add (current);
	}

}
