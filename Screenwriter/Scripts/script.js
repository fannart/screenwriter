$(document).ready(function () {
	$('#advSearchButton').click(function () {
		if ($('#advancedSearch').is(':visible')) {
			$('#advancedSearch').slideUp('slow');
		}
		else {
			$('#advancedSearch').slideDown('slow');
		}
	});
});