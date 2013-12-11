package at.technikum.mgs.healthgame;

import com.unity3d.player.UnityPlayer;

import android.content.Intent;
import android.content.Context;

public class GCMRegistration {
  
  public static void RegisterDevice(Context context, String SENDER_ID) {
    Intent i = new Intent(context,GCMJava.class);
    i.putExtra("isRegistration", true);
    i.putExtra("senderID",SENDER_ID);
    i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
    context.startService(i);
  }
  
  public static void UnregisterDevice(Context context) {
    Intent i = new Intent(context,GCMJava.class);
    i.putExtra("isRegistration", false);
    i.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
    context.startService(i);
  }
  
}
