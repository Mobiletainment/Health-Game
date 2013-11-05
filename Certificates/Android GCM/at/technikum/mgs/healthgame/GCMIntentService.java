package at.technikum.mgs.healthgame;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;
import android.os.Handler;

import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
 
import com.google.android.gcm.GCMBaseIntentService;
  
public class GCMIntentService extends GCMBaseIntentService {
 
    private static final String TAG = "GCMIntentService";
    private static final String NOTIFICATION_TITLE = "ECPN";
    
    public static String message = "";
    
    private Handler handler = new Handler();
 
    /**
     * Method called on device registered
     **/
    @Override
    protected void onRegistered(Context context, String registrationId) {
        Log.i(TAG, "Device registered: regId = " + registrationId);
        UnityPlayer.UnitySendMessage("ECPNManager","RegisterAndroidDevice",registrationId);
    }
 
    /**
     * Method called on device un registred
     * */
    @Override
    protected void onUnregistered(Context context, String registrationId) {
        Log.i(TAG, "Device unregistered");
        UnityPlayer.UnitySendMessage("ECPNManager","UnregisterDevice",registrationId);
    }
 
    /**
     * Method called on Receiving a new message
     * */
    @Override
    protected void onMessage(Context context, Intent intent) {
        Log.i(TAG, "Received message");
        String message = intent.getExtras().getString("price");
 
        // notifies user
        generateNotification(context, message);
    }
 
    /**
     * Method called on receiving a deleted message
     * */
    @Override
    protected void onDeletedMessages(Context context, int total) {
        Log.i(TAG, "Received deleted messages notification");
    }
 
    /**
     * Method called on Error
     * */
    @Override
    public void onError(Context context, String errorId) {
        Log.i(TAG, "Received error: " + errorId);
    }
 
    @Override
    protected boolean onRecoverableError(Context context, String errorId) {
        // log message
        Log.i(TAG, "Received recoverable error: " + errorId);
        return super.onRecoverableError(context, errorId);
    }
 
    /**
     * Issues a notification to inform the user that server has sent a message.
     */
    private void generateNotification(Context context, String m) {
      message = m;
      handler.post(new Runnable() {
        public void run() {
          Context context = GCMIntentService.this;
          int icon = getResources().getIdentifier("ic_launcher", "drawable", context.getPackageName());//R.drawable.ic_launcher;
          long when = System.currentTimeMillis();
          NotificationManager notificationManager = (NotificationManager)
            context.getSystemService(Context.NOTIFICATION_SERVICE);
          Notification notification = new Notification(icon, message, when);
          
          Intent notificationIntent = new Intent(GCMIntentService.this, UnityPlayerActivity.class);
          // set intent so it does not start a new activity
          notificationIntent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP |
                                      Intent.FLAG_ACTIVITY_SINGLE_TOP);
          PendingIntent intent =
            PendingIntent.getActivity(context, 0, notificationIntent, 0);
          notification.setLatestEventInfo(context, NOTIFICATION_TITLE, message, intent);
          
          // Flags
          notification.flags |= Notification.FLAG_AUTO_CANCEL;
          //notification.defaults |= Notification.DEFAULT_SOUND;
          //notification.defaults |= Notification.DEFAULT_VIBRATE; // uncomment and add VIBRATE permissions on manifest to get vibrating notifications
          notificationManager.notify(0, notification);
        }
      });
        
    }
 
}