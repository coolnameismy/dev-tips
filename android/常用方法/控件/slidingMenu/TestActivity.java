package com.example.hello;

import java.util.ArrayList;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

import com.example.hello.adapter.MyFragmentPagerAdaptert;
import com.example.hello.fragment.MyFragment;
import com.example.hello.fragment.myListFragment;
import com.example.hello.tool.Common;
import com.jeremyfeinstein.slidingmenu.lib.SlidingMenu;
import com.jeremyfeinstein.slidingmenu.lib.SlidingMenu.OnClosedListener;

public class TestActivity extends FragmentActivity {

	ViewPager viewPager ;
    SlidingMenu menu;
	int i = 0;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_test);
		//user code
		initFragment();
	    initSlidingmenu();
	}
	private void initFragment() {
		 ArrayList<Fragment> fragments = new ArrayList<Fragment>();
		 Fragment fragment1 = new MyFragment("fragment1");
		 Fragment fragment2 = new myListFragment();
		 Fragment fragment3 = new MyFragment("fragment3");
		 fragments.add(fragment1);
		 fragments.add(fragment2);
		 fragments.add(fragment3);
		 
		MyFragmentPagerAdaptert adapter = 
				new MyFragmentPagerAdaptert(getSupportFragmentManager(),fragments);
		viewPager = (ViewPager) findViewById(R.id.viewPager);
		viewPager.setAdapter(adapter);
 
	}
	private void initSlidingmenu() {
		 
		//初始化样式
		menu = new SlidingMenu(this);
		menu.setMode(SlidingMenu.LEFT_RIGHT);//设置左右滑菜单
		menu.setTouchModeAbove(SlidingMenu.SLIDING_WINDOW);//设置要使菜单滑动，触碰屏幕的范围
//		localSlidingMenu.setTouchModeBehind(SlidingMenu.SLIDING_CONTENT);//设置了这个会获取不到菜单里面的焦点，所以先注释掉
//		localSlidingMenu.setShadowWidthRes(R.dimen.shadow_width);//设置阴影图片的宽度
//		localSlidingMenu.setShadowDrawable(R.drawable.shadow);//设置阴影图片
	 	menu.setBehindOffsetRes(R.dimen.menu_keepto_main);//SlidingMenu划出时主页面显示的剩余宽度
		menu.setFadeDegree(0.35F);//SlidingMenu滑动时的渐变程度
		menu.attachToActivity(this, SlidingMenu.RIGHT);//使SlidingMenu附加在Activity右边
//		localSlidingMenu.setBehindWidthRes(R.dimen.left_drawer_avatar_size);//设置SlidingMenu菜单的宽度
		menu.setMenu(R.layout.fragment_meun);//设置menu的布局文件
//		localSlidingMenu.toggle();//动态判断自动关闭或开启SlidingMenu
		menu.setSecondaryMenu(R.layout.fragment_meun);
//		menu.setSecondaryShadowDrawable(R.drawable.shadowright);
		menu.setOnOpenedListener(new SlidingMenu.OnOpenedListener() {
					public void onOpened() {
						
					}
				});
		menu.setOnClosedListener(new OnClosedListener() {
			@Override
			public void onClosed() {
				// TODO Auto-generated method stub
				
			}
		});
		//初始化menu按钮功能
		Button button1 =  (Button) menu.findViewById(R.id.button1);
		button1.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				Common.showMessageWithToast(getApplicationContext(),"menu_button1_clicked");
			}
		});
	}
		 
	public void btn_left_clicked(View view) {
		Common.showMessageWithToast(this,"btn_left_clicked");
		if(menu.isMenuShowing()){
			menu.showContent();
		}else{
			menu.showMenu();
		}
	}
	public void btn_right_clicked(View view) {
		Common.showMessageWithToast(this,"btn_right_clicked");
		if(menu.isSecondaryMenuShowing()){
			menu.showSecondaryMenu();
		}else{
			menu.showSecondaryMenu();
		}
	}
	public void changPage(View view) {
		viewPager.setCurrentItem(i++%3);
	}
	 
}
