
$(document).ready(function () {
	$('#advSearchButton').click(function () {
		if ($('#advancedSearch').is(':visible')) {
			$('#advancedSearch').slideUp('slow');
		}
		else {
			$('#advancedSearch').slideDown('slow');
		}
	});
	// Handles all actions to request an existing subtitle.
	$('.requestSubtitle').on('click', function (e) {
		e.preventDefault();
		$this = $(this);
		var href = $this.attr('href');
		var id = $this.attr('data-id');
		$.ajax({
			type: 'GET',
			contentType: 'application/json; charset=utf-8',
			url: href,
			dataType: 'json',
			success: function (value) {
				// TODO: Keep an eye on this functionality if the markup changes.
				// TODO: if value.requestCreated == false, activate error.
				$this.parent().prev().text(value.requestCount);
			},
			error: function () {
				// Error handling for when a user is not registered.
				$('#registerToRequestError').modal();
			}
		});
	});
});