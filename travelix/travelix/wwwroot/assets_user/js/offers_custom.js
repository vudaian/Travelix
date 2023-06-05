

$(document).ready(function()
{

	initIsotopeFiltering();

    function initIsotopeFiltering()
    {
    	var sortBtn = $('.sort_btn');
    	var filterBtn = $('.filter_btn');

    	if($('.offers_grid').length)
    	{
    		var grid = $('.offers_grid').isotope({
    			itemSelector: '.offers_item',
	            getSortData: {
	            	price: function(itemElement)
	            	{
	            		var priceEle = $(itemElement).find('.offers_price').text().replace( '$', '' );
	            		return parseFloat(priceEle);
	            	},
	            	name: '.offer_name',
	            	stars: function(itemElement)
	            	{
	            		var starsEle = $(itemElement).find('.offers_rating');
	            		var stars = starsEle.attr("data-rating");
	            		return stars;
	            	}
	            },
	            animationOptions: {
	                duration: 800,
	                easing: 'linear',
	                queue: false
	            }
	        });

    		// Sorting
	        sortBtn.each(function()
	        {
	        	$(this).on('click', function()
	        	{
	        		var parent = $(this).parent().parent().find('.sorting_text');
	        		parent.text($(this).text());
	        		var option = $(this).attr('data-isotope-option');
	        		option = JSON.parse( option );
    				grid.isotope( option );
	        	});
	        });

	        // Filtering
	        $('.filter_btn').on('click', function()
	        {
	        	var parent = $(this).parent().parent().find('.sorting_text');
	        	parent.text($(this).text());
		        var filterValue = $(this).attr('data-filter');
  				grid.isotope({ filter: filterValue });
	        });
    	}
    }
});