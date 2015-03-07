



;(function($,undefined){

	$('.custom-btn').on('click', function(event){
		event.preventDefault();

		var $this = $(this),
			apiEndPoint = '/Api/Relay'
			submittingClass = 'btn-submitting',	
			successClass = 'btn-success3d',	
			errorClass = 'btn-error3d';
		
		$this.addClass(submittingClass);


		$.post(apiEndPoint, {}, function(data, textStatus, xhr) {
			$this.addClass(successClass).removeClass(submittingClass);
		});



	});


})(jQuery);