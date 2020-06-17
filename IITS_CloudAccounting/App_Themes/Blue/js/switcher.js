jQuery(window).load(function() {

	//-- show and hide switcher --

	jQuery('.switcherShowHide').click(function() {
		if ( jQuery('.switcherShowHide').hasClass('switcherToggle') )
			{
			jQuery('.switcherShowHide').removeClass('switcherToggle');
			jQuery('.switcher').removeClass('opened');
		}else
		{
			jQuery('.switcherShowHide').addClass('switcherToggle');
			jQuery('.switcher').addClass('opened');
		}

	});

	jQuery('.switcher').click(function(e){
		e.stopPropagation();
	});

	jQuery('html').on( 'click', function ( _ev )
	{
		jQuery('.switcherShowHide').removeClass('switcherToggle');
		jQuery('.switcher').removeClass('opened');
	});


   //-- controlling the position of switcher --
	var jQueryswitcherWrappper = jQuery('.switcherWrappper');

	jQueryswitcherWrappper.resize(function(){

		jQuery('.switcher').css({ 'left' : - jQueryswitcherWrappper.width()});

	});

	jQueryswitcherWrappper.trigger('resize');



	var emerald_gnrl_color=false;

	// Color
	jQuery('li[data-name=gnrl_color]').click(function() {
		emerald_gnrl_color = jQuery(this).attr("data-value");
		emerald_gnrl_color_2 = jQuery(this).attr("data-value-2");
		if(emerald_gnrl_color!=false){
			pointer_color(emerald_gnrl_color,emerald_gnrl_color_2);
		}
	});

	// General Color
	function pointer_color(color_style,color_style_2){
		url = jQuery('#skins-css').attr('href' );
		newHref= url.replace(/\\/g,'/').replace( /.*\//, '' ).replace( /\..*/, '' );
		newHref2= url.replace(newHref, color_style);
		jQuery('#skins-css').attr('href', newHref2);

		urlr = jQuery('.style-5 .ribbon').attr('src' );
		newHrefr= urlr.replace(/\\/g,'/').replace( /.*\//, '' ).replace( /\..*/, '' );
		newHref2r= urlr.replace(newHrefr, 'ribbon-'+color_style);
		jQuery('.style-5 .ribbon').attr('src', newHref2r);
	}

	// Layout
	jQuery('li[data-name=gnrl_layout]').click(function() {
		jQuery("*").removeClass("active-layout");
		jQuery(this).addClass("active-layout");
		jQuery('.owl-stage').resize();
		emerald_gnrl_layout = jQuery(this).attr("data-value");
		if(emerald_gnrl_layout!=false){
			pointer_layout(emerald_gnrl_layout);
		}
	});

	// General Layout
	function pointer_layout(layout_style){
		if (layout_style == "wide") {
			jQuery("body").removeClass("body-boxed").removeClass("body-boxed-2");
			jQuery(".allWrapper").removeClass("boxed").removeClass("boxed-2");
			jQuery('.owl-stage').resize();
			jQuery(window).resize();
			jQuery("body").attr("style","");
		}else if (layout_style == "boxed") {
			jQuery("body").addClass("body-boxed").removeClass("body-boxed-2");
			jQuery(".allWrapper").addClass("boxed").removeClass("boxed-2");
			jQuery('.owl-stage').resize();
			jQuery(window).resize();
			jQuery("body").attr("style","");
		}else if (layout_style == "boxed2") {
			jQuery("body").removeClass("body-boxed").addClass("body-boxed-2");
			jQuery(".allWrapper").removeClass("boxed").addClass("boxed-2");
			jQuery('.owl-stage').resize();
			jQuery(window).resize();
			jQuery("body").attr("style","");
		}
	}

	// Pattern
	jQuery('li[data-name=gnrl_pattern]').click(function() {
		emerald_gnrl_gnrl_pattern = jQuery(this).attr("data-value");
		if(emerald_gnrl_gnrl_pattern!=false){
			pointer_pattern(emerald_gnrl_gnrl_pattern);
		}
	});

	// General Pattern
	function pointer_pattern(pattern_style){
		if (jQuery(".active-layout").attr("data-value") == "boxed" || jQuery(".active-layout").attr("data-value") == "boxed2") {
			jQuery("body").css("background","url(wp-content/themes/7host/assets/images/patterns/"+pattern_style+".png) repeat");
		}
	}

});
