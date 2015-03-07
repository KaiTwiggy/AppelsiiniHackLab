



;(function($,undefined){

	$('.custom-btn').on('click', function(event){
		event.preventDefault();

		var $this = $(this),
			submittingClass = 'btn-submitting',	
			successClass = 'btn-success3d',	
			errorClass = 'btn-error3d';
		
		$this.addClass(submittingClass);

		setTimeout(function(){
			$this.addClass(successClass).removeClass(submittingClass);
		},
			2000
		);


	});


})(jQuery);