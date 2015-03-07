



;(function($,undefined){

	$('#form-actions').on('click', 'button[type="submit"]', function(event){
		event.preventDefault();

		var $this = $(this),
			submittingClass = 'btn-submitting',	
			successClass = 'btn-success3d',	
			errorClass = 'btn-error3d',
			_data = $this.closest('form').serialize();
		
		$this.addClass(submittingClass);


	});


})(jQuery);