##  安装material主题：

-	1：Package Control 安装 [material-theme](https://github.com/equinusocio/material-theme)
-	2：设置 //Activate the theme with the following preferences at (Preferences > Setting - User):

````
{
	"ignored_packages":
	[
		"Vintage"
	],
	"theme": "Material-Theme-Darker.sublime-theme",
	"color_scheme": "Packages/Material Theme/schemes/Material-Theme-Darker.tmTheme",
	"overlay_scroll_bars"          : "enabled",
	"line_padding_top"             : 3,
	"line_padding_bottom"          : 3,
	"always_show_minimap_viewport" : true,
	"bold_folder_labels"           : true,
	"indent_guide_options"         : [ "draw_normal", "draw_active" ],   // Highlight active indent
	"font_options"                 : [ "gray_antialias", "subpixel_antialias" ],    // On retina Mac & Windows
	"note":"Material-Theme.sublime-theme"
}

````