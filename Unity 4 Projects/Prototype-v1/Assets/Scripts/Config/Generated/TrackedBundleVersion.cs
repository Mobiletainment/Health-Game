using System.Collections;

public class TrackedBundleVersion
{
	public static readonly string bundleIdentifier = "at.technikum.mgs.healthgame";

	public static readonly TrackedBundleVersionInfo Version_1_21 =  new TrackedBundleVersionInfo ("1.21", 0);
	public static readonly TrackedBundleVersionInfo Version_1_22 =  new TrackedBundleVersionInfo ("1.22", 1);
	public static readonly TrackedBundleVersionInfo Version_1_23 =  new TrackedBundleVersionInfo ("1.23", 2);
	public static readonly TrackedBundleVersionInfo Version_1_31 =  new TrackedBundleVersionInfo ("1.31", 3);
	public static readonly TrackedBundleVersionInfo Version_1_80 =  new TrackedBundleVersionInfo ("1.80", 4);
	public static readonly TrackedBundleVersionInfo Version_1_40 =  new TrackedBundleVersionInfo ("1.40", 5);
	
	public ArrayList history = new ArrayList ();

	public TrackedBundleVersionInfo current = new TrackedBundleVersionInfo ("1.40", 5);

	public  TrackedBundleVersion() {
		history.Add (Version_1_21);
		history.Add (Version_1_22);
		history.Add (Version_1_23);
		history.Add (Version_1_31);
		history.Add (Version_1_80);
		history.Add (current);
	}

}
