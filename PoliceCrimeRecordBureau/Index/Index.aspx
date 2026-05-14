<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PCR_Bureau.Index.Index" %>


<!--A Design by W3layouts
   Author: W3layout
   Author URL: http://w3layouts.com
   License: Creative Commons Attribution 3.0 Unported
   License URL: http://creativecommons.org/licenses/by/3.0/
   -->
<!DOCTYPE html>
<html lang="zxx">
   <head>
      <title>PCR Bureau</title>
      <!--meta tags -->
      <meta charset="UTF-8" />
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <meta name="keywords" content="Sway Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
         Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
      <script>
         addEventListener("load", function () {
         	setTimeout(hideURLbar, 0);
         }, false);
         
         function hideURLbar() {
         	window.scrollTo(0, 1);
         }
      </script>
      <!--//meta tags ends here-->
      <!--booststrap-->
      <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="all">
      <!--//booststrap end-->
      <!-- font-awesome icons -->
      <link href="css/fontawesome-all.min.css" rel="stylesheet" type="text/css" media="all">
      <!-- //font-awesome icons -->
      <!--Slider -->
      <link href="css/lsb.css" rel="stylesheet" type="text/css">
      <!-- //slider-->
      <!--stylesheets-->
      <link href="css/style.css" rel='stylesheet' type='text/css' media="all">
      <!--//stylesheets-->
      <link href="//fonts.googleapis.com/css?family=Montserrat:300,400,500" rel="stylesheet">
      <link href="//fonts.googleapis.com/css?family=Felipa" rel="stylesheet">
   </head>
   <body>
      <div class="header-outs" id="home">
         <div class="header-bar">
            <nav class="navbar navbar-expand-lg navbar-light">
               <div class="hedder-up" style="background-color:brown;box-shadow:2px 2px 8px;border-radius:5px;padding:5px">
                  <h1 style="color:brown;font-family:Algerian;font-weight:bolder"><a class="navbar-brand" href="#">PCR Bureau </a> </h1>
               </div>
               <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
               <span class="navbar-toggler-icon"></span>
               </button>
               <div class="collapse navbar-collapse justify-content-end" id="navbarSupportedContent">
                  <ul class="navbar-nav ">
                     <li class="nav-item active">
                        <a class="nav-link" href="index.html">Home <span class="sr-only">(current)</span></a>
                     </li>
                     <li class="nav-item">
                        <a href="../Login/Login.aspx" class="nav-link">Login</a>
                     </li>
                  </ul>
                
               </div>
            </nav>
         </div>
      </div>
      <!-- //Navigation -->
      <!-- Slideshow 4 -->
      <div class="slider">
         <div class="callbacks_container">
            <ul class="rslides" id="slider4">
               <li>
                  <div class="slider-img one-img">
                     <div class="container">
                        <div class="slider-info text-left">
                           <h4>Crime Records<br><span class="pink-col">Bureau</span></h4>
                           <p class="pt-3"> </p>
                           <div class="outs_more-buttn">
                             
                           </div>
                        </div>
                     </div>
                  </div>
               </li>
               <li>
                  <div class="slider-img two-img">
                     <div class="container">
                        <div class="slider-info text-center">
                           <h4>Crime Records<span class="pink-col">Bureau </span></h4>
                           <p class="pt-3"> </p>
                           <div class="outs_more-buttn">
                              
                           </div>
                        </div>
                     </div>
                  </div>
               </li>
               <li>
                  <div class="slider-img three-img">
                     <div class="container">
                        <div class="slider-info text-center">
                           <h4>Crime<span class="pink-col"> Records</span> Bureau</h4>
                           <p class="pt-3"> </p>
                           <div class="outs_more-buttn">
                              
                           </div>
                        </div>
                     </div>
                  </div>
               </li>
            </ul>
         </div>
         <!-- This is here just to demonstrate the callbacks -->
         <!-- <ul class="events">
            <li>Example 4 callback events</li>
            </ul>-->
         <div class="clearfix"></div>
      </div>
      <!-- //banner -->
      <!--about -->
      
      <!--//service -->			
      <!--schedual-->
      
      <!--//footer-->
      <!--js working-->
      <script src='js/jquery-2.2.3.min.js'></script>
      <!--//js working-->
      <!--responsiveslides banner-->
      <script src="js/responsiveslides.min.js"></script>
      <script>
         // You can also use "$(window).load(function() {"
         $(function () {
         	// Slideshow 4
         	$("#slider4").responsiveSlides({
         		auto: true,
         		pager:false,
         		nav: true,
         		speed: 900,
         		namespace: "callbacks",
         		before: function () {
         			$('.events').append("<li>before event fired.</li>");
         		},
         		after: function () {
         			$('.events').append("<li>after event fired.</li>");
         		}
         	});
         
         });
      </script>
      <!--// responsiveslides banner-->	  
      <!--About OnScroll-Number-Increase-JavaScript -->
      <script src="js/jquery.waypoints.min.js"></script>
      <script src="js/jquery.countup.js"></script>
      <script>
         $('.counter').countUp();
      </script>
      <!-- //OnScroll-Number-Increase-JavaScript -->
      <!--slider flexisel -->
      <script src="js/jquery.flexisel.js"></script>
      <script>
         $(window).load(function() {
         	$("#flexiselDemo1").flexisel({
         		visibleItems: 4,
         		animationSpeed: 3000,
         		autoPlay:true,
         		autoPlaySpeed: 2000,    		
         		pauseOnHover: true,
         		enableResponsiveBreakpoints: true,
         		responsiveBreakpoints: { 
         			portrait: { 
         				changePoint:480,
         				visibleItems: 1
         			}, 
         			landscape: { 
         				changePoint:640,
         				visibleItems:2
         			},
         			tablet: { 
         				changePoint:768,
         				visibleItems: 3
         			}
         		}
         	});
         	
         });
      </script>
      <!-- //slider flexisel -->
      <!-- slider-pop-up -->
      <script src="js/lsb.min.js"></script>
      <script>
         $(window).load(function() {
         	  $.fn.lightspeedBox();
         	});
      </script>
      <!-- //slider-pop-up -->
      <!-- start-smoth-scrolling -->
      <script src="js/move-top.js"></script>
      <script src="js/easing.js"></script>
      <script>
         jQuery(document).ready(function ($) {
         	$(".scroll").click(function (event) {
         		event.preventDefault();
         		$('html,body').animate({
         			scrollTop: $(this.hash).offset().top
         		}, 900);
         	});
         });
      </script>
      <!-- start-smoth-scrolling -->
      <!-- here stars scrolling icon -->
      <script>
         $(document).ready(function () {
         
         	var defaults = {
         		containerID: 'toTop', // fading element id
         		containerHoverID: 'toTopHover', // fading element hover id
         		scrollSpeed: 1200,
         		easingType: 'linear'
         	};
         	$().UItoTop({
         		easingType: 'easeOutQuart'
         	});
         
         });
      </script>
      <!-- //here ends scrolling icon -->
      <!--bootstrap working-->
      <script src="js/bootstrap.min.js"></script>
      <!-- //bootstrap working-->
   </body>
</html>