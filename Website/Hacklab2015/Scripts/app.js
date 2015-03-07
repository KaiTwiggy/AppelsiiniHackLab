



;(function($,undefined){

	$('.custom-btn').on('click', function(event){
		event.preventDefault();

		var $this = $(this),
			apiEndPoint = '/Api/Relay'
			submittingClass = 'btn-submitting',	
			successClass = 'btn-success3d',	
			errorClass = 'btn-error3d',
			_id = $this.data('id');
		
		$this.addClass(submittingClass);

		$.post(apiEndPoint, {'id':_id}, function(data, textStatus, xhr) {

		})
		.error(function(){
			$this.addClass(errorClass).removeClass(submittingClass);
		})
		.done(function(){
			$this.addClass(successClass).removeClass(submittingClass);
		});



	});


})(jQuery);