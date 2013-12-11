package at.technikum.mgs.healthgame;

import com.unity3d.player.UnityPlayer;

import com.google.android.gcm.GCMRegistrar;
import android.app.IntentService;
import android.os.AsyncTask;
import android.content.Context;
import android.content.IntentFilter;
import android.content.BroadcastReceiver;
import android.content.Intent;
import android.util.Log;
import android.os.Bundle;

public class GCMJava extends IntentService {
  
    String DISPLAY_MESSAGE_ACTION = "";
    String EXTRA_MESSAGE = "message";
    
    static Boolean isRegistration;
    
    public GCMJava() {
      super("GCMJava");
    }
    
    @Override
    public void onHandleIntent(Intent i) {
        Boolean isRegistration = i.getExtras().getBoolean("isRegistration");
        if(!isRegistration) {
          // Unregister device
          GCMRegistrar.unregister(this);
        } else {
          // Carry on with registration
          String SENDER_ID = i.getStringExtra("senderID");
          
          // Checking device and manifest dependencies
          GCMRegistrar.checkDevice(this);
          GCMRegistrar.checkManifest(this);
          
          // Get GCM registration id
          final String regId = GCMRegistrar.getRegistrationId(this);
          
          // Check if regid already presents
          if (regId.equals("")) {
            // Registration is not present, register now with GCM
            GCMRegistrar.register(this, SENDER_ID);
          } else {
            // Send ID to Unity
            sendConfirmRegistration(regId);
            // if registeredOnServer flag is not set, send info to Unity
            if (!GCMRegistrar.isRegisteredOnServer(this)) {
              GCMRegistrar.setRegisteredOnServer(this, true);
            }
          }
        }
    }
    /*@Override
    public void onCreate(Bundle savedInstance) {
        super.onCreate(savedInstance);
        Intent i = getIntent();
        Boolean isRegistration = getIntent().getExtras().getBoolean("isRegistration");
        if(!isRegistration) {
          // Unregister device
          GCMRegistrar.unregister(this);
        } else {
          // Carry on with registration
          String SENDER_ID = i.getStringExtra("senderID");
          
          // Checking device and manifest dependencies
          GCMRegistrar.checkDevice(this);
          GCMRegistrar.checkManifest(this);
          
          // Get GCM registration id
          final String regId = GCMRegistrar.getRegistrationId(this);
          
          // Check if regid already presents
          if (regId.equals("")) {
            // Registration is not present, register now with GCM
            GCMRegistrar.register(this, SENDER_ID);
          } else {
            // Send ID to Unity
            sendConfirmRegistration(regId);
            // if registeredOnServer flag is not set, send info to Unity
            if (!GCMRegistrar.isRegisteredOnServer(this)) {
              GCMRegistrar.setRegisteredOnServer(this, true);
            }
          }
        }
        
        finish();
        return;
  }*/
    
    public void sendConfirmRegistration(String id) {
      UnityPlayer.UnitySendMessage("ECPNManager","RegisterAndroidDevice",id);
    }
}
