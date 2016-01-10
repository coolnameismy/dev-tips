

安卓开发中，在低版本SDK使用高版本的API会报错。一般处理方法是换一种实现方法，或者在高版本SDK中使用高版本API，低版本SDK中使用效果可能会差点的折衷方案；后者可以用如下技巧来实现。

Step 1

在使用了高版本API的方法前面加一个 @TargetApi(API号)

Step 2

在代码上用版本判断来控制不同版本使用不同的代码


````java 

@TargetApi(Build.VERSION_CODES.JELLY_BEAN) 
public class TestActivity extends Activity {
	
	NotificationManager notificationManager ;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_test);
		
		//user code
	    //获取系统通知管理
		notificationManager = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
		//启动intent
		 Context context = TestActivity.this;
		 Intent intent = new Intent(context, TestActivity.class);  
         PendingIntent pi = PendingIntent.getActivity(this, 0, intent, 0);  	
         
         Notification notification= null;
         if(android.os.Build.VERSION.SDK_INT > 16){
        	 notification = new Notification.Builder(context).build();
         }
         else
         {
        	 notification = new Notification.Builder(context)
             .setContentTitle("Title").setContentText("Text")
             .setSmallIcon(R.drawable.ic_launcher).getNotification();
         }
        
	}
 

}
````
