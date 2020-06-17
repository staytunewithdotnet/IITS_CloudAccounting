// ReSharper disable DuplicatingLocalDeclaration
// ReSharper disable UnusedLocals
/*

◄------------------------------------------------------------►
This file includes all cusomized javascript and all plugins libraries options
◄------------------------------------------------------------►
*/

jQuery(document).ready(function($) {
  
  //-- Enable Use Strict Mode --
  "use strict";

  var priceTableIcon = $('.pricingIcon');
  priceTableIcon.each(function(){
    var data = $(this).data('image');
      if ( data != '' ) {
        $(this).css({ 'background-image' : 'url(' + data + ')' });
      } 
  });

  //--Portfolio Mixitup Filter--
    // jQuery('#Grid').mixitup('toGrid');
    jQuery('#grid').mixitup({
      targetSelector: '.mix',
      filterSelector: '.filter',
      sortSelector: '.sort',
      buttonEvent: 'click',
      effects: ['fade','scale'/*,'blur'*/],
      listEffects: null,
      easing: 'smooth',
      layoutMode: 'grid',
      targetDisplayGrid: 'inline-block',
      targetDisplayList: 'block',
      gridClass: '.mix',
      listClass: '',
      transitionSpeed: 600,
      showOnLoad: 'all',
      sortOnLoad: false,
      multiFilter: false,
      filterLogic: 'or',
      resizeContainer: true,
      minHeight: 0,
      failClass: 'fail',
      perspectiveDistance: '3000',
      perspectiveOrigin: '50% 50%',
      animateGridList: true,
      onMixLoad: null,
      onMixStart: null,
      onMixEnd: null
    });


  //--------------------------------------------------------------------------------------------

$('.comment').each(function(){
  if ( $(this).parent('.comment').length ) {
    var dist1 = $(this).offset();
    var dist2 = $(this).parent( '.comment' ).offset();
    if ( $(this).hasClass('depth-2') ) {
      var width = dist1.left - dist2.left - 33 -20;
      var height = dist1.top - dist2.top - 33 - 20;
      var top = dist1.top - dist2.top - 67 -20;
    } else {
      var width = dist1.left - dist2.left - 33;
      var height = dist1.top - dist2.top - 33;
      var top = dist1.top - dist2.top - 67;
    }
    $(this).children('.line').css( "height", height );
    $(this).children('.line').css( "width", width );
    $(this).children('.line').css( "top", -top );
    $(this).children('.line').css( "left", -width );
  }
});

  var $container = jQuery('#blog .isotope');
  // init
  $container.imagesLoaded( function() {
    $container.isotope({
        resizable: false,
        itemSelector: '.post',
        layoutMode: 'masonry'
    });
  });

  $('textarea').parent(".fieldarea").css("display", "block");
  $('.widget_rss ul').addClass("ticker").attr("id", "ticker");
  $('.widget_rss .widgetHeader, .widget_rss .footerWidgetHeader').append('<span class="tickerControl"><i class="animated fa fa-angle-left ticker-prev"></i><i class="animated fa fa-angle-right ticker-next"></i></span>');
  $('.widget_rss li').prepend('<i class="fa fa-rss-square fa-2x"></i>');

  $('.background-image').each(function(){
    var imageUrl = $(this).attr( "data-image" );
    if ( imageUrl != false ) {
      $(this).css( "background-image", "url(" + imageUrl + ")" );
    }
  });

  $('#bridge .pricingBody').each(function(){
    $(this).next().remove();
  });

  var checkbox = $('#bridge #frmlogin input[type="checkbox"]');
  checkbox.each(function(){
    var append = $(this).parent().next().prepend(checkbox);
  });

  $('#bridge input[type="checkbox"]').css("display", "block");

  $('.sectionWrapper').each(function(){
    if ( $(this).find('.wpb_gmaps_widget').length > 0 ) {
      $(this).css("padding", "0");
    }
  });



  /*-------------------------
  * CONTACT FORM
  *--------------------------*/
  //  $('.contact-form').submit(function(){
  //  var action = $(this).attr('action');
  //  $("#message").slideUp(750,function() {
  //  $('#message').hide();
  //  $('#submit')
  //    .after('<i class="fa fa-refresh fa-spin fa-2x"></i>')
  //    .attr('disabled', 'disabled');
  //  $.post(
  //    action,
  //    {
  //      action: 'ajax_contact_form',
  //      name: $('#name').val(),
  //      email: $('#email').val(),
  //      phone: $('#phone').val(),
  //      subject: $('#subject').val(),
  //      comments: $('#message').val(),
  //    },
  //    function(data){
  //      document.getElementById('message').innerHTML = data;
  //      $('#message').slideDown('slow');
  //      $('.contact-form .fa-spin').fadeOut('fast',function(){$(this).remove()});
  //      $('#submit').removeAttr('disabled');
  //      if(data.match('success') != null) $('.contact-form').slideUp('slow');
  //    }
  //  );
  //});
  //return false;
  //});


  //--Preloaing Effect --
  jQuery(window).load(function(){
    jQuery('.loadingContainer').css({'opacity' : 0 , 'display' : 'none'});
    jQuery('.allWrapper').css({'opacity' : 1 , 'visibility' : 'visible'});
    jQuery('.switcher').css({'opacity' : 1 , 'visibility' : 'visible'});
    jQuery('.back-to-top').css({'opacity' : 1 , 'visibility' : 'visible'});
    jQuery('body').css({'overflow' : 'visible'});
  });

  //--------------------------------------------------------------------------------------------

jQuery(document).ready(function() {

  //Bootstrap classes
  jQuery(".widget ul").addClass("list");
  jQuery(".widget_calendar table").each(function() {
    jQuery(this).addClass("table");
  });
  jQuery("table").each(function() {
    jQuery(this).addClass("table");
  });
  jQuery(".widget_search ul").removeClass("list");
  jQuery(".addCommentWidget ul").removeClass("list");
  jQuery(".comment-form").addClass("addCommentForm");
  jQuery(".comment-form div").wrapAll('<div class="row"></div>');
  jQuery(".form-submit input").unwrap();

  //-- Customizing some elements css according to windows size --
  var jQuerywindow = jQuery(window);
  var data = jQuery('#slider, .slider .item > img, #banner, #banner .item').data('height');
  var height = '';

  jQuerywindow.resize(function(){
  	if ( data != '' ) {
  		height = data;
  	} else {
  		height = '783';
  	}
    //-- fixed heights for some slider elements --
    jQuery('#slider, .slider .item > img, #banner, #banner .item').css({ 'height' : height });
  });

  var color = jQuery('#slider').data('cover');
  jQuery('#slider .cover').css({ 'background-color' : color });

  jQuerywindow.trigger('resize');
  //--------------------------------------------------------------------------------------------

  //-- customizing position of loading container --
  var jQueryloadingContainer = jQuery('.loadingContainer');

  jQueryloadingContainer.resize(function(){
    jQuery('.loadingContainer').css({
      'margin-left' : - jQueryloadingContainer.width() / 2 ,
      'margin-top' : - jQueryloadingContainer.height()  / 2
    });
  });

  jQueryloadingContainer.trigger('resize');
  //--------------------------------------------------------------------------------------------

    //-- Making the header fixed --
    var jQueryheader = jQuery('header#header');
    var jQueryheaderTop = jQueryheader.offset().top;

    jQuery('.offset').height( jQueryheader.outerHeight() ); //-- Window Scroll Functions --

    jQuery(window).scroll(function(){
      (jQuery(window).scrollTop() > jQueryheaderTop) ? jQuery('.sticky').addClass('fixedHeader') : jQuery('.sticky').removeClass('fixedHeader');
    });

  //--------------------------------------------------------------------------------------------



  //-- customizing the height of horizontal tabs --
  var jQuerysingleTab = jQuery('.tabsVr .singleTab');

  jQuerysingleTab.resize(function(){
    jQuery('.tabsVr .etabs').css({ 'height' : jQuerysingleTab.height() });
  });

  jQuerysingleTab.trigger('resize');

  //--------------------------------------------------------------------------------------------

  //-- Tooltip --
    jQuery('.tooltip-h').tooltip();
  //--------------------------------------------------------------------------------------------


  //-- Alert Custom closing effect --
  jQuery('.alert-general .close').click(function () {
    jQuery('.alert-general').slideToggle(500);
  });

  jQuery('.alert-success .close').click(function () {
    jQuery('.alert-success').slideToggle(500);
  });

  jQuery('.alert-warning .close').click(function () {
    jQuery('.alert-warning').slideToggle(500);
  });


  jQuery('.alert-info .close').click(function () {
    jQuery('.alert-info').slideToggle(500);
  });

  jQuery('.alert-error .close').click(function () {
    jQuery('.alert-error').slideToggle(500);
  });

  jQuery('.alert-attention .close').click(function () {
    jQuery('.alert-attention').slideToggle(500);
  });
  //--------------------------------------------------------------------------------------------


  //-- Closing message --
  jQuery('.messagePanel4 .close').click(function () {
    jQuery('.messagePanel4').fadeOut(500);
  });
  //--------------------------------------------------------------------------------------------


   //-- Scroll Spy --
  jQuery('.scrollTo').on('click', function( e ) {

      var scrollAnchor = jQuery(this).attr('data-scroll'),
          scrollPoint = jQuery('.scrollAnchor[data-anchor="' + scrollAnchor + '"]').offset().top - 92;

      jQuery('body,html').animate({
          scrollTop: scrollPoint
      }, 1000);

      window.location.hash = jQuery(this).attr('href').replace('#','');
      e.preventDefault();
  });
// ReSharper restore UnusedLocals
// ReSharper restore DuplicatingLocalDeclaration
// ReSharper disable DuplicatingLocalDeclaration
    jQuery(window).scroll(function() {
    var windscroll = jQuery(window).scrollTop();
    if (windscroll >= 0) {
      jQuery('.mainSection').each(function(i) {
          if (jQuery(this).position().top <= windscroll + 0) {
              jQuery('.intro .mainNav li > a.active').removeClass('active');
              jQuery('.intro .mainNav li > a').eq(i).addClass('active');
          }
      });

    } else {
      jQuery('.intro .mainNav li > a.active').removeClass('active');
    }

  }).scroll();

  //--------------------------------------------------------------------------------------------


  //-- Language filter (facny select) --
    jQuery('#language').fancySelect();
  //--------------------------------------------------------------------------------------------


  /* ◄------ All Carousels Init al over the template -------------------------------► */

  //-- homeSlider_1 and postSlider --

    //Init the carousel
    jQuery(".homeSlider_1 , .postSlider").owlCarousel({
      animateOut: 'fadeOut',
      items:1,
      margin:0,
      loop:true,
      autoplay:true,
      autoplayTimeout:8000,
      autoplayHoverPause:false,
      nav: true,
      dots: false,
      stagePadding:0,
      smartSpeed:1000,
      responsive:{
        0:{
          items:1
        },
        768:{
          items:1
        },
        1000:{
          items:1
        }
      }
    });

  //--------------------------------------------------------------------------------------------

  //-- homeSlider_2 --

    var owl = jQuery(".homeSlider_2");

    owl.owlCarousel({
      animateOut: 'fadeOut',
      items:1,
      margin:0,
      loop:true,
      autoplay:true,
      autoplayTimeout:8000,
      autoplayHoverPause:false,
      nav: true,
      dots : true,
      responsive:{
          0:{
              items:1
          },
          768:{
              items:1
          },
          1000:{
              items:1
          }
        }
    });
  //--------------------------------------------------------------------------------------------


  //-- homeSlider_4 --

    var owl = jQuery(".homeSlider_4");

    owl.owlCarousel({
      animateOut: 'fadeOut',
      dots : true,
      responsive:{
        0:{
            items:1
        },
        768:{
            items:1
        },
        1000:{
            items:1
        }
      }
    });
  //--------------------------------------------------------------------------------------------



  //-- carousel --

    var owl = jQuery(".carousel");

    owl.owlCarousel({
      nav : false,
      dots : true,
      loop:true,
      autoplay: true,
      items:4,
      responsive:{
        0:{
            items:1,
            slideBy: 1
        },
        768:{
            items:3,
            slideBy: 3
        },
        1000:{
            items:4,
            slideBy: 4
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- testmonialsCarousel --

    var owl = jQuery(".testmonialsCarousel");

    owl.owlCarousel({
      nav : false,
      dots : true,
      loop:true,
      autoplay : true,
      items : 3,
      responsive:{
        0:{
            items:1,
            slideBy: 1
        },
        768:{
            items:2,
            slideBy: 2
        },
        1000:{
            items:3,
            slideBy: 3
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- testmonialsCarousel2 --

    var owl = jQuery(".testmonialsCarousel2");

    owl.owlCarousel({
      nav : true,
      dots : false,
      animateOut : 'fadeOut',
      animateIn: 'flipInX',
      loop:true,
      autoplay : true,
      items : 1,
      responsive:{
        0:{
            items:1
        },
        768:{
            items:1
        },
        1000:{
            items:1
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- testmonialsCarousel3 --

    var owl = jQuery(".testmonialsCarousel3");

    owl.owlCarousel({
      nav : true,
      dots : false,
      autoplay : true,
      loop:true,
      items : 2,
      responsive:{
        0:{
            items:1,
            slideBy: 1
        },
        768:{
            items:2,
            slideBy: 2
        },
        1000:{
            items:2,
            slideBy: 2
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- clientsCarousel --

    var owl = jQuery(".clientsCarousel");

    owl.owlCarousel({
      nav : true,
      dots : false,
      loop:true,
      autoplay : true,
      items : 6,
      responsive:{
        0:{
            items:1,
            slideBy: 1
        },
        480:{
            items:2,
            slideBy: 2
        },
        768:{
            items:4,
            slideBy: 4
        },
        1000:{
            items:6,
            slideBy: 6
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- servicesCarousel2 and featuresCarousel2  --

    var owl = jQuery(".servicesCarousel2 , .featuresCarousel2");

    owl.owlCarousel({
      nav : false,
      dots : true,
      loop:true,
      autoplay : true,
      items : 3,
      responsive:{
        0:{
            items:1,
            slideBy: 1
        },
        768:{
            items:2,
            slideBy: 2
        },
        1000:{
            items:3,
            slideBy: 3
        }
      }
    });
  //--------------------------------------------------------------------------------------------



  //-- .aboutBoxBody and testmonialsCarousel3 --

    var owl = jQuery(".aboutBoxBody.owl-carousel , .testmonials4 .testmonialsCarousel3");

    owl.owlCarousel({
      nav : true,
      dots : false,
      loop:true,
      autoplay : false,
      items : 1,
      responsive:{
        0:{
            items:1
        },
        768:{
            items:1
        },
        1000:{
            items:1
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- testmonialsCarousel4 --

    var owl = jQuery(".testmonials4 .testmonialsCarousel4");

    owl.owlCarousel({
      nav : false,
      dots : true,
      loop:true,
      autoplay : true,
      items : 1,
      responsive:{
        0:{
            items:1
        },
        768:{
            items:1
        },
        1000:{
            items:1
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- carousel3 --

    var owl = jQuery(".carousel3");

    owl.owlCarousel({
      nav : true,
      dots : false,
      animateOut : 'slideUpSlow',
      animateIn: 'fadeOutUp',
      autoplay:true,
      loop:true,
      items : 1,
      responsive:{
        0:{
            items:1
        },
        768:{
            items:1
        },
        1000:{
            items:1
        }
      }
    });
  //--------------------------------------------------------------------------------------------


  /* ◄------ Accordion & Toggle -------------------------------► */

  //-- Accordion 1 --
    jQuery(".accordionRow > a").on("click", function(e){
      if(jQuery(this).parent().has("div")) {
        e.preventDefault();
      }

      if(!jQuery(this).hasClass("activeLine")) {
        // hide any open menus and remove all other classes
        jQuery(".accordionRow > a").removeClass("activeLine");
        jQuery(".accordionRow > .accordion-content").removeClass("opened");
        jQuery(".accordionRow > .accordion-content").slideUp(500);

        // open our new menu and add the activeLine class
        jQuery(this).addClass("activeLine");
        jQuery(".accordionRow > .accordion-content").addClass("opened");
        jQuery(this).next(".accordion-content").slideDown(500);
      }

      else if(jQuery(this).hasClass("activeLine")) {
        jQuery(this).removeClass("activeLine");
        jQuery(".accordionRow > .accordion-content").removeClass("opened");
        jQuery(this).next(".accordion-content").slideUp(500);
      }
    });
  //--------------------------------------------------------------------------------------------

  /* ◄------ Foucs and Blur for textarea -------------------------------► *

  //-- comment --

    var watermark = 'Comment';

    //init, set watermark text and class
    jQuery('#commentArea').val(watermark).addClass('inputBar');

    //if blur and no value inside, set watermark text and class again.
    jQuery('#commentArea').blur(function(){
        if (jQuery(this).val().length == 0){
          jQuery(this).val(watermark).addClass('inputBar');
      }
    });

    //if focus and text is watermrk, set it to empty and remove the watermark class
    jQuery('#commentArea').focus(function(){
        if (jQuery(this).val() == watermark){
          jQuery(this).val('').removeClass('inputBar');
      }
    });
  //--------------------------------------------------------------------------------------------


  //-- message --

    var watermark = 'Message';

    //init, set watermark text and class
    jQuery('#messageArea').val(watermark).addClass('inputBar');

    //if blur and no value inside, set watermark text and class again.
    jQuery('#messageArea').blur(function(){
        if (jQuery(this).val().length == 0){
          jQuery(this).val(watermark).addClass('inputBar');
      }
    });

    //if focus and text is watermrk, set it to empty and remove the watermark class
    jQuery('#messageArea').focus(function(){
        if (jQuery(this).val() == watermark){
          jQuery(this).val('').removeClass('inputBar');
      }
    });
  //--------------------------------------------------------------------------------------------*/




  //-- Domain Ex selection --
    jQuery("#domainEx").msDropdown({visibleRows:4});
  //--------------------------------------------------------------------------------------------


  //-- ticker --
  jQuery('.ticker').each(function(){
    jQuery(this).newsTicker({
      row_height: 80,
      max_rows: 3,
      duration: 4000,
      prevButton: jQuery(this).children(".ticker-prev"),
      nextButton: jQuery(this).children(".ticker-next")
    });
  });
  //--------------------------------------------------------------------------------------------


  //-- tabs --
    jQuery('.tabsContainer').easytabs();
  //--------------------------------------------------------------------------------------------



  //-- flip clock --
    var clock;

    // Grab the current date
    var currentDate = new Date();

    var fdate = $('.clock').data('date');
    var ftime = $('.clock').data('time');

    // Set some date in the future. In this case, it's always Jan 1
    //var futureDate  = new Date(currentDate.getFullYear() + 1, 0, 0);
    var futureDate  = new Date(fdate + ' ' + ftime);

    // Calculate the difference in seconds between the future and current date
    var diff = futureDate.getTime() / 1000 - currentDate.getTime() / 1000;

    // Instantiate a coutdown FlipClock
    clock = jQuery('.clock').FlipClock(diff, {
      clockFace: 'DailyCounter',
      countdown: true
    });
  //--------------------------------------------------------------------------------------------




  //-- Creating back to top btn --
    jQuery('body').append(
      "<a href='#' class='back-to-top'>"+
        "<i class='fa fa-chevron-up'></i>"+
      "</a>"
    );
  //-- scroll to top --
    var offset = 600;
    var duration = 1500;
    jQuery(window).scroll(function() {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.back-to-top').addClass('fadeInup');
        } else {
            jQuery('.back-to-top').removeClass('fadeInup');
        }
    });

    jQuery('.back-to-top').click(function(e) {
        e.stopPropagation();
        jQuery('body,html').animate({
        scrollTop: 0
    }, duration);
        return false;
    }); //--------------------------------------------------------------------------------------------




  /* ◄------ Scroll Animation -------------------------------► */

  //-- Progressbar --
  jQuery(document).scroll(function() {
    jQuery('.progress-bar').each(function(){
    var imagePos = jQuery(this).offset().top;

    var topOfWindow = jQuery(document).scrollTop();
      if (imagePos < topOfWindow+jQuery(window).height() * 0.8) {
        jQuery(this).addClass("animated slideRightSlow");
      }
    });
  });

  //-- Intro Demos --
  /*jQuery(document).scroll(function() {
    jQuery('.demo:nth-child(1n)').each(function(){
    var imagePos = jQuery(this).offset().top;

    var topOfWindow = jQuery(document).scrollTop();
      if (imagePos < topOfWindow+jQuery(window).height() * 0.5) {
        jQuery(this).addClass("animated fadeInLeft");
      }
    });
  });

  jQuery(document).scroll(function() {
    jQuery('.demo:nth-child(2n)').each(function(){
    var imagePos = jQuery(this).offset().top;

    var topOfWindow = jQuery(document).scrollTop();
      if (imagePos < topOfWindow+jQuery(window).height() * 0.5) {
        jQuery(this).addClass("animated pullUp");
      }
    });
  });


  jQuery(document).scroll(function() {
    jQuery('.demo:nth-child(3n)').each(function(){
    var imagePos = jQuery(this).offset().top;

    var topOfWindow = jQuery(document).scrollTop();
      if (imagePos < topOfWindow+jQuery(window).height() * 0.5) {
        jQuery(this).addClass("animated fadeInRight");
      }
    });
  });*/
  //--------------------------------------------------------------------------------------------



  /* ◄------ Nice Scroll -------------------------------► */

  //-- The whole page --
  jQuery("html").niceScroll({
    cursorborder: 0,
    cursorcolor: '#171717',
    autohidemode: false,
    zindex: 9999999,
    scrollspeed: 60,
    mousescrollstep: 36,
    cursorwidth: 6,
    horizrailenabled: false,
    cursorborderradius: 3
  });
  //--------------------------------------------------------------------------------------------

  //-- Modal --
  jQuery(".modal").niceScroll({
    cursorborder: 0,
    cursorcolor: '#fff',
    autohidemode: false,
    zindex: 99999999999,
    scrollspeed: 60,
    mousescrollstep: 36,
    cursorwidth: 6,
    horizrailenabled: false,
    cursorborderradius: 3
  });
  //--------------------------------------------------------------------------------------------

  //-- Table Wrapper ( JUST IN RESPONSIVE ) --
  jQuery(".tableWrapper").niceScroll(".table",{
    cursorborder: 0,
    cursorcolor: '#ccc',
    autohidemode: false,
    zindex: 99999999999,
    scrollspeed: 60,
    mousescrollstep: 36,
    cursorwidth: 6,
    horizrailenabled: true,
    cursorborderradius: 3,
    usetransition: 0
  });
  //--------------------------------------------------------------------------------------------


  /* ◄------ Responsive Nav -------------------------------► */

    //-- Including the main nav contents in responsive main nav DIV --
    jQuery('.mainNav .navTabs').clone().appendTo('.responsiveMainNav');

    //-- Show and Hide responsive nav --
    jQuery('#responsiveMainNavToggler').click(function(event){
      event.preventDefault();
      jQuery('#responsiveMainNavToggler').toggleClass('opened');
      jQuery('.responsiveMainNav').slideToggle(1000);


      if ( jQuery('#responsiveMainNavToggler i').hasClass('fa-bars') )
      {
          jQuery('#responsiveMainNavToggler i').removeClass('fa-bars');
          jQuery('#responsiveMainNavToggler i').addClass('fa-close');
      }else
      {
          jQuery('#responsiveMainNavToggler i').removeClass('fa-close');
          jQuery('#responsiveMainNavToggler i').addClass('fa-bars');
      }

    });

    // dropdown level 1
    if(jQuery(".responsiveMainNav .navTabs > li > a").parent().has("ul")) {
      jQuery(".responsiveMainNav .navTabs > li > a:first-child").addClass("toggleResponsive");
      jQuery(".responsiveMainNav .navTabs > li > a:last-child").removeClass("toggleResponsive");
    }

    jQuery(".responsiveMainNav .navTabs > li > .toggleResponsive").on("click", function(e){
      if(jQuery(this).parent().has("ul")) {
        e.preventDefault();
      }

      if(!jQuery(this).hasClass("activeLine")) {
        // hide any open menus and remove all other classes
        jQuery(".responsiveMainNav .navTabs > li > .toggleResponsive").removeClass("activeLine");
        jQuery(".responsiveMainNav .navTabs > li > .dropDown").slideUp(500);

        // open our new menu and add the activeLine class
        jQuery(this).addClass("activeLine");
        jQuery(this).next(".responsiveMainNav .navTabs > li > .dropDown").slideDown(500);
      }

      else if(jQuery(this).hasClass("activeLine")) {
        jQuery(this).removeClass("activeLine");
        jQuery(this).next(".responsiveMainNav .navTabs > li > .dropDown").slideUp(500);
      }
    });


    // dropdown level 2
    if(jQuery(".responsiveMainNav .navTabs > li > .dropDown > li > a").parent().has("ul")) {
      jQuery(".responsiveMainNav .navTabs > li > .dropDown > li > a:first-child").addClass("toggleResponsive");
      jQuery(".responsiveMainNav .navTabs > li > .dropDown > li > a:last-child").removeClass("toggleResponsive");
    }


    jQuery(".responsiveMainNav .navTabs > li > .dropDown > li > .toggleResponsive").on("click", function(e){
      if(jQuery(this).parent().has("ul")) {
        e.preventDefault();
      }

      if(!jQuery(this).hasClass("activeLine")) {
        // hide any open menus and remove all other classes
        jQuery(".responsiveMainNav .navTabs > li > .dropDown > li > .toggleResponsive").removeClass("activeLine");
        jQuery(".responsiveMainNav .navTabs > li > .dropDown li .dropDown").slideUp(500);

        // open our new menu and add the activeLine class
        jQuery(this).addClass("activeLine");
        jQuery(this).next(".responsiveMainNav .navTabs > li > .dropDown li .dropDown").slideDown(500);
      }

      else if(jQuery(this).hasClass("activeLine")) {
        jQuery(this).removeClass("activeLine");
        jQuery(this).next(".responsiveMainNav .navTabs > li > .dropDown li .dropDown").slideUp(500);
      }
    });

  });
  //--------------------------------------------------------------------------------------------

  /* ◄------ Demo Hover Effect -------------------------------► */
  /*jQuery(".perview img").mouseover(function(){
    var $distance = this.height - jQuery(this).parent().height();
    jQuery(this).stop().animate({marginTop: -$distance}, 6000, 'linear');

    }).mouseout(function(){
    jQuery(this).stop().animate({marginTop: '0'}, 2000);
  });*/



})//end of use strict


// ReSharper restore DuplicatingLocalDeclaration