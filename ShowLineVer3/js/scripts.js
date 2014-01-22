	$(document).ready(function() {	

	
	$("#nav").show();
	$(".tab-content").hide();
	$("ul#main-nav li:first").addClass("active").show();
	$(".tab-content:first").show();

	$("ul#main-nav li").click(function() {
		$("ul#main-nav li").removeClass("active");
		$(this).addClass("active");
		$(".tab-content").hide();
		var activeTab = $(this).find("a").attr("href");
		$(activeTab).fadeIn();
		return false;
	});
	
	
	
$("#openPanel").click(function () {
      $("div#panel").slideToggle("slow");
	  $("#toggle").toggleClass("open");
    });



$(function () {
        /* the menu	 */
        var $menu = $('#showsMenu');

        /* for each list element,
         * we show the submenu when hovering and
         * expand the span element (title) to 510px
         */
        $menu.children('li').each(function () {
            var $this = $(this);
            //var $span = $this.children('span');
            //$span.data('width', $span.width());

            $this.bind('mouseenter', function () {
                $menu.find('.showsSubMenu').stop(true, true).fadeOut();
                $this.find('.showsSubMenu').fadeIn();
				$this.find('.subReq').addClass("open");

            }).bind('mouseleave', function () {
                $this.find('.showsSubMenu').stop(true, true).fadeOut();
				$this.find('.subReq').removeClass("open");
            }).bind('click', function () {
                $this.find('.showsSubMenu').stop(true, true).fadeOut();
				$this.find('.subReq').removeClass("open");

            });
        });
    });

	
});
	
