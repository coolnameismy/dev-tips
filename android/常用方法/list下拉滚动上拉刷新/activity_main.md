````
<RelativeLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical" >

     
          <LinearLayout 
                 android:layout_above="@+id/toolbar"
                 android:layout_width="fill_parent"
       			 android:layout_height="wrap_content"
       			 android:layout_alignParentTop="true"
       			 android:orientation="horizontal"
                >
                <android.support.v4.view.ViewPager
		        android:id="@+id/viewPager"
		        android:layout_width="match_parent"
		        android:layout_height="wrap_content" /> 
        </LinearLayout> 
    

    <View
        android:id="@+id/toolbar_divider"
        android:layout_width="fill_parent"
        android:layout_height="0.5dip"
        android:layout_alignTop="@+id/toolbar"
        android:background="@color/gray" />

    <LinearLayout
        android:id="@+id/toolbar"
        android:layout_width="fill_parent"
        android:layout_height="40dp"
        android:layout_alignParentBottom="true"
        android:background="#fff6f7f7"
        android:orientation="horizontal"
        android:paddingLeft="6.0dip"
        android:paddingRight="6.0dip" >

        <ImageView
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1"
            android:clickable="true"
            android:scaleType="center"
            android:src="@drawable/icon_favor" 
            android:onClick="changPage"/>

        <ImageView
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1"
            android:clickable="true"
            android:scaleType="center"
            android:src="@drawable/icon_write" />

        <ImageView
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1"
            android:scaleType="center"
            android:src="@drawable/review_toolbar_normal" />

        <ImageView
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1"
            android:scaleType="center"
            android:src="@drawable/ic_action_report_normal" />

        <ImageView
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1"
            android:scaleType="center"
            android:src="@drawable/ic_action_attenation_normal" />
    </LinearLayout>

</RelativeLayout>
````