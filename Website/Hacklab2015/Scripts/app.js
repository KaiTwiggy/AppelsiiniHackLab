



;(function($,undefined){

	$('.custom-btn').on('click', function(event){
		event.preventDefault();

		var $this = $(this),
			apiEndPoint = '/Api/Relay'
			submittingClass = 'btn-submitting',	
			successClass = 'btn-success3d',	
			errorClass = 'btn-error3d',
			_action = $this.data('action');
		
		$this.addClass(submittingClass);

		$.post(apiEndPoint, {'action':_action}, function(data, textStatus, xhr) {

		})
		.error(function(){
			$this.addClass(errorClass).removeClass(submittingClass);
		})
		.done(function(){
			$this.addClass(successClass).removeClass(submittingClass);
		});



	});


})(jQuery);