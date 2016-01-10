
##	主view

````java
View view = (View)findViewById(android.R.id.content);
````

##	第一个布局的view

````java
((ViewGroup)context.findViewById(android.R.id.content)).getChildAt(0);  

````